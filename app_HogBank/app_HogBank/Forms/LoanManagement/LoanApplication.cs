using app_HogBank.Models;
using app_HogBank.Models.Arguments;
using app_HogBank.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_HogBank.Forms.LoanManagement
{
    public partial class LoanApplication : Form
    {
        DatabaseService databaseService;
        dynamic storedObject;
        Type storedType;
        UserSessionFlags sessionFlags;

        public LoanApplication()
        {
            InitializeComponent();
        }

        //=====================================================================
        // Window Management Snippets
        //=====================================================================
        private void LoanApplication_Load(object sender, EventArgs e)
        {
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            foreach (Control control in this.panelHeader.Controls)
            {
                if (!(control.Name.Equals("buttonMinimize") || control.Name.Equals("buttonMaximize") || control.Name.Equals("buttonExit")))
                {
                    control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
                }
            }

            // Window Max/Min/(Exit or Back)
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);

            // Database Service Initialization
            databaseService = new DatabaseService(onError, onInfo);

            // Set Stored Tag
            Type tagType = WindowManager.getTagType(this.Tag); ;
            if (tagType != null)
            {
                storedType = tagType;
                storedObject = Convert.ChangeType(this.Tag, storedType);

                // Determine if the user is a teller / branch manager.
                sessionFlags = WindowManager.setUserSessionFlags(storedObject);
            }
            else
            {
                MessageBox.Show("System Error: Could not convert user information successfully");
                throw new Exception("Type of Form.Tag object is null");
            }

            // Sidebar Toggle
            sidebarManager = new SidebarManager(this, this.GetType(), flowPanelA, flowPanelB, buttonToggle, buttonToggle2, sessionFlags);
            this.buttonToggle.Click += new System.EventHandler(this.buttonToggle_Click);
            this.buttonToggle2.Click += new System.EventHandler(this.buttonToggle2_Click);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            WindowManager.navigateToForm(this, this.GetType(), typeof(Homescreen));
        }

        private void buttonMaximize_Click(object sender, EventArgs e) { WindowManager.handleWindowMaximization(this); }

        private void buttonMinimize_Click(object sender, EventArgs e) { WindowManager.handleWindowMinimization(this); }

        private void mouseDown(object sender, MouseEventArgs e) { WindowManager.fireMouseDownEvent(Handle, e); }

        //=====================================================================
        // Sidebar Menu
        //=====================================================================
        SidebarManager sidebarManager;
        private void buttonToggle_Click(object sender, EventArgs e)
        {
            sidebarManager.buttonToggleClick();
        }
        private void buttonToggle2_Click(object sender, EventArgs e)
        {
            sidebarManager.buttonToggle2Click();
        }

        //=====================================================================
        // Database Service Event Handlers
        //=====================================================================
        private void onInfo(object sender, FormInfoArg arg)
        {
            MessageBox.Show(arg.message);
        }

        private void onError(object sender, FormErrorArg arg)
        {
            MessageBox.Show(arg.message);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxAccountNumber.Text != null && comboBoxLoanType.Text != null && textBoxInterest.Text != null && textBoxPrincipal.Text != null && textBoxSocialSecurity.Text != null && textBoxCreditScore.Text != null)
            {
                decimal dec_out, dec_out_2;
                if ((new Regex(@"^\d+$").Match(textBoxAccountNumber.Text).Success) && Decimal.TryParse(textBoxInterest.Text, out dec_out) && Decimal.TryParse(textBoxPrincipal.Text, out dec_out_2) && (new Regex(@"^\d+$").Match(textBoxSocialSecurity.Text).Success) && (new Regex(@"^\d+$").Match(textBoxCreditScore.Text).Success))
                {
                    databaseService.AddLoanApplication(new LoanApplicationVO(-1, Convert.ToInt32(textBoxAccountNumber.Text), -1, Convert.ToDouble(textBoxPrincipal.Text), comboBoxLoanType.Text, Convert.ToInt32(textBoxInterest.Text), textBoxSocialSecurity.Text, Convert.ToInt32(textBoxCreditScore.Text), null));

                    WindowManager.navigateToForm(this, this.GetType(), typeof(Homescreen));
                }
            }
            else
            {
                MessageBox.Show("Invalid Loan Info Provided.");
            }
        }

        private void comboBoxLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxLoanType.SelectedItem.ToString() == "Standard")
            {
                textBoxInterest.Text = "5";
            }
            if(comboBoxLoanType.SelectedItem.ToString() == "Premium")
            {
                textBoxInterest.Text = "2";
            }
        }
    }
}
