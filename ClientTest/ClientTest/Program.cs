using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    class Program
    {
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr ConsoleWindow, int Hide_Show);

        private const int ShowConsole = 5;
        private const int HideConsole = 0;

        private static Socket ClientSocket;
        private static byte[] buffer;
        private static System.Timers.Timer timer;

        private static string IP = string.Empty;

        static void Main(string[] args)
        {
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.FileName = System.Windows.Forms.Application.ExecutablePath;
            //info.CreateNoWindow = false;
            //Process.Start(info);
            //Process.GetCurrentProcess().Kill();
            IPHostEntry host = Dns.GetHostEntry(IPAddress.Parse("93.216.115.74"));
            IP = host.AddressList[0].ToString();
            //IntPtr ConsoleWindow = FindWindow(null, Console.Title);
            //ShowWindow(ConsoleWindow, HideConsole);
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            buffer = new byte[1024];
            Connect(IP);
            //timer = new System.Timers.Timer();
            //timer.Elapsed += timer_Elapsed;
            //timer.Interval = 1800000;
            //timer.Interval = 20000;
            //timer.Enabled = true;          
            Console.ReadKey();
        }

        private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(ClientSocket.Connected == false)
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = System.Windows.Forms.Application.ExecutablePath;
                Process.Start(info);
                Process.GetCurrentProcess().Kill();
            }
        }

        private static void Connect(string IP)
        {
            try
            {
                LoopConnect(IP);
                ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), ClientSocket);
            }
            catch (Exception ex)
            {

            }
        }

        private static void LoopConnect(string IP)
        {
            int attempts = 0;
            while(ClientSocket.Connected == false)
            {
                try
                {
                    attempts++;
                    //ClientSocket.Connect(IPAddress.Parse("93.216.115.74"), 22233);
                    //ClientSocket.Connect(new IPEndPoint(IPAddress.Parse("93.216.115.74"), 22233));
                    //ClientSocket.BeginConnect(IPAddress.Parse(IP), 25588, new AsyncCallback(OnConnectCallback), ClientSocket);
                    ClientSocket.BeginConnect(IPAddress.Parse(IP), 44455, new AsyncCallback(OnConnectCallback), ClientSocket);
                }
                catch (Exception ex)
                {

                }
            }
            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes("PC NAME");
            ClientSocket.Send(data);
            //Connected
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
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int received = socket.EndReceive(ar);
                byte[] data = new byte[received];
                Array.Copy(buffer, data, received);
                string text = Encoding.ASCII.GetString(data);
                if(text == "close")
                {
                    Process.GetCurrentProcess().Kill();
                }
                else if(text == "test")
                {
                    Console.WriteLine("Test");
                }
                else
                {
                    Console.WriteLine(text);
                }
                ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), ClientSocket);
            }
            catch (Exception ex)
            {

            }
        }   
    }
}
