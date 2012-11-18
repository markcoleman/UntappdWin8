using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class SocialSettings
    {
        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("foursquare")]
        public string Foursquare { get; set; }
    }
}