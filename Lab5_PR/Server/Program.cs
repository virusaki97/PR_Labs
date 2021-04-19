using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace Server
{
    class Program
    {
        public static string sha256encrypt(string phrase, string UserName)
        {
            string salt = CreateSalt(UserName);
            string saltAndPwd = String.Concat(phrase, salt);
            UTF8Encoding encoder = new UTF8Encoding();
            SHA256Managed sha256hasher = new SHA256Managed();
            byte[] hashedDataBytes = sha256hasher.ComputeHash(encoder.GetBytes(saltAndPwd));
            string hashedPwd = String.Concat(byteArrayToString(hashedDataBytes), salt);
            return hashedPwd;
        }

        public static string byteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }

        private static string CreateSalt(string UserName)
        {
            string username = UserName;
            byte[] userBytes;
            string salt;
            userBytes = ASCIIEncoding.ASCII.GetBytes(username);
            long XORED = 0x00;

            foreach (int x in userBytes)
                XORED = XORED ^ x;

            Random rand = new Random(Convert.ToInt32(XORED));
            salt = rand.Next().ToString();
            salt += rand.Next().ToString();
            salt += rand.Next().ToString();
            salt += rand.Next().ToString();
            return salt;
        }
        static void Main(string[] args)
        {
            
            IPAddress serverip = IPAddress.Parse("127.0.0.1");
            IPEndPoint ServerEndPoint = new IPEndPoint(serverip, 1234);
            Socket socket = new Socket(serverip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Bind(ServerEndPoint);

                socket.Listen(100);

                while (true)
                {

                    Console.WriteLine("Waiting connection ... ");

                    Socket clientSocket = socket.Accept();

                    
                    byte[] received_into_bytes = new Byte[1024];
                
                    int numByte = clientSocket.Receive(received_into_bytes);
                       
                    string message_received = Encoding.ASCII.GetString(received_into_bytes,0, numByte);


                    Console.Write("The message received from the client: "); Console.WriteLine(message_received);

                    byte[] message_to_send = Encoding.ASCII.GetBytes(sha256encrypt(message_received,"There we go ;)"));
                    
                    clientSocket.Send(message_to_send);

                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Something went Wrong from the server side -_-");
            }

        }
    }
}
