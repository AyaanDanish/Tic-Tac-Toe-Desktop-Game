using CN_Project_Server;
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
    public partial class MatchWonWindow : Form
    {
        private static string messageText;
        Color messageColor;
        List<string> scoreList;
        public MatchWonWindow(string msgText, List<string> score, Color msgColor)
        {
            InitializeComponent();
            messageText = msgText;
            scoreList = score;
            messageColor = msgColor;
        }

        private void ScoreboardBtn_Click(object sender, EventArgs e)
        {
            ScoreboardWindow window = new ScoreboardWindow(scoreList);
            window.ShowDialog();
        }

        private void MatchWonWindow_Shown(object sender, EventArgs e)
        {
            ResultLabel.Text = messageText;
            ResultLabel.ForeColor = messageColor;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
