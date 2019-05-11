using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class ServerForm : Form
    {
        ServerProgram server = new ServerProgram(IPAddress.Any, 2224);
        bool state = false;
        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ServerProgram.SetDataFunction = new ServerProgram.SetDataControl(SetData);
            ServerProgram.SetClientsNumberFunction = new ServerProgram.SetClientsNumberControl(SetClientsNumber);
            ServerProgram.SetClientsFunction = new ServerProgram.SetClientsControl(SetClients);
        }
        public void SetData(string data)
        {
            lbServerConsole.Items.Add(data);
        }
        public void SetClientsNumber(int clientsNumber)
        {
            tbClientsNumber.Text = clientsNumber.ToString();
        }
        public void SetClients(List<string> clients)
        {
            lbListUser.Items.Clear();
            foreach (string item in clients)
                lbListUser.Items.Add(item);
        }

        private void StartServer_Click(object sender, EventArgs e)
        {
            if (state == false)
            {
                server.Listen();
                state = true;
            }
            else { SetData("Dang cho client ket noi..."); }
        }

        private void StopServer_Click(object sender, EventArgs e)
        {
            if (state == true)
            {
                server.Close();
                SetData("Server dong ket noi");
                state = false;
            }
            else { SetData("Server da dong ket noi"); }
        }

        private void BtnSendAll_Click(object sender, EventArgs e)
        {
            server.SendAll(Encoding.ASCII.GetBytes(tbInput.Text));
        }
    }
        
}
