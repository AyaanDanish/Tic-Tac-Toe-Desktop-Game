namespace CN_Project
{
    partial class MatchWonWindow
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
            this.ResultLabel = new System.Windows.Forms.Label();
            this.PlayAgainBtn = new System.Windows.Forms.Button();
            this.ScoreboardBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResultLabel
            // 
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResultLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ResultLabel.Location = new System.Drawing.Point(12, 9);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(591, 173);
            this.ResultLabel.TabIndex = 21;
            this.ResultLabel.Text = "You Won/Lost the Match!";
            this.ResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayAgainBtn
            // 
            this.PlayAgainBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.PlayAgainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayAgainBtn.ForeColor = System.Drawing.Color.White;
            this.PlayAgainBtn.Location = new System.Drawing.Point(142, 170);
            this.PlayAgainBtn.Name = "PlayAgainBtn";
            this.PlayAgainBtn.Size = new System.Drawing.Size(132, 60);
            this.PlayAgainBtn.TabIndex = 24;
            this.PlayAgainBtn.Text = "Play Again";
            this.PlayAgainBtn.UseVisualStyleBackColor = false;
            this.PlayAgainBtn.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ScoreboardBtn
            // 
            this.ScoreboardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.ScoreboardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreboardBtn.ForeColor = System.Drawing.Color.White;
            this.ScoreboardBtn.Location = new System.Drawing.Point(334, 170);
            this.ScoreboardBtn.Name = "ScoreboardBtn";
            this.ScoreboardBtn.Size = new System.Drawing.Size(132, 127);
            this.ScoreboardBtn.TabIndex = 25;
            this.ScoreboardBtn.Text = "View Scoreboard";
            this.ScoreboardBtn.UseVisualStyleBackColor = false;
            this.ScoreboardBtn.Click += new System.EventHandler(this.ScoreboardBtn_Click);
            // 
            // QuitBtn
            // 
            this.QuitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.QuitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitBtn.ForeColor = System.Drawing.Color.White;
            this.QuitBtn.Location = new System.Drawing.Point(142, 237);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(132, 60);
            this.QuitBtn.TabIndex = 26;
            this.QuitBtn.Text = "Quit";
            this.QuitBtn.UseVisualStyleBackColor = false;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // MatchWonWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(615, 353);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.ScoreboardBtn);
            this.Controls.Add(this.PlayAgainBtn);
            this.Controls.Add(this.ResultLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "MatchWonWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Match Results";
            this.Shown += new System.EventHandler(this.MatchWonWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button PlayAgainBtn;
        private System.Windows.Forms.Button ScoreboardBtn;
        private System.Windows.Forms.Button QuitBtn;
    }
}