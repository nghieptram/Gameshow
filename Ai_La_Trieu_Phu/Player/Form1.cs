using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class frmPlayer : Form
    {
        public frmPlayer()
        {
            InitializeComponent();

            question1.BringToFront();
            lbTitle.Text = "Câu Hỏi";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            guides1.BringToFront();
            lbTitle.Text = "Hướng Dẫn";
        }

        private void btnQuestions_Click(object sender, EventArgs e)
        {
            question1.BringToFront();
            lbTitle.Text = "Câu Hỏi";
        }
    }
}
