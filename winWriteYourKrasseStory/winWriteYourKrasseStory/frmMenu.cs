using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winWriteYourKrasseStory
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        private void btnStarten_Click(object sender, EventArgs e)
        {
            Form form1 = new frmStory(tbNameServer.Text, Convert.ToInt32(tblength.Text));
            form1.Show();
            this.Hide();
        }
        private void btnClientStart_Click(object sender, EventArgs e)
        {
            Form form1 = new frmStory(tbServerIP.Text, tbNameClient.Text );
            form1.Show();
            this.Hide();
        }
    }
}
