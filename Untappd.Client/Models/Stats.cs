using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Stats
    {
        [JsonProperty("total_badges")]
        public int TotalBadges { get; set; }

        [JsonProperty("total_friends")]
        public int TotalFriends { get; set; }

        [JsonProperty("total_checkins")]
        public int TotalCheckins { get; set; }

        [JsonProperty("total_beers")]
        public int TotalBeers { get; set; }

        [JsonProperty("total_created_beers")]
        public int TotalCreatedBeers { get; set; }
    }
}