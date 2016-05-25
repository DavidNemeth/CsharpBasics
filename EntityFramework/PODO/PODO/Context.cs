using System;
using System.Data.Entity;

namespace PODO
{
    class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    class VidContext : DbContext
    {
        public VidContext() : base(@"Data Source =(localdb)\ProjectsV13; Initial catalog = MyTestDb; Integrated Security = True") { }
        public DbSet<Video> Videos { get; set; }        
    }

    class MainClass
    {
        static void Main()
        {
            var video = new Video
            {
                Title = "Warcraft",
                Description = "Some kind of move with orcs n trolls"
            };
            var vidContext = new VidContext();
            vidContext.Videos.Add(video);
            vidContext.SaveChanges();
        }
    }
}
