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
            btnConnect.Enabled = false;
        }

        private void btnStarten_Click(object sender, EventArgs e)
        {
            TCPServer Server = new TCPServer();
            Form form1 = new frmStory(100,Server,tbServerIP.Text,tbName1.Text);
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TCPClient client = new TCPClient(tbServerIP.Text);
            client.Connect();
            Form form1 = new frmStory(100, client, tbServerIP.Text, tbName1.Text);
            form1.Show();
            this.Hide();

        }

        private void tServer_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
