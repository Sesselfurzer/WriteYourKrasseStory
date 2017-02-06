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
    public partial class frmStory : Form
    {

        List<Spieler> lstSpieler;
        List<string> lstItems;
        int Spieler = 0;
        int Voting = 0;
        TCPServer Server;
        TCPClient client;
        public frmStory(int maxlength,object isServer,string strIP,string Name)
        {
            InitializeComponent();
            lstSpieler = new List<Spieler>();
            lstItems = new List<String>();
            if (isServer is TCPServer)
            {
                Server = (TCPServer)isServer;
                Server.newClientConnected += Server_newClientConnected;
                Server.messageReceived += messageReceived;
                client = new TCPClient(strIP);
                client.messageReceived += messageReceived;
            }
            else
            {
                client = (TCPClient)isServer;
                client.messageReceived += messageReceived;
            }
            lvSpieler.Items.Add(Name);
            lstSpieler.Add(new Spieler(Name,client));        
            tbZeile.MaxLength = maxlength ;
            tbZeile.Enabled = false;
        }
        private void Server_newClientConnected(ConnectionToClient client)
        {
            lstSpieler.Add(new Spieler("Player " + lstSpieler.Count + 1, client));
            foreach(Spieler s in lstSpieler)
            {
                Server.SendData(client, "P: "+s.Name);
                s.client.send("P: " + s.Name);
            }

        }

        private void messageReceived(string str)
        {
            switch (str.Substring(0, 2))
            {
                case "P:":
                    NeuerSpieler(str.Substring(2, str.Length-16),str.Substring(str.Length-15,15));

                    break;
                case "Z:":
                    if (Server != null&&lbZeilen.Items[lbZeilen.Items.Count].ToString()!= str.Substring(str.Length - 2, str.Length))
                    {
                        foreach(Spieler s in lstSpieler)
                        {
                            s.client.send(str);
                        }
                    }
                        if (str.Substring(str.Length - 2, str.Length) == "0")
                        {
                            NeueZeile(str.Substring(2, str.Length - 1), false);
                        }
                        else
                        {
                            NeueZeile(str.Substring(2, str.Length - 1), true);
                        }
                    break;
                case "V:":
                    changeVoting();
                    break;
            }
        }

        public void backgroundclear()
        {
            foreach(ListViewItem i in lvSpieler.Items)
            {
                i.BackColor = lvSpieler.BackColor;
            }
        }
        private void tbZeile_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (lbZeilen.Items.Count > 1)
                {
                   
                }
                lstItems.Add(tbZeile.Text);
                lbZeilen.Items.Clear();
                lbZeilen.Items.Add(lstItems[lstItems.Count - 1]);
                tbZeile.Text = "";
                if (Spieler < lvSpieler.Items.Count)
                {
                    backgroundclear();
                    lvSpieler.Items[Spieler].BackColor = Color.Green;
                    Spieler++;
                }
                else
                {
                    backgroundclear();
                    Spieler = 0;
                    lvSpieler.Items[0].BackColor = lvSpieler.BackColor;
                }
            }

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            changeVoting();

        }

        private void frmStory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void NeuerSpieler(string Player,string clientip)
        {
            lvSpieler.Items.Add(Player);
            lstSpieler.Add(new Spieler(Player,new TCPClient(clientip)));
        }
        public void NeueZeile(string Zeile,bool type)
        {
            lstItems.Add(Zeile);
            if (type)
            {
                tbZeile.Enabled = true;
                lbZeilen.Items.Add(Zeile);
            }
            else
            {
                tbZeile.Enabled = false;
            }
        }
        public void changeVoting()
        {
            Voting++;
            btnEnd.Text = "Beenden " + Voting;
            if (Voting >= lstSpieler.Count && Voting != 0)
            {
                lbZeilen.Items.Clear();
                foreach (String s in lstItems)
                {
                    lbZeilen.Items.Add(s);
                }
            }
        }
    }
}
