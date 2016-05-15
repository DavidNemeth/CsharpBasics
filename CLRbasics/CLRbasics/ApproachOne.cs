using System;
using System.Net;
using System.Threading;

namespace CLRbasics
{
    class ApproachOne
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
                var thread = new Thread(Download);
                thread.Start(url);
            }
        }

        private static void Download(object url)
        {
            var client = new WebClient();
            var html = client.DownloadString(url.ToString());
            Console.WriteLine("Download {0} chars from {1} on thread {2}",
                html.Length, url, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
