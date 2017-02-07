using System;
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
        delegate void voidStringDelegate(string spieler);
        delegate void SpieleraddDelegate(string s);
        delegate void voidVoidDelegate();
        List<Spieler> lstSpieler;
        List<string> lstItems;
        Spieler thisSpieler;
        TCPServer Server;
        TCPClient client;
        Thread ServerThread;
        public frmStory(string Hostname, string Name)
        {
            InitializeComponent();
            btnEnd.Text = "Start";
            lstSpieler = new List<Spieler>();
            lstItems = new List<string>();
            tbZeile.Enabled = false;
            client = new TCPClient(Hostname);
            client.messageReceived += messageReceived;
            client.Connect();
            client.send("N:" + Name);
            thisSpieler = new Spieler(Name);
            btnEnd.Enabled = false;
        }
        public frmStory(string Name, int maxlength)
        {
            //basis Konstruktor
            InitializeComponent();
            btnEnd.Text = "Start";
            lstSpieler = new List<Spieler>();
            lstItems = new List<string>();
            tbZeile.Enabled = false;

            //basis Konstruktor Ende
            Server = new TCPServer();
            Server.newClientConnected += Server_newClientConnected;
            Server.messageReceived += ServermessageReceived;
#warning nutzloser thread
            ServerThread = new Thread(Server.StartServer);
            ServerThread.Start();
            client = new TCPClient("::1");
            client.messageReceived += messageReceived;
            client.Connect();
            client.send("N:" + Name);
            tbZeile.MaxLength = maxlength;
            thisSpieler = new Spieler(Name);
        }
        private void ServermessageReceived(string message)
        {
            switch (message.Substring(0, 2))
            {
                case "P:":
                    for (int i = 0; i < lstSpieler.Count; i++)
                    {
                        if (lstSpieler[i].Name == message.Substring(2) && lstSpieler.Count - 1 == i)
                        {
                            Server.SendData(lstSpieler[0].client, "Dr");
                        }
                        else if (lstSpieler[i].Name == message.Substring(2))
                        {
                            Server.SendData(lstSpieler[i + 1].client, "Dr");
                        }
                    }
                    break;
                case "Z:":
                    foreach (Spieler s in lstSpieler)
                    {
                        Server.SendData(s.client, message);
                    }
                    break;
                case "N:":
                    lstSpieler[lstSpieler.Count - 1].Name = message.Substring(2, message.Length - 2);
                    string players = "";
                    foreach (Spieler p in lstSpieler)
                    {
                        players += "P:" + p.Name;
                    }
                    foreach (Spieler s in lstSpieler)
                    {
                        Server.SendData(s.client, players);
                    }
                    break;
            }
        }
        private void Server_newClientConnected(ConnectionToClient client)
        {
            lstSpieler.Add(new Spieler("", client));
        }
        private void messageReceived(string str)
        {
            switch (str.Substring(0, 2))
            {
                case "P:":
                    string spielerListe = str.Substring(2);
                    spielerListeAktualisieren(spielerListe);
                    break;
                case "Z:":
                    zeileZuListeHinzufuegen(str.Substring(2, str.Length - 2));
                    break;
                case "EN":
                    aufloesen();
                    break;
                case "Dr":
                    rundeVorbereiten();
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
                zeileSenden(tbZeile.Text);
                tbZeile.Text = "";
                tbZeile.Enabled = false;
            }

        }
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (btnEnd.Text == "Start")
            {
                this.tbZeile.Enabled = true;
                btnEnd.Text = "Beenden";
            }
            else
            {
                lbZeilen.Items.Clear();
                if (this.Server != null)
                {
                    foreach (Spieler s in lstSpieler)
                    {
                        if (s.client != null)
                        {
                            Server.SendData(s.client, "EN");
                        }
                    }
                }
                foreach (string s in lstItems)
                {
                    lbZeilen.Items.Add(s);
                }
            }
        }
        private void frmStory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void spielerListeAktualisieren(string liste)
        {
            if (InvokeRequired)
            {
                voidStringDelegate temp = spielerListeAktualisieren;
                Object[] args = { liste };
                Invoke(temp,args);
            }
            else
            {
                lvSpieler.Items.Clear();
                string[] spielerNamen = liste.Split(':');
                for (int i = 0; i < spielerNamen.Length-1; i++) //Letztzeichen löchen(ist ein P)
                {
                    spielerNamen[i] = spielerNamen[i].Substring(0, spielerNamen[i].Length - 1);
                }
                foreach (string spieler in spielerNamen)
                {
                    lvSpieler.Items.Add(spieler);
                }
            }
        }
        public void zeileSenden(string Zeile)
        {
            client.send("P:" + thisSpieler.Name);
            client.send("Z:" + Zeile);
        }
        public void zeileZuListeHinzufuegen(string Zeile)
        {
            if (InvokeRequired)
            {
                voidStringDelegate temp = zeileZuListeHinzufuegen;
                Object[] tempargs = { Zeile };
                Invoke(temp, tempargs);
            }
            else
            {
                lstItems.Add(Zeile);
                lbZeilen.Items.Add(Zeile);
            }
        }
        public void rundeVorbereiten()
        {
            if (InvokeRequired)
            {
                voidVoidDelegate temp = rundeVorbereiten;
                Invoke(temp);
            }
            else
            {
                tbZeile.Enabled = true;
            }
        }
        private void aufloesen()
        {
            if (InvokeRequired)
            {
                voidVoidDelegate temp = aufloesen;
                Invoke(temp);
            }
            else
            {
                lbZeilen.Items.Clear();
                foreach (string s in lstItems) { lbZeilen.Items.Add(s); }
            }
        }
    }
}
