using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC.UserControls
{
    public partial class AboutusUC : UserControl
    {
        public AboutusUC()
        {
            InitializeComponent();
        }
        private void lbEmail_96_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:1760096@student.hcmus.edu.vn");
        }

        private void labelEmail_100_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:1760100@student.hcmus.edu.vn");
        }

        private void labelEmail_119_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:1760119@student.hcmus.edu.vn");
        }
    }
}
