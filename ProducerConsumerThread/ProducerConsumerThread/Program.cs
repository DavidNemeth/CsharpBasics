﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace ProducerConsumerThread
{
    class Program
    {
        static SyncQueue<int> numbers = new SyncQueue<int>();
        static Random randy = new Random();
        static int NumThreads = Environment.ProcessorCount;
        static int[] sums = new int[NumThreads];
        static int iterate = 20;
        static int range = 100;

        static void ProduceNumbers()
        {
            for (int i = 0; i < iterate; i++)
            {
                int numToEnque = randy.Next(range);
                Console.WriteLine("Producing thread, adding " + numToEnque + " to the queue.");                
                numbers.Enqueue(numToEnque);                              
                Thread.Sleep(randy.Next(500));
            }
        }
        static void SumNumbers(object threadNumber)
        {
            DateTime startTime = DateTime.Now;
            int mySum = 0;
            while ((DateTime.Now - startTime).Seconds < 11)
            {
                int numTosum = -1;
                lock (numbers.SyncRoot)
                {
                    if (numbers.Count != 0)
                    {
                        numTosum = numbers.Dequeue();
                    }
                }
                if (numTosum != -1)
                {
                    mySum += numTosum;
                    Console.WriteLine("Consuming thread#" + threadNumber
                        + ", adding " + numTosum + " to its total sum making "
                        + numTosum + " for the thread total.");
                }                
            }
            sums[(int)threadNumber] = mySum;

        }
        static void Main(string[] args)
        {
            var producingThread = new Thread(ProduceNumbers);
            producingThread.Start();
            Thread[] threads = new Thread[NumThreads];
            for (int i = 0; i < NumThreads; i++)
            {
                threads[i] = new Thread(SumNumbers);
                threads[i].Start(i);
            }
            for (int i = 0; i < NumThreads; i++)
            {
                threads[i].Join();
            }
            int totalSum = 0;
            for (int i = 0; i < NumThreads; i++)
            {
                totalSum += sums[i];
            }
            Console.WriteLine("Done adding. Total is " + totalSum);
            float percentage = ((float)totalSum / ((float)range * (float)iterate)) * 100;
            Console.WriteLine("{0}% of the maximum value", percentage);
        }
    }

    class SyncQueue<T> : Queue<T>
    {
        object bot = new object();
        Queue<T> theQ = new Queue<T>();
        public void Enqueue(T item)
        {
            lock (bot)
                theQ.Enqueue(item);
        }
        public T Dequeue()
        {
            lock (bot)
                return theQ.Dequeue();
        }
        public int Count
        {           
            get { return theQ.Count; }
        }
        public object SyncRoot
        {
            get { return bot; }
        }
    }
}
