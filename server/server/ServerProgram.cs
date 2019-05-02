using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class ServerProgram
    {

        private static int clientsNumber = 0;
        private static List<string> clients = new List<string>();
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
        public SetDataControl SetDataFunction = null;
        public delegate void SetClientsNumberControl(int clientsNumber);
        public SetClientsNumberControl SetClientsNumberFunction = null;
        public delegate void SetClientsControl(List<string> clients);
        public SetClientsControl SetClientsFunction = null;
        #endregion

        Socket serverSocket = null;
        IPEndPoint serverEP = null;
        Socket clientSocket = null;
        byte[] buff = new byte[1024];
        int byteReceive = 0;
        string stringReceive = "";

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
            //chap nhan nhieu client ket noi
            serverSocket.Listen(-1);
            serverSocket.BeginAccept(new AsyncCallback(AcceptSocket), serverSocket);
            SetDataFunction("Dang cho client ket noi..."); //in ra control bang mot cach nao do, tuy ham control
        }
        private void AcceptSocket(IAsyncResult ia) //ia: gia tri tra ve cua phuong thuc BeginAccept
        {
            try
            {
                //lay trang thai serverSocket
                Socket e = (Socket)ia.AsyncState;
                //chap nhan ket noi, tra ve 1 socket moi va su dung de ket noi voi client
                clientSocket = serverSocket.EndAccept(ia);
                string hello = "Hello Client";
                buff = Encoding.ASCII.GetBytes(hello);
                clientSocket.BeginSend(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(SendData), clientSocket);
                //trong khi gui loi chao thi in thong tin client ra server form
                SetDataFunction("Client: " + clientSocket.RemoteEndPoint.ToString() + " da ket noi");
                //test xuat so client
                AddClient();
                UpdateClients();
            }
            catch
            {
                SetDataFunction("Dong ket noi");
            }
        }
        private void SendData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            buff = new byte[1024];
            s.BeginReceive(buff, 0, buff.Length, SocketFlags.None, new AsyncCallback(ReceiveData), s);
        }
        public void Close()
        {
            serverSocket.Close();
            if (clientSocket != null)
            {
                clientSocket.Close();
            }           
        }
        private void ReceiveData(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            try
            {
                byteReceive = s.EndReceive(ia);
            }
            catch
            {
                //loi client ngat ket noi
                RemoveClient();
                UpdateClients();
                //thong bao ngat ket noi va cap nhat list clients
                SetDataFunction("Client: "+s.RemoteEndPoint.ToString()+" ngat ket noi");
                Close();
                Listen();
                return;
            }
            if(byteReceive == 0)
            {
                //neu client shutdown
                RemoveClient();
                UpdateClients();
                SetDataFunction("Client: " + s.RemoteEndPoint.ToString() + " dong ket noi");
                Close();
            }
            else
            {
                string stringRecieve = Encoding.ASCII.GetString(buff);
                s.BeginSend(buff,0, buff.Length, SocketFlags.None, new AsyncCallback(SendData), s);
                SetDataFunction(s.RemoteEndPoint.ToString() + ": " + stringRecieve);
            }
        }
        #region handle clients number and list clients
        private void RemoveClient()
        {
            clientsNumber--;
            clients.Remove(clientSocket.RemoteEndPoint.ToString());
        }
        private void AddClient()
        {
            clientsNumber++;
            clients.Add(clientSocket.RemoteEndPoint.ToString());
        }
        private void UpdateClients()
        {
            SetClientsNumberFunction(clientsNumber);
            SetClientsFunction(clients);
        }
        #endregion

    }
}
