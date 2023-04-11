namespace CN_Project_Client
{
    partial class StartupWindow
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
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.RoundsLabel = new System.Windows.Forms.Label();
            this.RoundsTextBox = new System.Windows.Forms.TextBox();
            this.SymbolLabel = new System.Windows.Forms.Label();
            this.SymbolTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.ConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmButton.ForeColor = System.Drawing.Color.White;
            this.ConfirmButton.Location = new System.Drawing.Point(49, 215);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(182, 39);
            this.ConfirmButton.TabIndex = 26;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = false;
            // 
            // RoundsLabel
            // 
            this.RoundsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoundsLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RoundsLabel.Location = new System.Drawing.Point(23, 98);
            this.RoundsLabel.Name = "RoundsLabel";
            this.RoundsLabel.Size = new System.Drawing.Size(242, 42);
            this.RoundsLabel.TabIndex = 25;
            this.RoundsLabel.Text = "Enter number of rounds in tournament:";
            this.RoundsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoundsTextBox
            // 
            this.RoundsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.RoundsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoundsTextBox.ForeColor = System.Drawing.Color.White;
            this.RoundsTextBox.Location = new System.Drawing.Point(27, 153);
            this.RoundsTextBox.Name = "RoundsTextBox";
            this.RoundsTextBox.Size = new System.Drawing.Size(226, 26);
            this.RoundsTextBox.TabIndex = 24;
            this.RoundsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SymbolLabel
            // 
            this.SymbolLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SymbolLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SymbolLabel.Location = new System.Drawing.Point(23, 19);
            this.SymbolLabel.Name = "SymbolLabel";
            this.SymbolLabel.Size = new System.Drawing.Size(242, 28);
            this.SymbolLabel.TabIndex = 23;
            this.SymbolLabel.Text = "Enter your player symbol:";
            this.SymbolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SymbolTextBox
            // 
            this.SymbolTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.SymbolTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SymbolTextBox.ForeColor = System.Drawing.Color.White;
            this.SymbolTextBox.Location = new System.Drawing.Point(27, 50);
            this.SymbolTextBox.Name = "SymbolTextBox";
            this.SymbolTextBox.Size = new System.Drawing.Size(226, 26);
            this.SymbolTextBox.TabIndex = 22;
            this.SymbolTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StartupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(282, 291);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.RoundsLabel);
            this.Controls.Add(this.RoundsTextBox);
            this.Controls.Add(this.SymbolLabel);
            this.Controls.Add(this.SymbolTextBox);
            this.Name = "StartupWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartupWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Label RoundsLabel;
        private System.Windows.Forms.TextBox RoundsTextBox;
        private System.Windows.Forms.Label SymbolLabel;
        private System.Windows.Forms.TextBox SymbolTextBox;
    }
}