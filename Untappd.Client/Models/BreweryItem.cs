using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class BreweryItem
    {
        [JsonProperty("brewery")]
        public Brewery Brewery { get; set; }
    }
}