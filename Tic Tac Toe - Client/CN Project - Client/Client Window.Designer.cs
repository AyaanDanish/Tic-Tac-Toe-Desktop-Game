namespace CN_Project_Client
{
    partial class ClientWindow
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
            this.SendBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.ConnectionStatusLabel = new System.Windows.Forms.Label();
            this.IPTextBox = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.TitleLabel2 = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.OwnerLabel = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Button1_2 = new System.Windows.Forms.RadioButton();
            this.Button1_1 = new System.Windows.Forms.RadioButton();
            this.Button1_0 = new System.Windows.Forms.RadioButton();
            this.Button0_0 = new System.Windows.Forms.RadioButton();
            this.Button2_0 = new System.Windows.Forms.RadioButton();
            this.Button2_1 = new System.Windows.Forms.RadioButton();
            this.Button2_2 = new System.Windows.Forms.RadioButton();
            this.Button0_2 = new System.Windows.Forms.RadioButton();
            this.Button0_1 = new System.Windows.Forms.RadioButton();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.TurnLabel = new System.Windows.Forms.Label();
            this.RoundLabel = new System.Windows.Forms.Label();
            this.ScoreboardBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendBtn
            // 
            this.SendBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.SendBtn.Enabled = false;
            this.SendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendBtn.ForeColor = System.Drawing.Color.White;
            this.SendBtn.Location = new System.Drawing.Point(784, 394);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(103, 94);
            this.SendBtn.TabIndex = 19;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = false;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.ConnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.ForeColor = System.Drawing.Color.White;
            this.ConnectBtn.Location = new System.Drawing.Point(272, 37);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(182, 39);
            this.ConnectBtn.TabIndex = 14;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = false;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.BackColor = System.Drawing.Color.Red;
            this.ConnectionStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConnectionStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionStatusLabel.Location = new System.Drawing.Point(11, 90);
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(229, 28);
            this.ConnectionStatusLabel.TabIndex = 13;
            this.ConnectionStatusLabel.Text = "Not Connected";
            this.ConnectionStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IPTextBox
            // 
            this.IPTextBox.AcceptsReturn = true;
            this.IPTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.IPTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPTextBox.ForeColor = System.Drawing.Color.White;
            this.IPTextBox.Location = new System.Drawing.Point(14, 45);
            this.IPTextBox.Name = "IPTextBox";
            this.IPTextBox.Size = new System.Drawing.Size(226, 26);
            this.IPTextBox.TabIndex = 12;
            this.IPTextBox.Text = "127.0.0.1:1234";
            this.IPTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.IPTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IPTextBox_KeyPress);
            // 
            // IPLabel
            // 
            this.IPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.ForeColor = System.Drawing.Color.White;
            this.IPLabel.Location = new System.Drawing.Point(10, 14);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(242, 28);
            this.IPLabel.TabIndex = 11;
            this.IPLabel.Text = "Enter IP and Port to Connect to:";
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.DisconnectBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisconnectBtn.ForeColor = System.Drawing.Color.White;
            this.DisconnectBtn.Location = new System.Drawing.Point(272, 85);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(182, 39);
            this.DisconnectBtn.TabIndex = 21;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = false;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // TitleLabel2
            // 
            this.TitleLabel2.AutoSize = true;
            this.TitleLabel2.Font = new System.Drawing.Font("Magneto", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel2.ForeColor = System.Drawing.Color.White;
            this.TitleLabel2.Location = new System.Drawing.Point(530, 21);
            this.TitleLabel2.Name = "TitleLabel2";
            this.TitleLabel2.Size = new System.Drawing.Size(332, 58);
            this.TitleLabel2.TabIndex = 26;
            this.TitleLabel2.Text = "Tic Tac Toe";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Magneto", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.ForeColor = System.Drawing.Color.White;
            this.TitleLabel.Location = new System.Drawing.Point(611, 79);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(169, 32);
            this.TitleLabel.TabIndex = 25;
            this.TitleLabel.Text = "Using TCP";
            // 
            // OwnerLabel
            // 
            this.OwnerLabel.AutoSize = true;
            this.OwnerLabel.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OwnerLabel.ForeColor = System.Drawing.Color.White;
            this.OwnerLabel.Location = new System.Drawing.Point(656, 120);
            this.OwnerLabel.Name = "OwnerLabel";
            this.OwnerLabel.Size = new System.Drawing.Size(202, 23);
            this.OwnerLabel.TabIndex = 27;
            this.OwnerLabel.Text = "Property of Ayaan and Ayihan ";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 807);
            this.splitter1.TabIndex = 28;
            this.splitter1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.Button1_2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Button1_1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Button1_0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Button0_0, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Button2_0, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Button2_1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Button2_2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Button0_2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Button0_1, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(32, 170);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(746, 555);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // Button1_2
            // 
            this.Button1_2.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button1_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button1_2.Enabled = false;
            this.Button1_2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button1_2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1_2.ForeColor = System.Drawing.Color.White;
            this.Button1_2.Location = new System.Drawing.Point(499, 188);
            this.Button1_2.Name = "Button1_2";
            this.Button1_2.Size = new System.Drawing.Size(241, 179);
            this.Button1_2.TabIndex = 37;
            this.Button1_2.TabStop = true;
            this.Button1_2.Tag = "false";
            this.Button1_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button1_2.UseVisualStyleBackColor = false;
            this.Button1_2.CheckedChanged += new System.EventHandler(this.Button1_2_Click);
            this.Button1_2.MouseEnter += new System.EventHandler(this.Button1_2_MouseEnter);
            this.Button1_2.MouseLeave += new System.EventHandler(this.Button1_2_MouseLeave);
            // 
            // Button1_1
            // 
            this.Button1_1.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button1_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button1_1.Enabled = false;
            this.Button1_1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button1_1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1_1.ForeColor = System.Drawing.Color.White;
            this.Button1_1.Location = new System.Drawing.Point(251, 188);
            this.Button1_1.Name = "Button1_1";
            this.Button1_1.Size = new System.Drawing.Size(239, 179);
            this.Button1_1.TabIndex = 36;
            this.Button1_1.TabStop = true;
            this.Button1_1.Tag = "false";
            this.Button1_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button1_1.UseVisualStyleBackColor = false;
            this.Button1_1.CheckedChanged += new System.EventHandler(this.Button1_1_Click);
            this.Button1_1.MouseEnter += new System.EventHandler(this.Button1_1_MouseEnter);
            this.Button1_1.MouseLeave += new System.EventHandler(this.Button1_1_MouseLeave);
            // 
            // Button1_0
            // 
            this.Button1_0.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button1_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_0.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button1_0.Enabled = false;
            this.Button1_0.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button1_0.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button1_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1_0.ForeColor = System.Drawing.Color.White;
            this.Button1_0.Location = new System.Drawing.Point(3, 188);
            this.Button1_0.Name = "Button1_0";
            this.Button1_0.Size = new System.Drawing.Size(239, 179);
            this.Button1_0.TabIndex = 35;
            this.Button1_0.TabStop = true;
            this.Button1_0.Tag = "false";
            this.Button1_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button1_0.UseVisualStyleBackColor = false;
            this.Button1_0.CheckedChanged += new System.EventHandler(this.Button1_0_Click);
            this.Button1_0.MouseEnter += new System.EventHandler(this.Button1_0_MouseEnter);
            this.Button1_0.MouseLeave += new System.EventHandler(this.Button1_0_MouseLeave);
            // 
            // Button0_0
            // 
            this.Button0_0.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button0_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_0.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button0_0.Enabled = false;
            this.Button0_0.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button0_0.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button0_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button0_0.ForeColor = System.Drawing.Color.White;
            this.Button0_0.Location = new System.Drawing.Point(3, 3);
            this.Button0_0.Name = "Button0_0";
            this.Button0_0.Size = new System.Drawing.Size(239, 179);
            this.Button0_0.TabIndex = 32;
            this.Button0_0.TabStop = true;
            this.Button0_0.Tag = "false";
            this.Button0_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button0_0.UseVisualStyleBackColor = false;
            this.Button0_0.CheckedChanged += new System.EventHandler(this.Button0_0_Click);
            this.Button0_0.MouseEnter += new System.EventHandler(this.Button0_0_MouseEnter);
            this.Button0_0.MouseLeave += new System.EventHandler(this.Button0_0_MouseLeave);
            // 
            // Button2_0
            // 
            this.Button2_0.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button2_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_0.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button2_0.Enabled = false;
            this.Button2_0.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button2_0.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_0.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2_0.ForeColor = System.Drawing.Color.White;
            this.Button2_0.Location = new System.Drawing.Point(3, 373);
            this.Button2_0.Name = "Button2_0";
            this.Button2_0.Size = new System.Drawing.Size(239, 179);
            this.Button2_0.TabIndex = 34;
            this.Button2_0.TabStop = true;
            this.Button2_0.Tag = "false";
            this.Button2_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button2_0.UseVisualStyleBackColor = false;
            this.Button2_0.CheckedChanged += new System.EventHandler(this.Button2_0_Click);
            this.Button2_0.MouseEnter += new System.EventHandler(this.Button2_0_MouseEnter);
            this.Button2_0.MouseLeave += new System.EventHandler(this.Button2_0_MouseLeave);
            // 
            // Button2_1
            // 
            this.Button2_1.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button2_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button2_1.Enabled = false;
            this.Button2_1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button2_1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2_1.ForeColor = System.Drawing.Color.White;
            this.Button2_1.Location = new System.Drawing.Point(251, 373);
            this.Button2_1.Name = "Button2_1";
            this.Button2_1.Size = new System.Drawing.Size(239, 179);
            this.Button2_1.TabIndex = 33;
            this.Button2_1.TabStop = true;
            this.Button2_1.Tag = "false";
            this.Button2_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button2_1.UseVisualStyleBackColor = false;
            this.Button2_1.CheckedChanged += new System.EventHandler(this.Button2_1_Click);
            this.Button2_1.MouseEnter += new System.EventHandler(this.Button2_1_MouseEnter);
            this.Button2_1.MouseLeave += new System.EventHandler(this.Button2_1_MouseLeave);
            // 
            // Button2_2
            // 
            this.Button2_2.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button2_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button2_2.Enabled = false;
            this.Button2_2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button2_2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button2_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2_2.ForeColor = System.Drawing.Color.White;
            this.Button2_2.Location = new System.Drawing.Point(499, 373);
            this.Button2_2.Name = "Button2_2";
            this.Button2_2.Size = new System.Drawing.Size(239, 179);
            this.Button2_2.TabIndex = 32;
            this.Button2_2.TabStop = true;
            this.Button2_2.Tag = "false";
            this.Button2_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button2_2.UseVisualStyleBackColor = false;
            this.Button2_2.CheckedChanged += new System.EventHandler(this.Button2_2_Click);
            this.Button2_2.MouseEnter += new System.EventHandler(this.Button2_2_MouseEnter);
            this.Button2_2.MouseLeave += new System.EventHandler(this.Button2_2_MouseLeave);
            // 
            // Button0_2
            // 
            this.Button0_2.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button0_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button0_2.Enabled = false;
            this.Button0_2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button0_2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button0_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button0_2.ForeColor = System.Drawing.Color.White;
            this.Button0_2.Location = new System.Drawing.Point(499, 3);
            this.Button0_2.Name = "Button0_2";
            this.Button0_2.Size = new System.Drawing.Size(241, 179);
            this.Button0_2.TabIndex = 31;
            this.Button0_2.TabStop = true;
            this.Button0_2.Tag = "false";
            this.Button0_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button0_2.UseVisualStyleBackColor = false;
            this.Button0_2.CheckedChanged += new System.EventHandler(this.Button0_2_Click);
            this.Button0_2.MouseEnter += new System.EventHandler(this.Button0_2_MouseEnter);
            this.Button0_2.MouseLeave += new System.EventHandler(this.Button0_2_MouseLeave);
            // 
            // Button0_1
            // 
            this.Button0_1.Appearance = System.Windows.Forms.Appearance.Button;
            this.Button0_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button0_1.Enabled = false;
            this.Button0_1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Button0_1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.Button0_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button0_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button0_1.ForeColor = System.Drawing.Color.White;
            this.Button0_1.Location = new System.Drawing.Point(251, 3);
            this.Button0_1.Name = "Button0_1";
            this.Button0_1.Size = new System.Drawing.Size(239, 179);
            this.Button0_1.TabIndex = 32;
            this.Button0_1.TabStop = true;
            this.Button0_1.Tag = "false";
            this.Button0_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Button0_1.UseVisualStyleBackColor = false;
            this.Button0_1.CheckedChanged += new System.EventHandler(this.Button0_1_Click);
            this.Button0_1.MouseEnter += new System.EventHandler(this.Button0_1_MouseEnter);
            this.Button0_1.MouseLeave += new System.EventHandler(this.Button0_1_MouseLeave);
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedLabel.ForeColor = System.Drawing.Color.White;
            this.selectedLabel.Location = new System.Drawing.Point(818, 242);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(0, 24);
            this.selectedLabel.TabIndex = 30;
            // 
            // TurnLabel
            // 
            this.TurnLabel.AutoSize = true;
            this.TurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TurnLabel.ForeColor = System.Drawing.Color.Crimson;
            this.TurnLabel.Location = new System.Drawing.Point(28, 740);
            this.TurnLabel.Name = "TurnLabel";
            this.TurnLabel.Padding = new System.Windows.Forms.Padding(10);
            this.TurnLabel.Size = new System.Drawing.Size(303, 59);
            this.TurnLabel.TabIndex = 31;
            this.TurnLabel.Text = "Turn: Opponent\'s";
            this.TurnLabel.Visible = false;
            // 
            // RoundLabel
            // 
            this.RoundLabel.AutoSize = true;
            this.RoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoundLabel.ForeColor = System.Drawing.Color.White;
            this.RoundLabel.Location = new System.Drawing.Point(614, 740);
            this.RoundLabel.Name = "RoundLabel";
            this.RoundLabel.Padding = new System.Windows.Forms.Padding(10);
            this.RoundLabel.Size = new System.Drawing.Size(176, 59);
            this.RoundLabel.TabIndex = 36;
            this.RoundLabel.Text = "Round: 1";
            this.RoundLabel.Visible = false;
            // 
            // ScoreboardBtn
            // 
            this.ScoreboardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.ScoreboardBtn.Enabled = false;
            this.ScoreboardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreboardBtn.ForeColor = System.Drawing.Color.White;
            this.ScoreboardBtn.Location = new System.Drawing.Point(784, 631);
            this.ScoreboardBtn.Name = "ScoreboardBtn";
            this.ScoreboardBtn.Size = new System.Drawing.Size(103, 94);
            this.ScoreboardBtn.TabIndex = 37;
            this.ScoreboardBtn.Text = "View Scoreboard";
            this.ScoreboardBtn.UseVisualStyleBackColor = false;
            this.ScoreboardBtn.Click += new System.EventHandler(this.ScoreboardBtn_Click);
            // 
            // ClientWindow
            // 
            this.AcceptButton = this.SendBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(899, 807);
            this.Controls.Add(this.ScoreboardBtn);
            this.Controls.Add(this.RoundLabel);
            this.Controls.Add(this.TurnLabel);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.OwnerLabel);
            this.Controls.Add(this.TitleLabel2);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.ConnectionStatusLabel);
            this.Controls.Add(this.IPTextBox);
            this.Controls.Add(this.IPLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(915, 846);
            this.Name = "ClientWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic Tac Toe - Client";
            this.Shown += new System.EventHandler(this.ClientWindow_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label ConnectionStatusLabel;
        private System.Windows.Forms.TextBox IPTextBox;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.Label TitleLabel2;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label OwnerLabel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.RadioButton Button0_2;
        private System.Windows.Forms.RadioButton Button2_0;
        private System.Windows.Forms.RadioButton Button2_1;
        private System.Windows.Forms.RadioButton Button2_2;
        private System.Windows.Forms.RadioButton Button0_0;
        private System.Windows.Forms.RadioButton Button0_1;
        private System.Windows.Forms.RadioButton Button1_2;
        private System.Windows.Forms.RadioButton Button1_1;
        private System.Windows.Forms.RadioButton Button1_0;
        private System.Windows.Forms.Label TurnLabel;
        private System.Windows.Forms.Label RoundLabel;
        private System.Windows.Forms.Button ScoreboardBtn;
    }
}

