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
        public List<Video> GoodVideos { get; set; }
        public List<Video> BadVideos { get; set; }    
    }

    class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }  
    }

    class VidContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayList>().HasMany(p => p.GoodVideos).WithMany();
            modelBuilder.Entity<PlayList>().HasMany(p => p.BadVideos).WithMany();
        }
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
            playlist1.GoodVideos = new List<Video> { nextBigHit };
            playlist1.BadVideos = new List<Video> { testVideo };
            db.PlayLists.Add(playlist1);

            playlist2.Title = "playlist2";
            playlist2.BadVideos = new List<Video> { testVideo };
            playlist2.GoodVideos = new List<Video> { nextBigHit };
            db.PlayLists.Add(playlist2);            
            //db.SaveChanges();            
        }
    }
}
