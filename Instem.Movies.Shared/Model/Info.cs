using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Instem.Movies.Shared.Model
{
    public class Info
    {
        [JsonPropertyName("directors")]
        public List<string> Directors { get; set; } = new List<string>();
        
        [JsonPropertyName("release_date")]
        public DateTime ReleaseDate { get; set; }
        
        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; } = new List<string>();

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("plot")]
        public string Plot { get; set; } = "";

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("running_time_secs")]
        public int RunningTimeSecs { get; set; }

        [JsonPropertyName("actors")]
        public List<string> Actors { get; set; } = new List<string>();
    }
}
