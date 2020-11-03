using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC
{
    public partial class frmMC : Form
    {
        public frmMC()
        {
            InitializeComponent();

            questionsUC.BringToFront();
            lblTitle.Text = "Câu Hỏi";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboardUC.BringToFront();
            lblTitle.Text = "Dashboard";
        }
        private void btnQuestion_Click(object sender, EventArgs e)
        {
            questionsUC.BringToFront();
            lblTitle.Text = "Câu Hỏi";
        }

        private void btnAbout_us_Click(object sender, EventArgs e)
        {
            aboutusUC1.BringToFront();
            lblTitle.Text = "Thông Tin";
        }
    }
}
