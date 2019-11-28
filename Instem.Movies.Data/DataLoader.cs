using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Instem.Movies.Shared.Model;


namespace Instem.Movies.Data
{
    public class DataLoader
    {
        private readonly string _dataLocation;
        private readonly JsonSerializerOptions _options;
        
        public DataLoader(string dataLocation)
        {
            _dataLocation = dataLocation;
            _options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
        }

        public List<Movie> Load()
        {
            var list = new List<Movie>();
            using(var sr = new StreamReader(_dataLocation))
            {
                var data = sr.ReadToEnd();
                list.AddRange(JsonSerializer.Deserialize<List<Movie>>(data, _options));
            }
            return list;
        }

        public async Task<List<Movie>> LoadAsync()
        {
            var list = new List<Movie>();
            using (var sr = new StreamReader(_dataLocation))
            {
                var data = await sr.ReadToEndAsync();
                var m = JsonSerializer.Deserialize<List<Movie>>(data, _options);
                list.AddRange(m);
            }
            return list;
        }

        public List<Movie> LoadHomePageSelection()
        {
            var list = new List<Movie>();
            var movies = Load(); 
            list.AddRange(movies.OrderByDescending(y => y.Year).Take(4));
            return list;
        }

        public async Task<List<Movie>> LoadHomePageSelectionAsync()
        {
            var list = new List<Movie>();
            var movies = await LoadAsync(); 
            list.AddRange(movies.OrderByDescending(y => y.Year).Take(4));
            return list;
        }

        public List<Movie> SearchResults(string criteria)
        {
            var list = Load();
            var result = new List<Movie>();

            if (int.TryParse(criteria, out var year)) result.AddRange(list.Where(m => m.Year == year));

            result.AddRange(list.Where(m => m.Title.Contains(criteria)));
            result.AddRange(list.Where(m => m.Info.Directors.Any(d => d.Contains(criteria))));
            result.AddRange(list.Where(m => m.Info.Genres.Any(g => g.Contains(criteria))));
            result.AddRange(list.Where(m => m.Info.Actors.Any(a => a.Contains(criteria))));
            result.AddRange(list.Where(m => m.Info.Plot.Contains(criteria)));

            return result.Distinct().ToList();
        }

        public async Task<List<Movie>> SearchResultsAsync(string criteria)
        {
            var list = await LoadAsync();
            var result = new List<Movie>();

            if (int.TryParse(criteria, out var year)) result.AddRange(list.Where(m => m.Year == year));

            result.AddRange(list.Where(m => m.Title.Contains(criteria)));
            result.AddRange(list.Where(m => m.Info.Directors.Any(d => d.Contains(criteria))));
            result.AddRange(list.Where(m => m.Info.Genres.Any(g => g.Contains(criteria))));
            result.AddRange(list.Where(m => m.Info.Actors.Any(a => a.Contains(criteria))));
            result.AddRange(list.Where(m => m.Info.Plot.Contains(criteria)));

            return result.Distinct().ToList();
        }
    }
}
