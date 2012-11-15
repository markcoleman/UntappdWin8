using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class ShareCheckinSettings
    {
        [JsonProperty("checkin_to_facebook")]
        public int CheckinToFacebook { get; set; }

        [JsonProperty("checkin_to_twitter")]
        public int CheckinToTwitter { get; set; }

        [JsonProperty("checkin_to_foursquare")]
        public int CheckinToFoursquare { get; set; }
    }
}