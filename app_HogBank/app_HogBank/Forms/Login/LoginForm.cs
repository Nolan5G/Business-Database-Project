using app_HogBank.Models;
using app_HogBank.Models.Arguments;
using app_HogBank.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_HogBank.Forms.Login
{
    public partial class LoginForm : Form
    {
        private DatabaseService databaseService;

        public LoginForm()
        {
            databaseService = new DatabaseService(this.formError, this.formInfo);

            InitializeComponent();
 
            FormBorderStyle = FormBorderStyle.None;
        }

        //=====================================================================
        // General Form Management
        //=====================================================================
        private void LoginForm_Load(object sender, EventArgs e)
        {
            // The login form is the main instance, so we tag it to reference the main tag.
            this.Tag = this;

            // Header Draggable Subscription
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            foreach (Control control in this.panelHeader.Controls)
            {
                if(!(control.Name.Equals("buttonMinimize") || control.Name.Equals("buttonMaximize") || control.Name.Equals("buttonExit")))
                {
                    control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
                }
            }

            // Custom Exit Button Subscription
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.databaseService.cleanup();
            this.Close();
        }

        private void buttonMaximize_Click(object sender, EventArgs e) { WindowManager.handleWindowMaximization(this); }

        private void buttonMinimize_Click(object sender, EventArgs e) { WindowManager.handleWindowMinimization(this); }

        private void mouseDown(object sender, MouseEventArgs e) { WindowManager.fireMouseDownEvent(Handle, e); }

        //=====================================================================
        //  Custom Event Handlers
        //=====================================================================
        private void formError(object sender, FormErrorArg arg)
        {
            MessageBox.Show(arg.message);
        }

        private void formInfo(object sender, FormInfoArg arg)
        {
            MessageBox.Show(arg.message);
        }

        //=====================================================================
        // Form Custom Functionality
        //=====================================================================
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(preValidateTextboxes())
            {
                List<LoginVO> matchingLoginInfo = databaseService.GetMatchingLogin(textBoxUsername.Text, textBoxPassword.Text);

                if(matchingLoginInfo.Count > 1)
                {
                    formError(this, new FormErrorArg("Credentials correct, but system error occured.  Please contact your local Hog Bank branch manager for more info.", null));
                }
                if (matchingLoginInfo.Count < 1)
                {
                    formError(this, new FormErrorArg("Invalid Credentials.  Be sure to enter your correct username and password.", null));
                }
                if (matchingLoginInfo.Count == 1)
                {
                    LoginVO currentLogin = matchingLoginInfo[0];
                    CustomerVO customerInfo = databaseService.GetCustomerInformationFromRegistrationId(currentLogin.Id);
                    if(customerInfo == null)
                    {
                        EmployeeVO employeeInfo = databaseService.GetEmployeeInformationFromRegistrationId(currentLogin.Id);

                        if(employeeInfo == null)
                        {
                            formInfo(this, new FormInfoArg("Credentials are currently inactive.  Please contact your local Hog Bank branch manager for more info"));
                        } 
                        else
                        {
                            // Before exiting, unsubscribe.
                            this.databaseService.OnFormError -= this.formError;
                            WindowManager.navigateToFormStartTag(this, this.GetType(), typeof(Homescreen), employeeInfo);
                        }
                    }
                    else
                    {
                        // Before exiting, unsubscribe.
                        this.databaseService.OnFormError -= this.formError;
                        WindowManager.navigateToFormStartTag(this, this.GetType(), typeof(Homescreen), customerInfo);
                    }
                }
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SignupForm form = new SignupForm();
            form.Tag = this;
            form.Show(this);
            this.Hide();
        }

        //=====================================================================
        // Utility Functions
        //=====================================================================
        private bool preValidateTextboxes()
        {
            bool result = true;
            if(textBoxUsername.Text.Equals("") || textBoxUsername.Text.Length > 30)
            {
                formError(this, new FormErrorArg("Invalid username specified.  Must not be blank OR have length greater than 30", null));
                result = false;
            }
            if (textBoxPassword.Text.Equals("") || textBoxPassword.Text.Length > 30)
            {
                formError(this, new FormErrorArg("Invalid password specified.  Must not be blank OR have length greater than 30", null));
                result = false;
            }
            return result;
        }
    }
}
