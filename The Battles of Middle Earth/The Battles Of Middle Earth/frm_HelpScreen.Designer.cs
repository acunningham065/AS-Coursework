namespace The_Battles_Of_Middle_Earth
{
    partial class frm_HelpScreen
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
            this.tab_HelpOptions = new System.Windows.Forms.TabControl();
            this.tab_UserRegHelp = new System.Windows.Forms.TabPage();
            this.rtxt_UserRegHelp = new System.Windows.Forms.RichTextBox();
            this.tab_MainGameHelp = new System.Windows.Forms.TabPage();
            this.rtxt_MainGameHelp = new System.Windows.Forms.RichTextBox();
            this.tab_HelpOptions.SuspendLayout();
            this.tab_UserRegHelp.SuspendLayout();
            this.tab_MainGameHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_HelpOptions
            // 
            this.tab_HelpOptions.Controls.Add(this.tab_UserRegHelp);
            this.tab_HelpOptions.Controls.Add(this.tab_MainGameHelp);
            this.tab_HelpOptions.Location = new System.Drawing.Point(20, 12);
            this.tab_HelpOptions.Name = "tab_HelpOptions";
            this.tab_HelpOptions.SelectedIndex = 0;
            this.tab_HelpOptions.Size = new System.Drawing.Size(744, 688);
            this.tab_HelpOptions.TabIndex = 0;
            // 
            // tab_UserRegHelp
            // 
            this.tab_UserRegHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tab_UserRegHelp.Controls.Add(this.rtxt_UserRegHelp);
            this.tab_UserRegHelp.Location = new System.Drawing.Point(4, 22);
            this.tab_UserRegHelp.Name = "tab_UserRegHelp";
            this.tab_UserRegHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tab_UserRegHelp.Size = new System.Drawing.Size(736, 662);
            this.tab_UserRegHelp.TabIndex = 0;
            this.tab_UserRegHelp.Text = "User Registration";
            // 
            // rtxt_UserRegHelp
            // 
            this.rtxt_UserRegHelp.BackColor = System.Drawing.Color.Khaki;
            this.rtxt_UserRegHelp.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_UserRegHelp.ForeColor = System.Drawing.Color.Gold;
            this.rtxt_UserRegHelp.Location = new System.Drawing.Point(6, 6);
            this.rtxt_UserRegHelp.Name = "rtxt_UserRegHelp";
            this.rtxt_UserRegHelp.ReadOnly = true;
            this.rtxt_UserRegHelp.Size = new System.Drawing.Size(724, 651);
            this.rtxt_UserRegHelp.TabIndex = 0;
            this.rtxt_UserRegHelp.Text = "";
            // 
            // tab_MainGameHelp
            // 
            this.tab_MainGameHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tab_MainGameHelp.Controls.Add(this.rtxt_MainGameHelp);
            this.tab_MainGameHelp.Location = new System.Drawing.Point(4, 22);
            this.tab_MainGameHelp.Name = "tab_MainGameHelp";
            this.tab_MainGameHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tab_MainGameHelp.Size = new System.Drawing.Size(736, 662);
            this.tab_MainGameHelp.TabIndex = 1;
            this.tab_MainGameHelp.Text = "Main Game";
            // 
            // rtxt_MainGameHelp
            // 
            this.rtxt_MainGameHelp.BackColor = System.Drawing.Color.Khaki;
            this.rtxt_MainGameHelp.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_MainGameHelp.ForeColor = System.Drawing.Color.Gold;
            this.rtxt_MainGameHelp.Location = new System.Drawing.Point(6, 6);
            this.rtxt_MainGameHelp.Name = "rtxt_MainGameHelp";
            this.rtxt_MainGameHelp.Size = new System.Drawing.Size(724, 650);
            this.rtxt_MainGameHelp.TabIndex = 1;
            this.rtxt_MainGameHelp.Text = "";
            // 
            // frm_HelpScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 712);
            this.Controls.Add(this.tab_HelpOptions);
            this.Name = "frm_HelpScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help Screen";
            this.Load += new System.EventHandler(this.frm_HelpScreen_Load);
            this.tab_HelpOptions.ResumeLayout(false);
            this.tab_UserRegHelp.ResumeLayout(false);
            this.tab_MainGameHelp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_HelpOptions;
        private System.Windows.Forms.TabPage tab_MainGameHelp;
        private System.Windows.Forms.RichTextBox rtxt_MainGameHelp;
        private System.Windows.Forms.TabPage tab_UserRegHelp;
        private System.Windows.Forms.RichTextBox rtxt_UserRegHelp;
    }
}