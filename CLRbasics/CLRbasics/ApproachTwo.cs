using System;
using System.Net;
using System.Threading;

namespace CLRbasics
{
    public class ApproachTwo
    {
        public static void DownloadSync()
        {
            string[] urls =
                {
                "https://eztv.ag/",
                "https://www.twitch.tv/draintrainy/profile",
                "http://windows.microsoft.com/en-us/windows/set-program-access-computer-defaults#1TC=windows-7"
            };

            foreach (var url in urls)
            {
                Download(url);
            }
        }

        private static void Download(string url)
        {
            var client = new WebClient();
            client.DownloadStringCompleted += clinet_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(url), url);                       
        }

        private static void clinet_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var html = e.Result;
            var url = e.UserState as string;
            Console.WriteLine("Download {0} chars from {1} on thread {2}",
                html.Length, url, Thread.CurrentThread.ManagedThreadId);
        }
    }
}