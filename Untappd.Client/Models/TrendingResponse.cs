using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class TrendingResponse
    {
        [JsonProperty("macro")]
        public BeerList Macro { get; set; }

        [JsonProperty("micro")]
        public BeerList Micro { get; set; }
    }
}