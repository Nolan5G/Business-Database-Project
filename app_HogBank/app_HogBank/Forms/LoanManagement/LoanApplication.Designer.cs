namespace app_HogBank.Forms.LoanManagement
{
    partial class LoanApplication
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoanApplication));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.PictureBox();
            this.buttonMaximize = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonToggle2 = new System.Windows.Forms.Button();
            this.flowPanelB = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonToggle = new System.Windows.Forms.Button();
            this.flowPanelA = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxAccountNumber = new System.Windows.Forms.TextBox();
            this.comboBoxLoanType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInterest = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPrincipal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSocialSecurity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCreditScore = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Firebrick;
            this.panelHeader.Controls.Add(this.buttonMinimize);
            this.panelHeader.Controls.Add(this.buttonMaximize);
            this.panelHeader.Controls.Add(this.pictureBox2);
            this.panelHeader.Controls.Add(this.buttonExit);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Location = new System.Drawing.Point(0, 1);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1203, 101);
            this.panelHeader.TabIndex = 2;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(1082, 15);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(32, 29);
            this.buttonMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonMinimize.TabIndex = 3;
            this.buttonMinimize.TabStop = false;
            // 
            // buttonMaximize
            // 
            this.buttonMaximize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMaximize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMaximize.Image")));
            this.buttonMaximize.Location = new System.Drawing.Point(1120, 15);
            this.buttonMaximize.Name = "buttonMaximize";
            this.buttonMaximize.Size = new System.Drawing.Size(32, 29);
            this.buttonMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonMaximize.TabIndex = 2;
            this.buttonMaximize.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(646, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(1158, 15);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(32, 29);
            this.buttonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonExit.TabIndex = 1;
            this.buttonExit.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(626, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hog Bank - Central System Access";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.buttonToggle2);
            this.panel1.Controls.Add(this.flowPanelB);
            this.panel1.Controls.Add(this.buttonToggle);
            this.panel1.Controls.Add(this.flowPanelA);
            this.panel1.Location = new System.Drawing.Point(12, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 670);
            this.panel1.TabIndex = 5;
            // 
            // buttonToggle2
            // 
            this.buttonToggle2.BackColor = System.Drawing.Color.Red;
            this.buttonToggle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToggle2.ForeColor = System.Drawing.Color.White;
            this.buttonToggle2.Location = new System.Drawing.Point(3, 52);
            this.buttonToggle2.Name = "buttonToggle2";
            this.buttonToggle2.Size = new System.Drawing.Size(281, 36);
            this.buttonToggle2.TabIndex = 5;
            this.buttonToggle2.Text = "Employee Management System";
            this.buttonToggle2.UseVisualStyleBackColor = false;
            // 
            // flowPanelB
            // 
            this.flowPanelB.BackColor = System.Drawing.SystemColors.Control;
            this.flowPanelB.Location = new System.Drawing.Point(2, 94);
            this.flowPanelB.Name = "flowPanelB";
            this.flowPanelB.Size = new System.Drawing.Size(282, 0);
            this.flowPanelB.TabIndex = 4;
            this.flowPanelB.Tag = "Collapsed";
            // 
            // buttonToggle
            // 
            this.buttonToggle.BackColor = System.Drawing.Color.Red;
            this.buttonToggle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonToggle.ForeColor = System.Drawing.Color.White;
            this.buttonToggle.Location = new System.Drawing.Point(4, 4);
            this.buttonToggle.Name = "buttonToggle";
            this.buttonToggle.Size = new System.Drawing.Size(281, 36);
            this.buttonToggle.TabIndex = 3;
            this.buttonToggle.Text = "Customer Services";
            this.buttonToggle.UseVisualStyleBackColor = false;
            // 
            // flowPanelA
            // 
            this.flowPanelA.BackColor = System.Drawing.SystemColors.Control;
            this.flowPanelA.Location = new System.Drawing.Point(3, 46);
            this.flowPanelA.Name = "flowPanelA";
            this.flowPanelA.Size = new System.Drawing.Size(282, 0);
            this.flowPanelA.TabIndex = 2;
            this.flowPanelA.Tag = "Collapsed";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(339, 497);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 6;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(339, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Loan Application";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(339, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "What Account Number will be associated with this loan arrangement?";
            // 
            // textBoxAccountNumber
            // 
            this.textBoxAccountNumber.Location = new System.Drawing.Point(679, 161);
            this.textBoxAccountNumber.Name = "textBoxAccountNumber";
            this.textBoxAccountNumber.Size = new System.Drawing.Size(121, 20);
            this.textBoxAccountNumber.TabIndex = 9;
            // 
            // comboBoxLoanType
            // 
            this.comboBoxLoanType.FormattingEnabled = true;
            this.comboBoxLoanType.Items.AddRange(new object[] {
            "Standard",
            "Premium"});
            this.comboBoxLoanType.Location = new System.Drawing.Point(679, 190);
            this.comboBoxLoanType.Name = "comboBoxLoanType";
            this.comboBoxLoanType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLoanType.TabIndex = 10;
            this.comboBoxLoanType.SelectedIndexChanged += new System.EventHandler(this.comboBoxLoanType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "What type of loan are you wishing to take?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(571, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Loan Interest (%):";
            // 
            // textBoxInterest
            // 
            this.textBoxInterest.Location = new System.Drawing.Point(679, 226);
            this.textBoxInterest.Name = "textBoxInterest";
            this.textBoxInterest.ReadOnly = true;
            this.textBoxInterest.Size = new System.Drawing.Size(121, 20);
            this.textBoxInterest.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "What is the loan principal / amount borrowed?";
            // 
            // textBoxPrincipal
            // 
            this.textBoxPrincipal.Location = new System.Drawing.Point(679, 265);
            this.textBoxPrincipal.Name = "textBoxPrincipal";
            this.textBoxPrincipal.Size = new System.Drawing.Size(121, 20);
            this.textBoxPrincipal.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Background Check Information:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(342, 394);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "What is your social security number?";
            // 
            // textBoxSocialSecurity
            // 
            this.textBoxSocialSecurity.Location = new System.Drawing.Point(679, 387);
            this.textBoxSocialSecurity.Name = "textBoxSocialSecurity";
            this.textBoxSocialSecurity.Size = new System.Drawing.Size(121, 20);
            this.textBoxSocialSecurity.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(342, 434);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "What was your reported credit score?";
            // 
            // textBoxCreditScore
            // 
            this.textBoxCreditScore.Location = new System.Drawing.Point(679, 427);
            this.textBoxCreditScore.Name = "textBoxCreditScore";
            this.textBoxCreditScore.Size = new System.Drawing.Size(121, 20);
            this.textBoxCreditScore.TabIndex = 20;
            // 
            // LoanApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 669);
            this.Controls.Add(this.textBoxCreditScore);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxSocialSecurity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPrincipal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxInterest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxLoanType);
            this.Controls.Add(this.textBoxAccountNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoanApplication";
            this.Text = "TransactionApproval";
            this.Load += new System.EventHandler(this.LoanApplication_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox buttonMinimize;
        private System.Windows.Forms.PictureBox buttonMaximize;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonToggle2;
        private System.Windows.Forms.FlowLayoutPanel flowPanelB;
        private System.Windows.Forms.Button buttonToggle;
        private System.Windows.Forms.FlowLayoutPanel flowPanelA;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxAccountNumber;
        private System.Windows.Forms.ComboBox comboBoxLoanType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInterest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrincipal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSocialSecurity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCreditScore;
    }
}