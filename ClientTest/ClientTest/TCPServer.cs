using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    public delegate void newClientConnectedHandler(ConnectionToClient client);
    public delegate void messageReceivedHandler(string message);
    class TCPServer
    {
        const int port = 8888;
        public event newClientConnectedHandler newClientConnected;
        public event messageReceivedHandler messageReceived;
        #region Felder
        Socket ServerSocketv6,ServerSocketv4;
        byte[] buffer = new byte[1024];
        List<ConnectionToClient> lstSocket;
        public delegate void AddClientToListDelegate(string client);
        public delegate void DeleteClientFromListDelegate(string client);
        #endregion
        public void StartServer()
        {
            this.ServerSocketv6 = new Socket(SocketType.Stream,ProtocolType.Tcp);
            this.ServerSocketv6.Bind(new IPEndPoint(IPAddress.IPv6Any, port));
            this.ServerSocketv6.Listen(1);
            this.ServerSocketv6.BeginAccept(new AsyncCallback(OnAcceptCallbackv6), null);
#warning nicht überprüfte ipv4 unterstützung
            this.ServerSocketv4 = new Socket(SocketType.Stream, ProtocolType.Tcp);
            this.ServerSocketv4.Bind(new IPEndPoint(IPAddress.Any, port));
            this.ServerSocketv4.Listen(1);
            this.ServerSocketv4.BeginAccept(new AsyncCallback(OnAcceptCallbackv4), null);
        }
        public TCPServer()
        {
            lstSocket = new List<ConnectionToClient>();
        }
        private void OnAcceptCallbackv6(IAsyncResult ar)
        {
            Socket socket = null;
            socket = this.ServerSocketv6.EndAccept(ar);
            lstSocket.Add(new ConnectionToClient(socket));
            if (newClientConnected != null)
            {
                newClientConnected(lstSocket.Last());
            }    
            socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), socket);
            this.ServerSocketv6.BeginAccept(new AsyncCallback(OnAcceptCallbackv6), null);
        }
        private void OnAcceptCallbackv4(IAsyncResult ar)
        {
            Socket socket = null;
            socket = this.ServerSocketv4.EndAccept(ar);
            lstSocket.Add(new ConnectionToClient(socket));
            if (newClientConnected != null)
            {
                newClientConnected(lstSocket.Last());
            }
            socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), socket);
            this.ServerSocketv4.BeginAccept(new AsyncCallback(OnAcceptCallbackv4), null);
        }

        private void OnReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            // if (socket.Connected == true)
            {
                int receivedByteCount;
                try
                {
                    receivedByteCount = socket.EndReceive(ar);
                }
                catch (Exception ex)
                {
                    //Methode "OnReceiveCallback" wird aufgerufen, sobald ein Client sich schließt
                    //und kommt dann in den Catch verweis
                    for (int i = 0; i < lstSocket.Count; i++)
                    {
                        if (lstSocket[i].socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            lstSocket.RemoveAt(i);
                            //listBox1.BeginInvoke(new DeleteClientFromListDelegate(DeleteClientFromListMethod), socket.RemoteEndPoint.ToString());
                        }
                    }
                    return;
                }

                if (receivedByteCount != 0)
                {
                    byte[] data = new byte[receivedByteCount];
                    Array.Copy(this.buffer, data, receivedByteCount);
                    string text = Encoding.ASCII.GetString(data);
                    if (messageReceived != null)
                    {
                        messageReceived(text);
                        
                    }
                }
            }
        }
            //    else
            //    {
            //        for (int i = 0; i < lstSocket.Count; i++)
            //        {
            //            if (lstSocket[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
            //            {
            //                lstSocket.RemoveAt(i);
            //            }
            //        }
            //    }
            //}
            ////else
            //{

            //}
            //socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), socket);
       // }

        public void SendData(ConnectionToClient client, string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            client.socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnSendCallback), client.socket);
            //socket.BeginAccept(new AsyncCallback(OnAcceptCallback), null);
        }

        private void OnSendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }

    }
}
