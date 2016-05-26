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
            //create
            Video vid = new Video
            {
                Title = "Entity CRUD",
                Description = "learn basic crud with entity"
            };
            vidContext.Videos.Add(vid);
            vidContext.SaveChanges();
            //

            //read
            Video video = vidContext.Videos.First();
            Console.WriteLine(vid.Title);
            //

            //update
            vid.Title = "Update Title";
            Console.WriteLine(vid.Title);
            vidContext.SaveChanges();
            //

            //delete
            vidContext.Videos.Remove(vid);
            vidContext.SaveChanges();            
            //
        }
    }
}
