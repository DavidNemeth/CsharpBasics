using CLRbasics;
using System;
using System.Threading;


class SyncDownload
{
    static void Main(string[] args)
    {
       
        ApproachOne.DownloadSync();        
        Console.WriteLine("Waiting to finish on thread {0}..",
            Thread.CurrentThread.ManagedThreadId);  
        Console.ReadLine();

        ApproachTwo.DownloadSync();
        Console.WriteLine("Waiting to finish on thread {0}..",
            Thread.CurrentThread.ManagedThreadId);
        Console.ReadLine();

        ParallelApproach.DownloadSync();
        Console.WriteLine("Waiting to finish on thread {0}..This one should complete the method first before proceeding on",
            Thread.CurrentThread.ManagedThreadId);
        Console.ReadLine();
    }   
    
}

