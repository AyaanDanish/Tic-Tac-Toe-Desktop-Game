using System;
using System.Windows.Forms;

namespace CN_Project_Client
{
    public partial class StartupWindow : Form
    {

        public int numRounds { get; set; }
        public string playerSymbol { get; set; }

        public StartupWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.numRounds = Convert.ToInt32(RoundsTextBox.Text);
            this.playerSymbol = SymbolTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        
    }
}
