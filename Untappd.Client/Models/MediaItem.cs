using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class MediaItem
    {
        [JsonProperty("photo_id")]
        public int PhotoId { get; set; }

        [JsonProperty("photo")]
        public Photo Photo { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("checkin_id")]
        public int CheckinId { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("beer")]
        public Beer Beer { get; set; }

        [JsonProperty("brewery")]
        public Brewery Brewery { get; set; }

        [JsonProperty("venue")]
        public Venue Venue { get; set; }
    }
}