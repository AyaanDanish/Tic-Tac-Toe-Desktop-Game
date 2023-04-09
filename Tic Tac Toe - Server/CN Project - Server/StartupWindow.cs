using System;
using System.Windows.Forms;

namespace CN_Project_Server
{
    public partial class StartupWindow : Form
    {
        public int numRounds { get; set; }
        public string playerSymbol { get; set; }

        public bool selected = false;
        public StartupWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (RoundsTextBox.Text == string.Empty)
                return;

            if (!XRadioButton.Checked && !ORadioButton.Checked)
                return;

            numRounds = Convert.ToInt32(RoundsTextBox.Text);

            if (numRounds % 2 == 0)
            {
                MessageBox.Show("Please enter an odd number of rounds only!");
                return;
            }

            if (XRadioButton.Checked)
                playerSymbol = "X";

            else if (ORadioButton.Checked)
                playerSymbol = "O";

            selected = true;
            DialogResult = DialogResult.OK;
            this.Close();
            
        }

        private void StartupWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (selected)
                return;
            
            const string message = "You haven't finished setting up! If you exit, the game will close. Are you sure you want to exit?";
            const string caption = "Setup Incomplete";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                playerSymbol = "";
            }

        }
    }
}
