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
    class ClientThread
    {
        public Socket clientSocket,
            serverSocket;
        public IAsyncResult ia;
        public EndPoint IPClient;

        Thread tReceive;

        byte[] sendBuff = new byte[1024];
        byte[] receiveBuff = new byte[1024];

        int byteReceive = 0;
        string stringReceive = "";
        public ClientThread(Socket server, IAsyncResult ia)
        {
            this.serverSocket = server;
            this.ia = ia;
        }
        public void RunClientThread()
        {
            try
            {
                //lay trang thai serverSocket
                Socket e = (Socket)ia.AsyncState;
                //chap nhan ket noi, tra ve 1 socket moi va su dung de ket noi voi client
                clientSocket = serverSocket.EndAccept(ia);
                IPClient = clientSocket.RemoteEndPoint;
                string hello = "Xin chao client" + IPClient.ToString();
                SendData(Encoding.ASCII.GetBytes(hello));
                ServerProgram.SetDataFunction("Client: " + IPClient.ToString() + " da ket noi");
                tReceive = new Thread(new ThreadStart(ReceiveData));
                tReceive.Start();

                AddClient();
                UpdateClients();
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public void SendData(byte[] data)
        {
            sendBuff = data;
            try
            {
                clientSocket.BeginSend(sendBuff, 0, sendBuff.Length, SocketFlags.None, new AsyncCallback(SendToClient), clientSocket);
            }
            catch { ServerProgram.SetDataFunction("client ngat ket noi"); }
        }
        /// <summary>
        /// ham call back gui du lieu, khoi tao lai gia tri cua buff
        /// </summary>
        /// <param name="ia">gia tri tra ve cua phuong thuc BeginSend</param>
        private void SendToClient(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            s.EndSend(ia);
            string strData = Encoding.ASCII.GetString(sendBuff);
            ServerProgram.SetDataFunction("to " + IPClient.ToString() + ": " + strData);
            sendBuff = new byte[1024];
        }

        public void Close()
        {
            RemoveClient();
            UpdateClients();
            if (clientSocket != null)
            {
                clientSocket.Close();
            }
        }
        /// <summary>
        /// lap lai viec nhan du lieu tu server
        /// </summary>
        public void ReceiveData()
        {
            try
            {
                clientSocket.BeginReceive(receiveBuff, 0, receiveBuff.Length, SocketFlags.None, new AsyncCallback(ReceiveFromClient), clientSocket);
            }
            catch (Exception e) { ServerProgram.SetDataFunction(e.ToString()); }
        }
        /// <summary>
        /// ham call back nhan du lieu, in tin nhan ra man hinh va 
        /// </summary>
        /// <param name="ia">gia tri tra ve cua phuong thuc BeginReceive</param>
        private void ReceiveFromClient(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            try
            {
                byteReceive = s.EndReceive(ia);
            }
            catch
            {
                ServerProgram.SetDataFunction("client ngat ket noi");
            }
            ServerProgram.Input(receiveBuff);
            stringReceive = Encoding.ASCII.GetString(receiveBuff, 0, byteReceive);
            ServerProgram.SetDataFunction("from "+IPClient.ToString() +": "+ stringReceive);
            receiveBuff = new byte[1024];
            ReceiveData();
        }
        #region handle clients number and list clients
        private void RemoveClient()
        {
            ServerProgram.clientsNumber--;
            ServerProgram.clients.Remove(clientSocket.RemoteEndPoint.ToString());
        }
        private void AddClient()
        {
            ServerProgram.clientsNumber++;
            ServerProgram.clients.Add(clientSocket.RemoteEndPoint.ToString());
        }
        private void UpdateClients()
        {
            ServerProgram.SetClientsNumberFunction(ServerProgram.clientsNumber);
            ServerProgram.SetClientsFunction(ServerProgram.clients);
        }
        #endregion
    }
}
