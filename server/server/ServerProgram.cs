using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server
{
    public class ServerProgram
    {

        public static int clientsNumber = 0;
        public static List<string> clients = new List<string>();
        private static List<ClientThread> clientThreads = new List<ClientThread>(); //conversation

        public static Queue<byte[]> OutQ = new Queue<byte[]>();
        public static Queue<byte[]> InQ = new Queue<byte[]>();
        Thread tSend;
        private IPAddress serverIP;
        public IPAddress ServerIP
        {
            get { return serverIP; }
            set { serverIP = value; }
        }

        private int port;
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        #region delegates to set controls data
        public delegate void SetDataControl(string data);
        public static SetDataControl SetDataFunction = null;
        public delegate void SetClientsNumberControl(int clientsNumber);
        public static SetClientsNumberControl SetClientsNumberFunction = null;
        public delegate void SetClientsControl(List<string> clients);
        public static SetClientsControl SetClientsFunction = null;
        #endregion

        Socket serverSocket = null;
        IPEndPoint serverEP = null;

        public ServerProgram(IPAddress serverIp, int port)
        {
            this.ServerIP = serverIp;
            this.Port = port;
        }

        public void Listen()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverEP = new IPEndPoint(ServerIP, Port);
            serverSocket.Bind(serverEP);
            SetDataFunction("Dang cho client ket noi..."); //in ra control bang mot cach nao do, tuy ham control
            serverSocket.Listen(-1); //chap nhan nhieu client ket noi
            serverSocket.BeginAccept(new AsyncCallback(AcceptSocket), serverSocket);
        }
        private void AcceptSocket(IAsyncResult ia) //ia: gia tri tra ve cua phuong thuc BeginAccept
        {
            ClientThread clientThread = new ClientThread(serverSocket, ia);
            clientThreads.Add(clientThread);
            Thread thread = new Thread(new ThreadStart(clientThread.RunClientThread));
            thread.Start();
            tSend = new Thread(new ThreadStart(SendData));
            tSend.Start();
            try
            {
                serverSocket.BeginAccept(new AsyncCallback(AcceptSocket), serverSocket);
            }
            catch(Exception e) { SetDataFunction(e.ToString()); }
        }

        void SendData()
        {
            while (true)
            {
                if (OutQ.Count > 0)
                {
                    byte[] buff = OutQ.Dequeue();
                    SendAll(buff);
                }
            }
        }

        public void Close()
        {
            serverSocket.Close();
        }
        public void SendAll(byte[] data)
        {
            string strData = Encoding.ASCII.GetString(data);
            foreach (ClientThread clientThread in clientThreads)
            {
                clientThread.SendData(data);
            }

        }
        /// <summary>
        /// Ham nhan tin nhan dau vao tu form, dua vao hang doi de gui di
        /// </summary>
        /// <param name="data">noi dung tin nhan</param>
        public static void Input(byte[] data)
        {
            ServerProgram.OutQ.Enqueue(data);
            ServerProgram.InQ.Enqueue(data);
        }
    }
}
