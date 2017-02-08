﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace winWriteYourKrasseStory
{
    public class TCPClient
    {
        public delegate void messageReceivedHandler(string message);
        public delegate void connectionLostHandler();
        public event messageReceivedHandler messageReceived;
        public event connectionLostHandler connectionLost;
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
                host = Dns.GetHostEntry(hostname);
            }
            catch (System.ArgumentException)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }

            IP = host.AddressList[0];
            ClientSocket = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            buffer = new byte[1024];
            //   Connect();
            //         Console.ReadKey();
        }

        public void send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            ClientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnSendCallback), ClientSocket);
        }
        public async void Connect()
        {
            int attempts = 0;
            while (ClientSocket.Connected == false && attempts <= maximumAttempts)
            {
                attempts++;
                Task t = tryToConnect();
                t.Wait(connectTimeOut);
            }
            ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), ClientSocket);
        }
        private async Task tryToConnect()
        {
            try
            {
                // ClientSocket.BeginConnect(IP, OnReceiveCallback, ClientSocket);
                ClientSocket.Connect(IP, 8888);
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void OnReceiveCallback(IAsyncResult ar)
        {
            Socket socket = ar.AsyncState as Socket;
            int receivedByteCount;
            try
            {
                receivedByteCount = socket.EndReceive(ar);
            }
            catch (SocketException)
            {

                if (connectionLost != null)
                {
                    connectionLost();
                }
                return;
            } 
            byte[] data = new byte[receivedByteCount];
            Array.Copy(this.buffer, data, receivedByteCount);
            string text = Encoding.UTF8.GetString(data);
            if (messageReceived != null)
            {
                messageReceived(text);
            }
            ClientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), ClientSocket);
        }
        private void OnSendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }
    }
}
