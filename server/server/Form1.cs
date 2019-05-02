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
            server.SetDataFunction = new ServerProgram.SetDataControl(SetData);
            server.SetClientsNumberFunction = new ServerProgram.SetClientsNumberControl(SetClientsNumber);
            server.SetClientsFunction = new ServerProgram.SetClientsControl(SetClients);
        }
        public void SetData(string data)
        {
            listBox1.Items.Add(data);
        }
        public void SetClientsNumber(int clientsNumber)
        {
            textBox1.Text = clientsNumber.ToString();
        }
        public void SetClients(List<string> clients)
        {
            listBox2.Items.Clear();
            foreach (string item in clients)
                listBox2.Items.Add(item);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (state == false)
            {
                server.Listen();
                state = true;
            }
            else { SetData("Dang cho client ket noi..."); }   
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (state == true)
            {
                server.Close();
                SetData("Server dong ket noi");
                state = false;
            }
            else { SetData("Server da dong ket noi"); }
        }
    }
        
}
