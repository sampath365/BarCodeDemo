using MovieSearchApi.ApIInterface;
using MovieSearchApi.Model;
using Newtonsoft.Json;

namespace MovieSearchApi.APIRepositry
{
    public class TmdbApiService : ITmdbApiService
    {
        private readonly HttpClient _httpClient;

        public TmdbApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> SearchMoviesAsync(string query)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"search/movie?query={query}");
                var result = JsonConvert.DeserializeObject<ApiResponse<Movie>>(response);
                return result?.Results ?? null;
            }
            catch (Exception ex)
            {
                // Log the exception here (optional)
                Console.WriteLine($"Error occurred during movie search: {ex.Message}");
                return null; // Return null if any exception occurs
            }
        }

        public async Task<MovieDetailsWithCast> GetMovieDetailsAsync(string movieId)
        {
            try
            {
                // Get movie details
                var response = await _httpClient.GetStringAsync($"movie/{movieId}?api_key=YOUR_API_KEY");
                var movieDetails = JsonConvert.DeserializeObject<MovieDetails>(response);

                // Get cast details
                var castResponse = await _httpClient.GetStringAsync($"movie/{movieId}/credits?api_key=YOUR_API_KEY");
                var cast = JsonConvert.DeserializeObject<CastResponse>(castResponse);

                // Create and return the combined result
                return new MovieDetailsWithCast
                {
                    Movie = movieDetails,
                    Cast = cast?.Cast
                };
            }
            catch (Exception ex)
            {
                // Log the exception here (optional)
                Console.WriteLine($"Error occurred while fetching movie details: {ex.Message}");
                return null; // Return null if any exception occurs
            }
        }


        public async Task<List<Cast>> GetMovieCastAsync(string movieId)
        {
            try
            {
                // Make API call to get cast details
                var response = await _httpClient.GetStringAsync($"movie/{movieId}/credits");
                var castResponse = JsonConvert.DeserializeObject<CastResponse>(response);

                // Return the list of cast members
                return castResponse?.Cast;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching cast details: {ex.Message}");
                return null; // Return null in case of an error
            }
        }
    }
}