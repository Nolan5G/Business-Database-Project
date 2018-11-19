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

namespace app_HogBank.Forms.AccountManagement
{
    public partial class AccountCreate : Form
    {
        DatabaseService databaseService;
        dynamic storedObject;
        Type storedType;

        public AccountCreate()
        {
            InitializeComponent();
        }

        //=====================================================================
        // Window Management Snippets
        //=====================================================================
        private void AccountCreate_Load(object sender, EventArgs e)
        {
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

            // Sidebar Toggle
            sidebarManager = new SidebarManager(this, this.GetType(), flowPanelA, flowPanelB, buttonToggle, buttonToggle2);
            this.buttonToggle.Click += new System.EventHandler(this.buttonToggle_Click);
            this.buttonToggle2.Click += new System.EventHandler(this.buttonToggle2_Click);

            databaseService = new DatabaseService(onError, onInfo);

            // Update Welcome Message
            Type tagType = WindowManager.getTagType(this.Tag); ;
            if (tagType == null)
            {
                MessageBox.Show("System Error: Could not convert user information successfully");
            }
            else
            {
                storedType = tagType;
                storedObject = Convert.ChangeType(this.Tag, storedType);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != null && textBox1.Text != null)
            {
                if(textBox1.Text.Length > 0 && textBox1.Text.Length <= 30 && comboBox1.Text.Length <= 8 && comboBox1.Text.Length > 0)
                {
                    databaseService.AddNewAccount(storedObject.Id, textBox1.Text, comboBox1.Text);
                }
            }   
            else
            {
                MessageBox.Show("Invalid Account Info Provided: Account Name must have legnth > 0 and < 30.  Combobox must have length < 8");
            }
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
    }
}
