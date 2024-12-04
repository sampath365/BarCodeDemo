using Newtonsoft.Json;

namespace MovieSearchApi.Model
{

    public class MovieClientSide: Movie
    {
        private const string BaseImageUrl = "https://image.tmdb.org/t/p/w500";
      
        public string posterPath { get; set; }

        public string ImageUrl => !string.IsNullOrEmpty(posterPath) ? $"{BaseImageUrl}{posterPath}" : "default_image_placeholder.png";
        public bool adult { get; set; }
        public string backdropPath { get; set; }
        
        public string originalLanguage { get; set; }
        public string originalTitle { get; set; }
    
        public double popularity { get; set; }
       
        public string releaseDate { get; set; }
      
        public bool video { get; set; }
        public double voteAverage { get; set; }
        public int voteCount { get; set; }
    }
    public class Movie
    {
     
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

       

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }
       

    }

     
}