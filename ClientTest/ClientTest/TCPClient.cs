using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace ClientTest
{
    class TCPClient
    {
        public const int maximumAttempts = 5;
        public const int connectTimeOut = 1000;
        private Socket ClientSocket;
        private byte[] buffer;
        private IPAddress IP = null;

        public TCPClient(string hostname)
        {
            IPHostEntry host = null;
            try
            {
                host = Dns.GetHostEntry(IPAddress.Parse(hostname));
            }

            catch (System.ArgumentException)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
#warning das ist noch kacke der fehler muss behandelt werden
            }

            IP = host.AddressList[0];
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            buffer = new byte[1024];
            Connect();
            Console.ReadKey();
        }


        public async void Connect()
        {
            int attempts = 0;
            while (ClientSocket.Connected == false || attempts >= maximumAttempts)
            {
                attempts++;
                Task t = tryToConnect();
                t.Wait(connectTimeOut);
            }
            ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), ClientSocket);
        }
        private async Task tryToConnect()
        {
            ClientSocket.BeginConnect(IP, 44455, new AsyncCallback(OnConnectCallback), ClientSocket);
        }

        private void OnConnectCallback(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
            socket.EndConnect(ar);
        }

        private void OnReceiveCallback(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
            int received = socket.EndReceive(ar);
            string text = Encoding.ASCII.GetString(buffer);
            ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), ClientSocket);
        }
    }
}
