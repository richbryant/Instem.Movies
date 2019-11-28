using System.Collections.Generic;
using System.Threading.Tasks;
using Instem.Movies.Shared.Model;
using Refit;

namespace Instem.Movies.Data
{
    public interface IMovieDataService
    {
        [Get("/movies/")]
        Task<List<Movie>> GetHomePageAsync();

        [Get("/movies/{criteria}")]
        Task<List<Movie>> GetSearchResultsAsync(string criteria);
    }
}