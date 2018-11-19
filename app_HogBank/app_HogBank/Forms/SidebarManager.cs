using app_HogBank.Forms.AccountManagement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_HogBank.Forms
{
    class SidebarManager
    {
        public int fpa_height;
        private dynamic formReference;
        private FlowLayoutPanel flowPanelA;
        private FlowLayoutPanel flowPanelB;
        private Button buttonToggle;
        private Button buttonToggle2;

        public SidebarManager(Form formContext, Type formType, FlowLayoutPanel flowPanelA, FlowLayoutPanel flowPanelB, Button buttonToggle, Button buttonToggle2)
        {
            this.formReference = Convert.ChangeType(formContext, formType);

            this.flowPanelA = flowPanelA;
            this.flowPanelB = flowPanelB;
            this.buttonToggle = buttonToggle;
            this.buttonToggle2 = buttonToggle2;

            if (flowPanelA.Size.Height != 0)
                fpa_height = flowPanelA.Size.Height;
            else
                fpa_height = 300;
        }

        public void buttonToggleClick()
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
            else if (((String)flowPanelA.Tag).Equals("Collapsed"))
            {
                flowPanelA.Size = new Size(flowPanelA.Size.Width, fpa_height);
                flowPanelA.Tag = "Expanded";

                flowPanelA.Controls.Add(createNewButtonSpecific("Create Account", original_width, typeof(AccountCreate)));
                flowPanelA.Controls.Add(createNewButtonSpecific("Account History", original_width, typeof(AccountHistory)));
                flowPanelA.Controls.Add(createNewButtonSpecific("Deposits or Withdrawls", original_width, typeof(AccountTransaction)));

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

        public void buttonToggle2Click()
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

        private Button createNewButtonSpecific(String text, int width, Type formType)
        {
            Button temp = new Button();
            temp.Text = text;
            temp.Width = width;
            temp.Tag = formType;
            temp.Click += new System.EventHandler(genericClick);
            return temp;
        }

        private void genericClick(object sender, EventArgs e)
        {
            // Get the button object
            Button btn = (Button)sender;

            // Find the FormType tagged to the button
            Type type = (Type)btn.Tag;

            // Navigate
            WindowManager.navigateToForm(formReference, formReference.GetType(), type);
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
