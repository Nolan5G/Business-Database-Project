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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_HogBank.Forms.ManagerScreens
{
    public partial class SalesTrendReport : Form
    {
        DatabaseService databaseService;
        dynamic storedObject;
        Type storedType;
        UserSessionFlags sessionFlags;

        public SalesTrendReport()
        {
            InitializeComponent();
        }

        //=====================================================================
        // Window Management Snippets
        //=====================================================================
        private void SalesTrendReport_Load(object sender, EventArgs e)
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
    }
}
