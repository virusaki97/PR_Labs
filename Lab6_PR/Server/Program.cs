using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 4444);
                Socket listener = new Socket(ipAddr.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

                try
                {
                    listener.Bind(localEndPoint);

                    Console.WriteLine("Waiting connection ... ");

                    byte[] bytes = new Byte[1024];

                    int num = listener.Receive(bytes);

                    byte[] trimmed = new byte[num];
                    Array.Copy(bytes, 0, trimmed, 0, num);

                    Console.WriteLine(Encoding.ASCII.GetString(trimmed));

                    listener.Close();

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            Console.ReadKey();
        }
    }
}
