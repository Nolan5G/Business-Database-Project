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
        public HomeScreenLoginForm()
        {
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
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
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

        //=====================================================================
        // Form Custom Functionality
        //=====================================================================
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Homescreen form = new Homescreen();
            form.Tag = this;
            form.Show(this);
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HomescreenSignupForm form = new HomescreenSignupForm();
            form.Tag = this;
            form.Show(this);
            this.Hide();
        }
    }
}
