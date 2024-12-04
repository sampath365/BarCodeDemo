using MovieSearchApi.Model;
using Newtonsoft.Json;

namespace BarCodeDemo.ApService
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7181/api/"; // Replace with your API base URL

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<List<MovieClientSide>> SearchMoviesAsync(string query)
        {
            var response = await _httpClient.GetAsync($"movies/search?query={query}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<MovieClientSide>>(json);
            }

            throw new Exception("Error fetching movies.");
        }

        public async Task<MovieDetailsWithCast> GetMovieDetailsAsync(string movieId)
        {
            var response = await _httpClient.GetAsync($"movies/{movieId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MovieDetailsWithCast>(json);
            }

            throw new Exception("Error fetching movie details.");
        }
    }




}
