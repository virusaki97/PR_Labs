using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = 0;
            while (true)
            {
                try
                {
                    IPAddress serverip = IPAddress.Parse("127.0.0.1");

                    IPEndPoint ServerEndPoint = new IPEndPoint(serverip, 1234);

                    Socket socket = new Socket(serverip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                    socket.Connect(ServerEndPoint);


                    string message_to_send;

                    while (true)
                    {
                        Console.Write("Enter the message to send to the server: (quit to exit) ");
                        message_to_send = Console.ReadLine();
                        if (message_to_send.ToLower() == "quit") { Environment.Exit(0); }
                        if (message_to_send == "") { Console.WriteLine("Please enter a valid message ..."); continue; } else break;
                    }

                        byte[] message_to_send_in_bytes = Encoding.ASCII.GetBytes(message_to_send);
                        int byteSent = socket.Send(message_to_send_in_bytes);


                        byte[] message_received = new byte[1024];


                        int byteReceived = socket.Receive(message_received);
                    Console.Write("Message received from the server");

                          Console.WriteLine(Encoding.ASCII.GetString(message_received, 0, byteReceived)); 


                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not coonect to the server. Trying to recconect in 2 seconds ..."); Thread.Sleep(2000); t++;
                    if (t == 3) { Console.WriteLine("Could not coonect to the server. Try again later ..."); Console.ReadKey(); Environment.Exit(0); }
                }
            }


             Console.ReadKey();
        }
    }
}
