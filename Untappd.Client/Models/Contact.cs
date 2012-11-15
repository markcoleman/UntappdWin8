using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Contact
    {
        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("foursquare")]
        public string Foursquare { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}