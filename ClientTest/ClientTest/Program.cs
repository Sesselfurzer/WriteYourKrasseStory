using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
#pragma warning disable
namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPServer serv = new TCPServer();
            serv.messageReceived += Console.WriteLine;
          
            //serv.StartServer();
            Thread td = new Thread(serv.StartServer);
            td.Start();
            TCPClient client = new TCPClient("127.0.0.1");
            client.Connect();
           
            client.send("Hallo Welt");
            Console.ReadLine();
        }
        
    }
}
