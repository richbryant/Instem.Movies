using System.Text.Json.Serialization;

namespace Instem.Movies.Shared.Model
{
    public class Movie
    {
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; } = "";
        [JsonPropertyName("info")]
        public Info Info { get; set; } = new Info();
    }
}