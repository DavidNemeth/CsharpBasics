using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(SyncExampleTwo.AtTheDoctor).Start();
            }
            //var thread1 = new Thread(SyncExampleOne.IncrementCount);
            //var thread2 = new Thread(SyncExampleOne.IncrementCount);
            //thread1.Start();
            //Thread.Sleep(500);
            //thread2.Start();
            //for (int i = 0; i < Environment.ProcessorCount; i++)
            //{
            //    var thread = new Thread(DifferentMethod);                
            //    thread.Start(i);
            //}  
        }
        //static void DifferentMethod(object threadID)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("Hello from DifferentMethod "+ Thread.CurrentThread.ManagedThreadId);
        //    }
        //}
    }

    class SyncExampleOne
    {
        static object bot = new object();
        static int count = 0;
        public static void IncrementCount()
        {
            while (true)
            {
                lock (bot)
                {
                    int temp = count;
                    Thread.Sleep(1000);
                    count = temp + 1;
                    Console.WriteLine("Thread ID " + Thread.CurrentThread.ManagedThreadId +
                        " incremented count to " + count);
                }
                Thread.Sleep(1000);
            }
        }
    }

    class SyncExampleTwo
    {
        static object bot = new object();
        static Random randy = new Random();
        public static void AtTheDoctor()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId +
                " waiting in the queue area..");
            lock (bot)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId +
                    " my number is up. lets go");
                Thread.Sleep(randy.Next(2000));
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId +
                    " leaving the doctor..");
            }
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId +
                " leaving the building");
        }
    }
}
