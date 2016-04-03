namespace The_Battles_Of_Middle_Earth
{
    partial class frm_HighScoreScreen
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
            this.lbl_Credits = new System.Windows.Forms.Label();
            this.lst_HighscoreList = new System.Windows.Forms.ListBox();
            this.lbl_HighscoresTitle = new System.Windows.Forms.Label();
            this.btn_Replay = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.pbx_GifToShow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_GifToShow)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Credits
            // 
            this.lbl_Credits.AutoSize = true;
            this.lbl_Credits.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Credits.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Credits.Location = new System.Drawing.Point(331, 368);
            this.lbl_Credits.Name = "lbl_Credits";
            this.lbl_Credits.Size = new System.Drawing.Size(230, 22);
            this.lbl_Credits.TabIndex = 1;
            this.lbl_Credits.Text = "Created By: Aaron Cunningham";
            // 
            // lst_HighscoreList
            // 
            this.lst_HighscoreList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lst_HighscoreList.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_HighscoreList.ForeColor = System.Drawing.Color.Gold;
            this.lst_HighscoreList.FormattingEnabled = true;
            this.lst_HighscoreList.ItemHeight = 22;
            this.lst_HighscoreList.Location = new System.Drawing.Point(24, 111);
            this.lst_HighscoreList.Name = "lst_HighscoreList";
            this.lst_HighscoreList.Size = new System.Drawing.Size(266, 246);
            this.lst_HighscoreList.TabIndex = 2;
            // 
            // lbl_HighscoresTitle
            // 
            this.lbl_HighscoresTitle.AutoSize = true;
            this.lbl_HighscoresTitle.Font = new System.Drawing.Font("Lucida Handwriting", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HighscoresTitle.ForeColor = System.Drawing.Color.Gold;
            this.lbl_HighscoresTitle.Location = new System.Drawing.Point(190, 43);
            this.lbl_HighscoresTitle.Name = "lbl_HighscoresTitle";
            this.lbl_HighscoresTitle.Size = new System.Drawing.Size(198, 36);
            this.lbl_HighscoresTitle.TabIndex = 3;
            this.lbl_HighscoresTitle.Text = "High Scores:";
            // 
            // btn_Replay
            // 
            this.btn_Replay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Replay.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btn_Replay.FlatAppearance.BorderSize = 3;
            this.btn_Replay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Replay.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Replay.ForeColor = System.Drawing.Color.Gold;
            this.btn_Replay.Location = new System.Drawing.Point(24, 363);
            this.btn_Replay.Name = "btn_Replay";
            this.btn_Replay.Size = new System.Drawing.Size(110, 33);
            this.btn_Replay.TabIndex = 14;
            this.btn_Replay.Text = "Replay";
            this.btn_Replay.UseVisualStyleBackColor = false;
            this.btn_Replay.Click += new System.EventHandler(this.btn_Replay_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Exit.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btn_Exit.FlatAppearance.BorderSize = 3;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Trebuchet MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.ForeColor = System.Drawing.Color.Gold;
            this.btn_Exit.Location = new System.Drawing.Point(180, 363);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(110, 33);
            this.btn_Exit.TabIndex = 15;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // pbx_GifToShow
            // 
            this.pbx_GifToShow.Image = global::The_Battles_Of_Middle_Earth.Properties.Resources.Sauron;
            this.pbx_GifToShow.Location = new System.Drawing.Point(311, 175);
            this.pbx_GifToShow.Name = "pbx_GifToShow";
            this.pbx_GifToShow.Size = new System.Drawing.Size(250, 105);
            this.pbx_GifToShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_GifToShow.TabIndex = 16;
            this.pbx_GifToShow.TabStop = false;
            // 
            // frm_HighScoreScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(573, 418);
            this.Controls.Add(this.pbx_GifToShow);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Replay);
            this.Controls.Add(this.lbl_HighscoresTitle);
            this.Controls.Add(this.lst_HighscoreList);
            this.Controls.Add(this.lbl_Credits);
            this.Name = "frm_HighScoreScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "High Score Screen";
            this.Load += new System.EventHandler(this.frm_HighScoreScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_GifToShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Credits;
        private System.Windows.Forms.ListBox lst_HighscoreList;
        private System.Windows.Forms.Label lbl_HighscoresTitle;
        private System.Windows.Forms.Button btn_Replay;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.PictureBox pbx_GifToShow;
    }
}