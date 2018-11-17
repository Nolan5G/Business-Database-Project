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

namespace app_HogBank.Forms
{
    public partial class HomeScreenLoginForm : Form
    {
        private DatabaseService databaseService;

        public HomeScreenLoginForm()
        {
            databaseService = new DatabaseService();

            InitializeComponent();
 
            FormBorderStyle = FormBorderStyle.None;
        }

        //=====================================================================
        // General Form Management
        //=====================================================================
        // Constants and Variables
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Functions
        private void HomeScreenLoginForm_Load(object sender, EventArgs e)
        {
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            foreach (Control control in this.panelHeader.Controls)
            {
                if(!(control.Name.Equals("buttonMinimize") || control.Name.Equals("buttonMaximize") || control.Name.Equals("buttonExit")))
                {
                    control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
                }
            }

            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonMaximize.Click += new System.EventHandler(this.buttonMaximize_Click);
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);

            this.databaseService.OnFormError += this.formError;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.databaseService.OnFormError -= this.formError;
            this.Close();
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if(this.WindowState != FormWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void formError(object sender, FormErrorArg arg)
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
                    Homescreen form = new Homescreen();
                    form.Tag = this;
                    form.Show(this);
                    this.Hide();
                }
                
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HomescreenSignupForm form = new HomescreenSignupForm();
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
