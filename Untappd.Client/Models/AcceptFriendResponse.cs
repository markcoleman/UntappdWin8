using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class AcceptFriendResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("request_type")]
        public string RequestType { get; set; }

        [JsonProperty("friendship_type")]
        public string FriendshipType { get; set; }

        [JsonProperty("target_user")]
        public TargetUser TargetUser { get; set; }
    }
}