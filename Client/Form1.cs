using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    public partial class Form1 : Form
    {
        Socket client;
        IPEndPoint ipe;
        EndPoint remote;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            remote = (EndPoint)ipe;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "keo";
            int a = 0;
            byte[] send = BitConverter.GetBytes(a);
            client.SendTo(send, remote);

            byte[] rec = new byte[20];
            remote = (EndPoint)ipe;
            client.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bao";
            int a = 0;
            byte[] send = BitConverter.GetBytes(a);
            client.SendTo(send, remote);

            byte[] rec = new byte[20];
            remote = (EndPoint)ipe;
            client.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Bua";
            int a = 0;
            byte[] send = BitConverter.GetBytes(a);
            client.SendTo(send, remote);

            byte[] rec = new byte[20];
            remote = (EndPoint)ipe;
            client.ReceiveFrom(rec, ref remote);
            textBox2.Text = Encoding.ASCII.GetString(rec);
        }
    }
}
