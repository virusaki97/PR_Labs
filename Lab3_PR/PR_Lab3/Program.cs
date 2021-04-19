using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace lab3
{
    class Program
    {
        public static string url_POST = "http://127.0.0.1:8080/myfile.php";
        public static string url_GET = "http://127.0.0.1:8080/url_GET.php?name=Django";
        public static string Post_Request(string url, string password)
        {
            using (WebClient client = new WebClient())
            {

                byte[] response =
                client.UploadValues(url, new NameValueCollection()
                {   { "password", password }   });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
            return "Connection to server failed. Try again in 5 seconds.";
        }

        public static bool Connect_request(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "CONNECT";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        static void Main()
        {
            HttpWebRequest request;
            var method="POST";
            HttpWebResponse response;
            try
            {
                method = "POST";
                request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/myfile.php");
                request.Method = method;
                Console.WriteLine("\nMetoda POST: ");
                response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(Post_Request(url_POST, "87D6FD72CB57724460B363B74BD54A9971C579656C228755BAE8A9AD9AEAE2D73128478911819968083915966842664262531"));
                response.Close();
            }
            catch (Exception) { Console.WriteLine("The server does not allow POST requests !"); }

            try
            {
                method = "GET";
                Console.WriteLine("\nMetoda GET: ");
                using (WebClient client = new WebClient())
                {
                    Console.WriteLine(client.DownloadString(url_GET));
                }
            }catch(Exception) { Console.WriteLine("The server does not allow GET requests !"); }

            try
            {
                method = "HEAD";
                request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/");
                request.Method = method;
                Console.WriteLine(); Console.WriteLine("Metoda HEAD: ");
                response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.Headers.ToString());
            }
            catch(Exception)
            {
                Console.WriteLine("The server does not allow HEAD requests !");
            }

            try
            {
                method = "PUT";
                request = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com/");
                Console.WriteLine("\nMetoda PUT: ");
                response = (HttpWebResponse)request.GetResponse();
                using (var client = new System.Net.WebClient())
                {
                    byte[] val1 = new byte[32];
                    client.UploadData("http://www.microsoft.com/", "PUT", val1);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("The server does not allow PUT requests !");
            }

            try
            {
                method = "DELETE";
                Console.WriteLine("\nMetoda DELETE");
                request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/myfile.php");
                request.Method = method;
                response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.Headers);
                response.Close();
            } catch (Exception)
            {
                Console.WriteLine("The server does not allow DELETE requests !");
            }


            try
            {
                method = "CONNECT";
                Console.WriteLine("\nMetoda CONNECT");
                if (Connect_request("http://127.0.0.1:8080/myfile.php")) 
                { Console.WriteLine("Server is up !"); } 
                else { Console.WriteLine("Server is down !"); }
            }
            catch(Exception)
            {
                Console.WriteLine("The server does not allow DELETE requests !");
            }

            try
            {
                method = "OPTIONS";
                Console.WriteLine("\nMetoda Options");
                request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/myfile.php");
                request.Method = method;
                response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.Headers.ToString());
            } catch (Exception e) { Console.WriteLine(e.Message); }

            try
            {
                method = "TRACE";
                Console.WriteLine("\nMetoda TRACE");
                request = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com/");
                request.Method = method;
                response = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(response.Headers.ToString());
                Console.ReadKey();
            }
            catch (Exception e) { Console.WriteLine(e.Message); Console.ReadKey(); }
        }
        
    }
}
