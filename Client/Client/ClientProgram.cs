using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class ClientProgram
    {
        //delegate để set dữ liệu cho các Control
        //Tại thời điểm này ta chưa biết dữ liệu sẽ được hiển thị vào đâu nên ta phải dùng delegate
        public delegate void SetDataControl(string Data);
        public SetDataControl SetDataFunction = null;
        //buffer để nhận và gởi dữ liệu
        byte[] sendBuff = new byte[1024];
        byte[] receiveBuff = new byte[1024];
        int byteReceive = 0;
        string stringReceive = "";
        //tao 2 hang doi de chua du lieu nhan va gui di
        public Queue<byte[]> OutQ = new Queue<byte[]>();

        Thread tSend, tReceive, tConnect;

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint serverEP = null;

        public ClientProgram(IPAddress serverIP, int Port)
        {
            serverEP = new IPEndPoint(serverIP, Port);
        }

        /// <summary>
        /// tao 1 thread nhan nhiem vu ket noi de tranh treo tien trinh chinh
        /// </summary>
        public void CreateConnection()
        {
            tConnect = new Thread(new ThreadStart(Connect));
            tConnect.Start();
        }
        /// <summary>
        /// Ham bat dau ket noi
        /// </summary>
        public void Connect()
        {
            serverSocket.BeginConnect(serverEP, new AsyncCallback(ConnectCallback), serverSocket);
        }
        /// <summary>
        /// ham call back thuc hien sau khi ket thuc viec ket noi
        /// </summary>
        /// <param name="ia">gia tri tra ve cua ham begin connect</param>
        private void ConnectCallback(IAsyncResult ia)
        {
            //Lấy Socket đang thực hiện việc kết nối bất đồng bộ
            Socket s = (Socket)ia.AsyncState;
            try
            {
                SetDataFunction("Đang chờ kết nối");
                s.EndConnect(ia);
                SetDataFunction("Kết nối thành công");
            }
            catch
            {
                SetDataFunction("Kết nối thất bại");
                return;
            }
            //Tao 2 thread de nhan va gui du lieu sau khi ket noi thanh cong
            tSend = new Thread(new ThreadStart(SendData));
            tSend.Start();
            tReceive = new Thread(new ThreadStart(ReceiveData));
            tReceive.Start();
        }
        /// <summary>
        /// lap lai viec nhan du lieu tu server
        /// </summary>
        public void ReceiveData()
        {
            try
            {
                serverSocket.BeginReceive(receiveBuff, 0, receiveBuff.Length, SocketFlags.None, new AsyncCallback(ReceiveFromServer), serverSocket);
            }
            catch (Exception e) { SetDataFunction(e.ToString()); throw; }
        }
        /// <summary>
        /// ham call back nhan du lieu, in tin nhan ra man hinh va 
        /// </summary>
        /// <param name="ia">gia tri tra ve cua phuong thuc BeginReceive</param>
        private void ReceiveFromServer(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            try
            {
                byteReceive = s.EndReceive(ia);
                stringReceive = Encoding.ASCII.GetString(receiveBuff);
                SetDataFunction(stringReceive);
                receiveBuff = new byte[1024];
            } catch { SetDataFunction("Server ngat ket noi"); }
            ReceiveData();
        }
        /// <summary>
        /// ham gui du lieu tu hang doi OutQ
        /// </summary>
        public void SendData()
        {
            while (true)
            {
                //gui neu con du lieu chua duoc gui di trong hang doi
                if (OutQ.Count > 0)
                {
                    sendBuff = OutQ.Dequeue();
                    serverSocket.BeginSend(sendBuff, 0, sendBuff.Length, SocketFlags.None, new AsyncCallback(SendToServer), serverSocket);
                    string t = Encoding.ASCII.GetString(sendBuff);
                }
            }
        }
        /// <summary>
        /// ham call back gui du lieu, khoi tao lai gia tri cua buff
        /// </summary>
        /// <param name="ia">gia tri tra ve cua phuong thuc BeginSend</param>
        private void SendToServer(IAsyncResult ia)
        {
            Socket s = (Socket)ia.AsyncState;
            s.EndSend(ia);
        }
        /// <summary>
        /// Ham nhan tin nhan dau vao tu form, dua vao hang doi de gui di
        /// </summary>
        /// <param name="data">noi dung tin nhan</param>
        public void Input(byte[] data)
        {
            OutQ.Enqueue(data);
        }
        /// <summary>
        /// Hàm ngắt kết nối
        /// </summary>
        /// <returns>true: da ngat ket noi, false: loi</returns>
        public bool Disconnect()
        {
            
            try
            {
                //Shutdown Soket đang kết nối đến Server
                serverSocket.Shutdown(SocketShutdown.Both);
                serverSocket.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
