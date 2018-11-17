namespace app_HogBank.Forms
{
    partial class AccountHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountHistory));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonMinimize = new System.Windows.Forms.PictureBox();
            this.buttonMaximize = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).BeginInit();
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
            this.buttonMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.BackgroundImage")));
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
            this.buttonMaximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMaximize.BackgroundImage")));
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
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
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
            // AccountHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountHistory";
            this.Text = "AccountHistory";
            this.Load += new System.EventHandler(this.AccountHistory_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox buttonMinimize;
        private System.Windows.Forms.PictureBox buttonMaximize;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox buttonExit;
        private System.Windows.Forms.Label label1;
    }
}