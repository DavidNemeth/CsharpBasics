using System;
using System.Data.Entity;
using System.Linq;

namespace BasicPODO
{
    class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    class VidContext : DbContext
    {       
        public DbSet<Video> Videos { get; set; }
    }

    class MainClass
    {
        static void Main()
        {            
            var vidContext = new VidContext();
            var testVideo = vidContext.Videos.Single();
            Console.WriteLine(testVideo.ID);
            Console.WriteLine(testVideo.Title);
            Console.WriteLine(testVideo.Description);
        }
    }
}
