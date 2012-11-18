using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class FollowStatus
    {
        [JsonProperty("is_follow")]
        public bool IsFollow { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("uid")]
        public int Uid { get; set; }
    }
}