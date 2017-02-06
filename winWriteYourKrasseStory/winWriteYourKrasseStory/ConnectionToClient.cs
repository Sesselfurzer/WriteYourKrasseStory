using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace winWriteYourKrasseStory
{
    public class ConnectionToClient
    {
       
        public Socket socket { get; set; }

        public ConnectionToClient(Socket socket)
        {
            this.socket = socket;
        }
    }
}
