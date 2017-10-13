using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(ipe);
            Console.WriteLine("wating for a client..");
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)(sender);
            byte[] data = new byte[4];
            server.ReceiveFrom(data, ref remote);
            int clientchoosen = BitConverter.ToInt32(data, 0);
            Random rand = new Random(0);
            int serverchoosen = rand.Next(0, 2);
            if (clientchoosen==serverchoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Hoa");
                server.SendTo(send, remote);
            }
            if (clientchoosen>serverchoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thang");
                server.SendTo(send, remote);
            }
            if ((clientchoosen == 0) && (serverchoosen == 2))
            {
                byte[] send = Encoding.ASCII.GetBytes("Thang");
                server.SendTo(send, remote);
            }
            if (clientchoosen < serverchoosen)
            {
                byte[] send = Encoding.ASCII.GetBytes("Thua");
                server.SendTo(send, remote);
            }
            if ((clientchoosen == 2) && (serverchoosen == 0))
            {
                byte[] send = Encoding.ASCII.GetBytes("Thua");
                server.SendTo(send, remote);
            }

        }
    }
}
