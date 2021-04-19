using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {

                    IPAddress ipAddr = IPAddress.Parse("127.0.0.1");

                    IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 4444);

                    Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

                    Console.Write("Enter your message (enter 'quit' if you want to close the program ...): ");
                    string msg = Console.ReadLine();
                    if ( msg.ToLower() == "quit") Environment.Exit(0);


                    byte[] msgbyte = Encoding.ASCII.GetBytes(msg);

                    sender.SendTo(msgbyte, SocketFlags.None, localEndPoint);


                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

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
