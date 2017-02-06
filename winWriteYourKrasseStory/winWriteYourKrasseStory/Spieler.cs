using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winWriteYourKrasseStory
{
    public class Spieler
    {
        public string Name { get; set; }
        bool amZug { get; set; }
        List<string> lstZeilen { get; set; }
        public TCPClient client {get; set; }

        public Spieler(string Name,Object client)
        {
            this.Name = Name;
            this.lstZeilen = new List<string>();
            this.amZug = false;
            this.client = (TCPClient)client;
        }
    }
}
