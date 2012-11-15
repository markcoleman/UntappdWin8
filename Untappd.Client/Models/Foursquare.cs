using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Foursquare
    {
        [JsonProperty("foursquare_id")]
        public string FoursquareId { get; set; }

        [JsonProperty("foursquare_url")]
        public string FoursquareUrl { get; set; }
    }
}