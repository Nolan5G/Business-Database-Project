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

namespace app_HogBank.Forms.AccountManagement
{
    public partial class AccountTransaction : Form
    {
        DatabaseService databaseService;
        dynamic storedObject;
        Type storedType;

        public AccountTransaction()
        {
            InitializeComponent();
        }

        //=====================================================================
        // Window Management Snippets
        //=====================================================================
        private void AccountTransaction_Load(object sender, EventArgs e)
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

            // Sidebar Toggle
            sidebarManager = new SidebarManager(this, this.GetType(), flowPanelA, flowPanelB, buttonToggle, buttonToggle2);
            this.buttonToggle.Click += new System.EventHandler(this.buttonToggle_Click);
            this.buttonToggle2.Click += new System.EventHandler(this.buttonToggle2_Click);

            // Database Service Initialization
            databaseService = new DatabaseService(onError, onInfo);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.databaseService.cleanup();
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

        //=====================================================================
        // Custom Form Business Logic
        //=====================================================================
        private void buttonSubmitTransaction_Click(object sender, EventArgs e)
        {
            if(verifyTextboxes())
            {
                int account_number = Convert.ToInt32(textBoxAccountNumber.Text);
                double amount_value = Convert.ToDouble(textBoxAmount.Text);
                double amount_changed = (comboBoxDebitCredit.Text == "Credit") ? amount_value : 0 - amount_value;

                databaseService.AddAccountTransaction(account_number, amount_changed);

                WindowManager.navigateToForm(this, this.GetType(), typeof(Homescreen));
            }
            else
            {
                MessageBox.Show("Invalid Transaction Info Provided: Account Number must be an integer.  Combobox must have length < 8.  Amount changed should be a decimal.");
            }
        }

        private bool verifyTextboxes()
        {
            // Assume true until proven not true.
            bool result = true;
            if (textBoxAccountNumber.Text == null || comboBoxDebitCredit.Text == null || textBoxAmount.Text == null)
                result = false;
            else if (textBoxAccountNumber.Text == "" || comboBoxDebitCredit.Text == "" || textBoxAmount.Text == "" || comboBoxDebitCredit.Text.Length > 8)
                result = false;

            return result;
        }
    }
}
