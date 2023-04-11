using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CN_Project_Client
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
