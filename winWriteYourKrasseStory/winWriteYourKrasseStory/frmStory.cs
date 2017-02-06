﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace winWriteYourKrasseStory
{
    public partial class frmStory : Form
    {
        delegate void neuerSpielerDelegate(string spieler);
        List<Spieler> lstSpieler;
        List<string> lstItems;
        Spieler thisSpieler;
        TCPServer Server;
        TCPClient client;
        Thread ServerThread;
        ListView lv;
        public frmStory(string Hostname, string Name)
        {
            InitializeComponent();
            lstSpieler = new List<Spieler>();
            lstItems = new List<string>();
            lvSpieler.Items.Add(Name);
            lstSpieler.Add(new Spieler(Name));
            tbZeile.Enabled = false;
            client = new TCPClient(Hostname);
            client.messageReceived += messageReceived;
            client.send("P:" + Name);
            btnEnd.Enabled = false;
        }
        public frmStory( string Name, int maxlength)
        {
            //basis Konstruktor
            InitializeComponent();
            lstSpieler = new List<Spieler>();
            lstItems = new List<string>();
            lvSpieler.Items.Add(Name);
            lstSpieler.Add(new Spieler(Name));
            tbZeile.Enabled = false;
            //basis Konstruktor Ende
            Server = new TCPServer();
            Server.newClientConnected += Server_newClientConnected;
            Server.messageReceived += ServermessageReceived;
            ServerThread = new Thread(() => thread(lvSpieler));
            ServerThread.Start();
            tbZeile.MaxLength = maxlength;
        }
        private void ServermessageReceived(string message)
        {
            switch (message.Substring(0,2))
            {
                case "P:":
                    for(int i = 0; i < lstSpieler.Count; i++)
                    {
                        if (lstSpieler[i].Name == message.Substring(2))
                        {
                            if (lstSpieler.Count - 1 == i)
                            {
                                if (lstSpieler[0].client != null)
                                {
                                    Server.SendData(lstSpieler[0].client, "Dr");
                                }
                                else
                                {
                                    this.tbZeile.Enabled = true;
                                }
                            }
                            else
                            {
                                if (lstSpieler[i + 1].client != null)
                                {
                                    Server.SendData(lstSpieler[i + 1].client, "Dr");
                                }
                                else
                                {
                                    this.tbZeile.Enabled = true;
                                }
                            }
                        }
                    }
                    break;
                case "V:":
                    break;
                case "Z:":
                        foreach (Spieler s in lstSpieler)
                        {
                            Server.SendData(s.client, message);
                        }
                    break;

            }
        }
        public void thread(ListView lvSpieler1)
        {
            lv = lvSpieler1;
            Server.StartServer();
        }
        private void Server_newClientConnected(ConnectionToClient client)
        {
            lstSpieler.Add(new Spieler("Player " + lstSpieler.Count + 1, client));
            Server.SendData(client, "Y: " + "Player " + lstSpieler.Count);
            foreach (Spieler s in lstSpieler)
            {
                Server.SendData(client, "P: " + s.Name);
            }

        }
        private void messageReceived(string str)
        {
            switch (str.Substring(0, 2))
            {
                case "P:":
                    NeuerSpieler(str.Substring(2, str.Length - 2));
                    break;
                case "Z:":
                        NeueZeile(str.Substring(2, str.Length - 2));
                    break;
                //case "V:":
                //    changeVoting();
                //    break;
                case "Y:":
                    thisSpieler = new Spieler(str.Substring(3, str.Length - 2));
                    break;
                case "EN":
                    lbZeilen.Items.Clear();
                    foreach (string s in lstItems)
                    {
                        lbZeilen.Items.Add(s);
                    }
                    break;
                case"Dr":
                    tbZeile.Enabled = true;
                    break;
            }
        }
        public void backgroundclear()
        {
            foreach (ListViewItem i in lvSpieler.Items)
            {
                i.BackColor = lvSpieler.BackColor;
            }
        }
        private void tbZeile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NeueZeile(tbZeile.Text);
                tbZeile.Text = "";
            }

        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            lbZeilen.Items.Clear();
            foreach (string s in lstItems)
            {
                lbZeilen.Items.Add(s);
            }
            foreach(Spieler s in lstSpieler)
            {
                if(s.client != null)
                {
                    Server.SendData(s.client, "EN");
                }
            }

        }
        private void frmStory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void NeuerSpieler(string Player)
        {
            if (InvokeRequired)
            {
                neuerSpielerDelegate temp = NeuerSpieler;
                object[] tempArgs = { Player };
                Invoke(temp, tempArgs);
            }
            else
            {
                lv.Items.Add(Player);
            }
            lstSpieler.Add(new Spieler(Player));
        }
        public void NeueZeile(string Zeile)
        {
            lstItems.Add(Zeile);
            lbZeilen.Items.Add(Zeile);
            if (client != null)
            {
                client.send("P:" + thisSpieler.Name);
            }
            else
            {
                ServermessageReceived("P:" + thisSpieler);
            }
        }
        //public void changeVoting()
        //{
        //    Voting++;
        //    btnEnd.Text = "Beenden " + Voting;
        //    if (Voting >= lstSpieler.Count && Voting != 0)
        //    {
        //        lbZeilen.Items.Clear();
        //        foreach (String s in lstItems)
        //        {
        //            lbZeilen.Items.Add(s);
        //        }
        //    }
        //}
    }
}