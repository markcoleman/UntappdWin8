using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class CheckIn
    {
        [JsonProperty("")]
        public int GmtOffset { get; set; }

        [JsonProperty("")]
        public string TimeZone { get; set; }

        [JsonProperty("")]
        public int BeerId { get; set; }

        [JsonProperty("")]
        public string FourSquareId { get; set; }

        [JsonProperty("")]
        public int? GeoLat { get; set; }

        [JsonProperty("")]
        public int? GeoLng { get; set; }

        [JsonProperty("")]
        public string Shout { get; set; }

        [JsonProperty("")]
        public BeerRating Rating { get; set; }

        [JsonProperty("")]
        public bool PostToFacebook { get; set; }

        [JsonProperty("")]
        public bool PostToTwitter { get; set; }

        [JsonProperty("")]
        public bool PostToFourSquare { get; set; }
    }
}