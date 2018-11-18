using app_HogBank.Forms.AccountManagement;
using app_HogBank.Forms.Login;
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
    public partial class Homescreen : Form
    {
        public Homescreen()
        {
            InitializeComponent();
            if (this.flowPanelA.Size.Height != 0)
                fpa_height = this.flowPanelA.Size.Height;
            else
                fpa_height = 300;
        }

        //=====================================================================
        // Window Management Snippets
        //=====================================================================
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void Homescreen_Load(object sender, EventArgs e)
        {
            // Mouse Event Handling
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            foreach (Control control in this.panelHeader.Controls)
            {
                if (!(control.Name.Equals("buttonMinimize") || control.Name.Equals("buttonMaximize") || control.Name.Equals("buttonExit")))
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
            var form = (LoginForm)Tag;
            form.Show();
            this.Close();
        }

        private void buttonMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
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

        private int fpa_height;
        private void buttonToggle_Click(object sender, EventArgs e)
        {
            int original_width = flowPanelA.Size.Width - 5;
            if (((String)flowPanelA.Tag).Equals("Expanded"))
            {
                flowPanelA.Size = new Size(flowPanelA.Size.Width, 0);
                flowPanelA.Tag = "Collapsed";
                flowPanelA.Controls.Clear();

                // Adjust Toggle2 and FPB
                buttonToggle2.Location = new Point(buttonToggle2.Location.X, buttonToggle2.Location.Y - fpa_height);
                flowPanelB.Location = new Point(flowPanelB.Location.X, flowPanelB.Location.Y - fpa_height);
            }
            else if(((String)flowPanelA.Tag).Equals("Collapsed"))
            {
                flowPanelA.Size = new Size(flowPanelA.Size.Width, fpa_height);
                flowPanelA.Tag = "Expanded";
                
                flowPanelA.Controls.Add(createNewLabel("Account Management", original_width));
                flowPanelA.Controls.Add(createNewButtonSpecific("Account History", original_width, new AccountHistory()));
                flowPanelA.Controls.Add(createNewButton("Deposits", original_width));
                flowPanelA.Controls.Add(createNewButton("Withdrawls", original_width));

                flowPanelA.Controls.Add(createNewLabel("Loan Management", original_width));
                flowPanelA.Controls.Add(createNewButton("Apply for Loan", original_width));
                flowPanelA.Controls.Add(createNewButton("Loan History", original_width));

                flowPanelA.Controls.Add(createNewLabel("Investments", original_width));
                flowPanelA.Controls.Add(createNewButton("Stocks", original_width));
                flowPanelA.Controls.Add(createNewButton("Bonds", original_width));
                flowPanelA.Controls.Add(createNewButton("ETF", original_width));

                buttonToggle2.Location = new Point(buttonToggle2.Location.X, buttonToggle2.Location.Y + fpa_height);
                flowPanelB.Location = new Point(flowPanelB.Location.X, flowPanelB.Location.Y + fpa_height);
            }
        }

        private void buttonToggle2_Click(object sender, EventArgs e)
        {
            int original_width = flowPanelB.Size.Width;
            if (((String)flowPanelB.Tag).Equals("Expanded"))
            {
                flowPanelB.Size = new Size(flowPanelB.Size.Width, 0);
                flowPanelB.Tag = "Collapsed";
                flowPanelB.Controls.Clear();
            }
            else if (((String)flowPanelB.Tag).Equals("Collapsed"))
            {
                flowPanelB.Size = new Size(flowPanelB.Size.Width, fpa_height * 3 / 4);
                flowPanelB.Tag = "Expanded";
                flowPanelB.Controls.Add(createNewLabel("Manager Tools", original_width - 5));
                flowPanelB.Controls.Add(createNewButton("Employee Management", original_width - 5));
                flowPanelB.Controls.Add(createNewButton("Profit and Loss Report", original_width - 5));
                flowPanelB.Controls.Add(createNewButton("Sales Trend Report", original_width - 5));
            }
        }

        private Button createNewButton(String text, int width)
        {
            Button temp = new Button();
            temp.Text = text;
            temp.Width = width;
            temp.Tag = this;
            //temp.Click += new System.EventHandler(genericClick);
            return temp;
        }

        private Button createNewButtonSpecific(String text, int width, Form f)
        {
            Button temp = new Button();
            temp.Text = text;
            temp.Width = width;
            temp.Tag = f;
            temp.Click += new System.EventHandler(genericClick);
            return temp;
        }

        private void genericClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Form tempForm = (Form)btn.Tag;
            tempForm.Tag = this;
            tempForm.Show(this);
            this.Hide();
        }

        private Label createNewLabel(String text, int width)
        {
            Label temp = new Label();
            temp.Text = text;
            temp.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            temp.Width = width;
            //accountManagement.BackColor = Color.Gray;
            //accountManagement.ForeColor = Color.White;
            return temp;
        }
    }
}
