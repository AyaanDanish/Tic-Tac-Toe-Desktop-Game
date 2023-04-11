namespace CN_Project_Client
{
    partial class ScoreboardWindow
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
            this.ScoreList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ScoreList
            // 
            this.ScoreList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ScoreList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreList.ForeColor = System.Drawing.Color.White;
            this.ScoreList.FormattingEnabled = true;
            this.ScoreList.ItemHeight = 20;
            this.ScoreList.Location = new System.Drawing.Point(12, 12);
            this.ScoreList.Name = "ScoreList";
            this.ScoreList.Size = new System.Drawing.Size(472, 384);
            this.ScoreList.TabIndex = 1;
            // 
            // ScoreboardWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(496, 418);
            this.Controls.Add(this.ScoreList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ScoreboardWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScoreboardWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ScoreList;
    }
}