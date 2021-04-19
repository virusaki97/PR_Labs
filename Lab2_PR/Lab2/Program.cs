using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        private static List<Thread> threads = new List<Thread>();

        public static void doSomeWork(int ms)
        {
            string szThread = Thread.CurrentThread.Name;

            if (szThread.Equals("Thread 2"))
            {
                foreach ( Thread t in threads.ToList() )
                {
                    if ( t.Name.Equals("Thread 1") )
                        t.Join();
                }
            }

            if (szThread.Equals("Thread 5"))
            {
                foreach (Thread t in threads.ToList())
                {
                    if (t.Name.Equals("Thread 2"))
                        t.Join();
                }
            }

            if (szThread.Equals("Thread 4"))
            {
                foreach (Thread t in threads.ToList())
                {
                    if (t.Name.Equals("Thread 6"))
                        t.Join();
                }
            }

            if (szThread.Equals("Thread 7"))
            {
                foreach (Thread t in threads.ToList())
                {
                    if (t.Name.Equals("Thread 4"))
                        t.Join();
                }
            }

            if (szThread.Equals("Thread 3"))
            {
                foreach (Thread t in threads.ToList())
                {
                    if ( t.Name.Equals("Thread 1") || t.Name.Equals("Thread 5") || t.Name.Equals("Thread 6") || t.Name.Equals("Thread 7") )
                        t.Join();
                }
            }

            Console.WriteLine("Starting {0} \n", szThread);
            Thread.Sleep(ms);
            Console.WriteLine("{0} finished. \n", szThread);

        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => doSomeWork(1000));
            t1.Name = "Thread 1";
            threads.Add(t1);
            t1.Start();
            

            Thread t2 = new Thread(() => doSomeWork(1000));
            t2.Name = "Thread 2";
            threads.Add(t2);
            t2.Start();
           

            Thread t3 = new Thread(() => doSomeWork(1000));
            t3.Name = "Thread 3";
            threads.Add(t3);
            t3.Start();
           

            Thread t4 = new Thread(() => doSomeWork(1000));
            t4.Name = "Thread 4";
            threads.Add(t4);
            t4.Start();

            Thread t5 = new Thread(() => doSomeWork(1000));
            t5.Name = "Thread 5";
            threads.Add(t5);
            t5.Start();
           

            Thread t6 = new Thread(() => doSomeWork(1000));
            t6.Name = "Thread 6";
            threads.Add(t6);
            t6.Start();

            Thread t7 = new Thread(() => doSomeWork(1000));
            t7.Name = "Thread 7";
            threads.Add(t7);
            t7.Start();

            Console.ReadKey();

        }
    }
}
