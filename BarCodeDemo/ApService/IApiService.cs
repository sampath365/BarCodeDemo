using MovieSearchApi.Model;

namespace BarCodeDemo.ApService
{
    public interface IApiService
    {
        Task<List<MovieClientSide>> SearchMoviesAsync(string query);
        Task<MovieDetailsWithCast> GetMovieDetailsAsync(string movieId);
    }




}
