using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CN_Project
{
    public partial class RoundWonWindow : Form
    {
        private static string resultMessage, buttonMessage;
        private static Color windowColor;

        public RoundWonWindow(string resultMsg, string buttonMsg, Color winColor)
        {
            InitializeComponent();
            resultMessage = resultMsg;
            buttonMessage = buttonMsg;
            windowColor = winColor;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RoundWonWindow_Shown(object sender, EventArgs e)
        {
            ResultLabel.Text = resultMessage;
            ConfirmButton.Text = buttonMessage;
            ResultLabel.ForeColor = windowColor;
        }
    }
}
