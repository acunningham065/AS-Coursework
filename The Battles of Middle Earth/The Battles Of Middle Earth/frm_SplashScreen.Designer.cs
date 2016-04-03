namespace The_Battles_Of_Middle_Earth
{
    partial class frm_SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.lbl_SplashScreenTitle = new System.Windows.Forms.Label();
            this.lbl_Version = new System.Windows.Forms.Label();
            this.tmr_SplashScreen = new System.Windows.Forms.Timer(this.components);
            this.pbx_SplashScreenGraphic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_SplashScreenGraphic)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_SplashScreenTitle
            // 
            this.lbl_SplashScreenTitle.AutoSize = true;
            this.lbl_SplashScreenTitle.Font = new System.Drawing.Font("Trebuchet MS", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SplashScreenTitle.ForeColor = System.Drawing.Color.Gold;
            this.lbl_SplashScreenTitle.Location = new System.Drawing.Point(109, 51);
            this.lbl_SplashScreenTitle.Name = "lbl_SplashScreenTitle";
            this.lbl_SplashScreenTitle.Size = new System.Drawing.Size(466, 43);
            this.lbl_SplashScreenTitle.TabIndex = 0;
            this.lbl_SplashScreenTitle.Text = "The Battles of Middle Earth";
            // 
            // lbl_Version
            // 
            this.lbl_Version.AutoSize = true;
            this.lbl_Version.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Version.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Version.Location = new System.Drawing.Point(12, 520);
            this.lbl_Version.Name = "lbl_Version";
            this.lbl_Version.Size = new System.Drawing.Size(70, 15);
            this.lbl_Version.TabIndex = 2;
            this.lbl_Version.Text = "Version 1.0";
            // 
            // tmr_SplashScreen
            // 
            this.tmr_SplashScreen.Enabled = true;
            this.tmr_SplashScreen.Interval = 1000;
            this.tmr_SplashScreen.Tick += new System.EventHandler(this.tmr_SplashScreen_Tick);
            // 
            // pbx_SplashScreenGraphic
            // 
            this.pbx_SplashScreenGraphic.Image = global::The_Battles_Of_Middle_Earth.Properties.Resources.LOTR_Battle1;
            this.pbx_SplashScreenGraphic.Location = new System.Drawing.Point(34, 131);
            this.pbx_SplashScreenGraphic.Name = "pbx_SplashScreenGraphic";
            this.pbx_SplashScreenGraphic.Size = new System.Drawing.Size(625, 305);
            this.pbx_SplashScreenGraphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_SplashScreenGraphic.TabIndex = 1;
            this.pbx_SplashScreenGraphic.TabStop = false;
            // 
            // frm_SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(692, 544);
            this.Controls.Add(this.lbl_Version);
            this.Controls.Add(this.pbx_SplashScreenGraphic);
            this.Controls.Add(this.lbl_SplashScreenTitle);
            this.Name = "frm_SplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash Screen";
            ((System.ComponentModel.ISupportInitialize)(this.pbx_SplashScreenGraphic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_SplashScreenTitle;
        private System.Windows.Forms.PictureBox pbx_SplashScreenGraphic;
        private System.Windows.Forms.Label lbl_Version;
        private System.Windows.Forms.Timer tmr_SplashScreen;
    }
}

