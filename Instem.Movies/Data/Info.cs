using System;

namespace Instem.Movies.Data
{
    public class Info
    {
        public string[] Directors { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        public double Rating { get; set; }

        public string[] Genres { get; set; }

        public string ImageUrl { get; set; }

        public string Plot { get; set; }

        public int Rank { get; set; }

        public int RunningTimeSecs { get; set; }

        public string[] Actors { get; set; }
    }
}
