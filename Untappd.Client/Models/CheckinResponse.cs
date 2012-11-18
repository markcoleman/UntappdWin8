using System.Collections.Generic;
using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class CheckinResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("badge_valid")]
        public bool BadgeValid { get; set; }

        [JsonProperty("checkin_id")]
        public int CheckinId { get; set; }

        [JsonProperty("checkin_comment")]
        public string CheckinComment { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("rating")]
        public List<object> Rating { get; set; }

        [JsonProperty("rapid")]
        public Rapid Rapid { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("beer")]
        public Beer Beer { get; set; }

        [JsonProperty("brewery")]
        public Brewery Brewery { get; set; }

        [JsonProperty("venue")]
        public List<object> Venue { get; set; }

        [JsonProperty("recommendations")]
        public List<object> Recommendations { get; set; }

        [JsonProperty("distance")]
        public int Distance { get; set; }

        [JsonProperty("media")]
        public CheckInMedia Media { get; set; }

        [JsonProperty("media_allowed")]
        public bool MediaAllowed { get; set; }

        [JsonProperty("social_settings")]
        public SocialSettings SocialSettings { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("follow_status")]
        public FollowStatus FollowStatus { get; set; }

        [JsonProperty("promotions")]
        public Promotions Promotions { get; set; }

        [JsonProperty("badges")]
        public Badges Badges { get; set; }

        [JsonProperty("social")]
        public List<object> Social { get; set; }
    }
}