namespace Instem.Movies.Shared.Model
{
    public class Movie
    {
        public int Year { get; set; }
        public string Title { get; set; } = "";
        public Info Info { get; set; } = new Info();
    }
}