﻿using System;
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
            db.Videos.Add(testVideo);    
                
            PlayList testPlayList = new PlayList();
            testPlayList.Title = "playlist1";
            testPlayList.Videos = new List<Video> { testVideo };
            db.PlayLists.Add(testPlayList);
            db.SaveChanges();
        }
    }
}
