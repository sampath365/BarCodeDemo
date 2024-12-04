using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieSearchApi.Model
{
    public class CastResponse
    {
        [JsonProperty("cast")]
        public List<Cast> Cast { get; set; } // List of cast members
    }


}
