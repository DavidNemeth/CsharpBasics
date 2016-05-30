using System;
using System.Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread1 = new Thread(SyncExampleOne.IncrementCount);
            var thread2 = new Thread(SyncExampleOne.IncrementCount);
            thread1.Start();
            Thread.Sleep(500);
            thread2.Start();
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
        static int count = 0;
        static object bot = new object();
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
}
