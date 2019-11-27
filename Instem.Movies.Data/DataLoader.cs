using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Instem.Movies.Shared.Model;


namespace Instem.Movies.Data
{
    public class DataLoader
    {
        private readonly string _dataLocation;

        public DataLoader(string dataLocation)
        {
            _dataLocation = dataLocation;
        }

        public List<Movie> Load()
        {
            var list = new List<Movie>();
            using(var sr = new StreamReader(_dataLocation))
            {
                var data = sr.ReadToEnd();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                list.AddRange(JsonSerializer.Deserialize<List<Movie>>(data, options));
            }
            return list;
        }

        public List<Movie> LoadHomePageSelection()
        {
            var list = new List<Movie>();
            using(var sr = new StreamReader(_dataLocation))
            {
                var data = sr.ReadToEnd();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                list.AddRange((JsonSerializer.Deserialize<List<Movie>>(data, options)).OrderByDescending(y => y.Year).Take(4));
            }
            return list;
        }

        public List<Movie> SearchResults(string criteria)
        {
            var list = Load();
            var result = new List<Movie>();

            if (int.TryParse(criteria, out var year))
            {
                var searchYear = list.Where(m => m.Year == year).ToList();
                result.AddRange(searchYear);
            }

            var searchTitle = list.Where(m => m.Title.Contains(criteria)).ToList();
            var searchDirector = list.Where(m => m.Info.Directors.Any(d => d.Contains(criteria))).ToList();
            var searchGenres = list.Where(m => m.Info.Genres.Any(g => g.Contains(criteria))).ToList();
            var searchActors = list.Where(m => m.Info.Actors.Any(a => a.Contains(criteria))).ToList();
            var searchPlot = list.Where(m => m.Info.Plot.Contains(criteria)).ToList();

            
            result.AddRange(searchTitle);
            result.AddRange(searchDirector);
            result.AddRange(searchGenres);
            result.AddRange(searchActors);
            result.AddRange(searchPlot);

            return result;
        }
    }
}
