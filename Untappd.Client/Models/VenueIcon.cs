using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class VenueIcon
    {
        [JsonProperty("sm")]
        public string sm { get; set; }
        [JsonProperty("md")]
        public string md { get; set; }
        [JsonProperty("lg")]
        public string lg { get; set; }
    }
}