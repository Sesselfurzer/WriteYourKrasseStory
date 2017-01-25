using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    class TCPServer
    {
        #region Felder
        Socket ServerSocket;
        byte[] buffer = new byte[1024];
        List<ConnectionToClient> lstSocket;
        public delegate void AddClientToListDelegate(string client);
        public delegate void DeleteClientFromListDelegate(string client);
        #endregion
        private void StartServer()
        {
            this.ServerSocket.Bind(new IPEndPoint(IPAddress.Any, 25588));
            this.ServerSocket.Listen(1);
            this.ServerSocket.BeginAccept(new AsyncCallback(OnAcceptCallback), null);
        }
        public TCPServer() { 

        }
        private void OnAcceptCallback(IAsyncResult ar)
        {
            Socket socket = null;
            try
            {
                socket = this.ServerSocket.EndAccept(ar);
                lstSocket.Add(new ConnectionToClient(socket));
                listBox1.BeginInvoke(new AddClientToListDelegate(AddClientToListMethod), socket.RemoteEndPoint.ToString());
                //listBox1.Items.Add(socket.RemoteEndPoint);
                //MessageBox.Show(socket.RemoteEndPoint.ToString());
                socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), socket);
                this.ServerSocket.BeginAccept(new AsyncCallback(OnAcceptCallback), null);
            }
            catch (Exception ex)
            {

            }
        }

        private void OnReceiveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            if (socket.Connected == true)
            {
                int received;
                try
                {
                    received = socket.EndReceive(ar);
                }
                catch (Exception ex)
                {
                    //Methode "OnReceiveCallback" wird aufgerufen, sobald ein Client sich schließt
                    //und kommt dann in den Catch verweis
                    for (int i = 0; i < lstSocket.Count; i++)
                    {
                        if (lstSocket[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            lstSocket.RemoveAt(i);
                            listBox1.BeginInvoke(new DeleteClientFromListDelegate(DeleteClientFromListMethod), socket.RemoteEndPoint.ToString());
                        }
                    }
                    return;
                }
                if (received != 0)
                {
                    byte[] data = new byte[received];
                    Array.Copy(this.buffer, data, received);
                    string text = Encoding.ASCII.GetString(data);
                }
                else
                {
                    for (int i = 0; i < lstSocket.Count; i++)
                    {
                        if (lstSocket[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                        {
                            lstSocket.RemoveAt(i);
                            listBox1.BeginInvoke(new DeleteClientFromListDelegate(DeleteClientFromListMethod), socket.RemoteEndPoint.ToString());
                        }
                    }
                }
            }
            else
            {

            }
            socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(OnReceiveCallback), socket);
        }

        private void SendData(Socket socket, string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(OnSendCallback), socket);
            //socket.BeginAccept(new AsyncCallback(OnAcceptCallback), null);
        }

        private void OnSendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }

    }
}
