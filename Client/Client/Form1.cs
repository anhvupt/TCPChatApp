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

namespace Client
{
    public partial class Form1 : Form
    {
        ClientProgram client;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void SetData(string Data)
        {
            this.lbMessageBox.Items.Add(Data);
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            client = new ClientProgram(IPAddress.Parse(tbIpServer.Text), int.Parse(tbPort.Text));
            client.SetDataFunction = new ClientProgram.SetDataControl(SetData);
            client.CreateConnection();
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            client.Input(Encoding.ASCII.GetBytes(tbInput.Text));
            this.tbInput.Text = "";
        }
    }
}
