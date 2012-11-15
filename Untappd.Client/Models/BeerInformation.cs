using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class BeerInformation
    {
        [JsonProperty("beer")]
        public Beer Beer { get; set; }

        [JsonProperty("brewery")]
        public Brewery Brewery { get; set; }
    }
}