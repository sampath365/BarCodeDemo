using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MovieSearchApi.ApIInterface;

namespace MovieSearchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ITmdbApiService _tmdbApiService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MoviesController> _logger;
        private static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromMinutes(10);  // Cache duration

        public MoviesController(ITmdbApiService tmdbApiService, IMemoryCache memoryCache, ILogger<MoviesController> logger)
        {
            _tmdbApiService = tmdbApiService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        // Search Movies Method with Caching
        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies(string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                    return BadRequest("Query cannot be empty.");
                if (string.IsNullOrWhiteSpace(query)) query = "moana-2";

                // Check if the result is cached
                if (!_memoryCache.TryGetValue(query, out var cachedMovies))
                {
                    // Cache miss - fetch from API
                    var movies = await _tmdbApiService.SearchMoviesAsync(query);

                    // Cache the result with a sliding expiration
                    _memoryCache.Set(query, movies, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = DefaultCacheDuration
                    });

                    // Return the result
                    return Ok(movies);
                }

                // Return cached result if available
                return Ok(cachedMovies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred while searching for movies: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // Get Movie Details with Caching
        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetMovieDetails(string movieId)
        {
            try
            {
                // Try to fetch from cache
                if (!_memoryCache.TryGetValue(movieId, out var cachedDetails))
                {
                    // Cache miss - fetch from API
                    var details = await _tmdbApiService.GetMovieDetailsAsync(movieId);

                    // Cache the result with a sliding expiration
                    _memoryCache.Set(movieId, details, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = DefaultCacheDuration
                    });

                    // Return the result
                    return Ok(details);
                }

                // Return cached result if available
                return Ok(cachedDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occurred while retrieving movie details for movieId {movieId}: {ex.Message}");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}