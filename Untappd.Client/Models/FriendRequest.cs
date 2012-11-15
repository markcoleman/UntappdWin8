using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class FriendRequest
    {
        [JsonProperty("friendship_hash")]
        public string FriendshipHash { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}