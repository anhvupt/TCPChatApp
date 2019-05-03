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
        ClientProgram client = new ClientProgram();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            client.SetDataFunction = new ClientProgram.SetDataControl(SetData);
        }
        private void SetData(string Data)
        {
            this.listBox1.Items.Add(Data);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            client.Connect(IPAddress.Parse(this.textBox1.Text), int.Parse(this.textBox2.Text));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            client.SendData(this.richTextBox1.Text);
            this.richTextBox1.Text = "";
        }
    }
}
