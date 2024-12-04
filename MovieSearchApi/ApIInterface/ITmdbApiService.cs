using MovieSearchApi.Model;

namespace MovieSearchApi.ApIInterface
{
    public interface ITmdbApiService
    {
        Task<List<Movie>> SearchMoviesAsync(string query);
        Task<MovieDetailsWithCast> GetMovieDetailsAsync(string movieId);
    }
}
