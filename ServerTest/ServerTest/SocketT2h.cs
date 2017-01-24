using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest
{
    public class SocketT2h
    {
        public Socket _Socket { get; set; }

        public SocketT2h(Socket socket)
        {
            this._Socket = socket;
        }
    }
}
