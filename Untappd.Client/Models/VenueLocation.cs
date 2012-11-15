using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class VenueLocation
    {
        [JsonProperty("venue_address")]
        public string venue_address { get; set; }
        [JsonProperty("venue_city")]
        public string venue_city { get; set; }
        [JsonProperty("venue_state")]
        public string venue_state { get; set; }
        [JsonProperty("lat")]
        public double lat { get; set; }
        [JsonProperty("lng")]
        public double lng { get; set; }
    }
}