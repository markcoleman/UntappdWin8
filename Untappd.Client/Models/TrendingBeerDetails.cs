using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class TrendingBeerDetails
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("your_count")]
        public int YourCount { get; set; }

        [JsonProperty("beer")]
        public Beer Beer { get; set; }

        [JsonProperty("brewery")]
        public Brewery Brewery { get; set; }
    }
}