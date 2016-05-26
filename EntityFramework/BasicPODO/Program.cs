using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BasicPODO
{
    class PlayList
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<Video> Videos { get; set; }
        public override string ToString()
        {
            string ret = Title +": ";
            foreach (Video vid in Videos)
            {
                ret += vid.Title + ", ";
            }
            return ret;
        }
    }

    class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<PlayList> PlayLists { get; set; }
    }

    class VidContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
    }

    class MainClass
    {
        static void Main()
        {
            VidContext db = new VidContext();

            Video testVideo = new Video
            {
                Title = "Worst relation",
                Description = "Title says it all"
            };
            Video nextBigHit = new Video
            {
                Title = "The next viral hit",
                Description = "Sharing is caring"
            };
            db.Videos.Add(testVideo);
            db.Videos.Add(nextBigHit);

            PlayList playlist1 = new PlayList();
            PlayList playlist2 = new PlayList();


            playlist1.Title = "playlist1";
            playlist1.Videos = new List<Video> { testVideo, nextBigHit };
            db.PlayLists.Add(playlist1);

            playlist2.Title = "Playlist2";
            playlist2.Videos = new List<Video> { testVideo };
            db.PlayLists.Add(playlist2);

            Console.WriteLine(playlist1);
            Console.WriteLine(playlist2);
            //db.SaveChanges();
            Console.Read();
        }
    }
}
