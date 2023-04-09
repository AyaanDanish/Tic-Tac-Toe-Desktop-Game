using System.Collections.Generic;
using System.Windows.Forms;

namespace CN_Project_Server
{
    public partial class ScoreboardWindow : Form
    {
        public ScoreboardWindow(List<string> scores)
        {
            InitializeComponent();
            foreach (string score in scores)
            {
                ScoreList.Items.Add(score);
            }
        }

    }
}
