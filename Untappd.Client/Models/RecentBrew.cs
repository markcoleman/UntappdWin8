using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class RecentBrew
    {
        [JsonProperty("beer")]
        public Beer Beer { get; set; }

        [JsonProperty("brewery")]
        public Brewery Brewery { get; set; }
    }
}