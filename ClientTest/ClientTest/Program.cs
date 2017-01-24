using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable
namespace ClientTest
{
    class Program
    {
        public const int maximumAttempts = 5;
        public const int connectTimeOut = 1000;
        private static Socket ClientSocket;
        private static byte[] buffer;
        private static IPAddress IP = null;

        static void Main(string[] args)
        {
            IPHostEntry host = null;
            try
            {
                host = Dns.GetHostEntry(IPAddress.Parse("0.0.0.0"));
            }

            catch (System.ArgumentException)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
#warning das ist noch kacke der fehler muss behandelt werden
            }

            IP = host.AddressList[0];
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            buffer = new byte[1024];
            Connect(IP);
            Console.ReadKey();
        }


        private static async void Connect()
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
        private static async Task tryToConnect()
        {
            ClientSocket.BeginConnect(IP, 44455, new AsyncCallback(OnConnectCallback), ClientSocket);
        }

        private static void OnConnectCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            try
            {
                socket.EndConnect(ar);
            }
            catch (Exception ex)
            {

            }
        }

        private static void OnReceiveCallback(IAsyncResult ar)
        {

            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);
            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string text = Encoding.ASCII.GetString(data);

            ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), ClientSocket);


        }
    }
}
