using MovieSearchApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieSearchApi.ApIInterface
{
    public interface ITmdbApiService
    {
        Task<List<Movie>> SearchMoviesAsync(string query);
        Task<MovieDetailsWithCast> GetMovieDetailsAsync(string movieId);
    }
}
