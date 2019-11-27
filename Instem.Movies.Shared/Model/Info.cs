using System;
using System.Collections.Generic;

namespace Instem.Movies.Shared.Model
{
    public class Info
    {
        public List<string> Directors { get; set; } = new List<string>();
        
        public DateTime ReleaseDate { get; set; }
        
        public double Rating { get; set; }

        public List<string> Genres { get; set; } = new List<string>();

        public string ImageUrl { get; set; }

        public string Plot { get; set; } = "";

        public int Rank { get; set; }

        public int RunningTimeSecs { get; set; }

        public List<string> Actors { get; set; } = new List<string>();
    }
}
