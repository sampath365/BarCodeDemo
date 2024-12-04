using System.Collections.Generic;

namespace MovieSearchApi.Model
{
    public class MovieDetailsWithCast
    {
        public MovieDetails Movie { get; set; }
        public List<Cast> Cast { get; set; }
    }


}
