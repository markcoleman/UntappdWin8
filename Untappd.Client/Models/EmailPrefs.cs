using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class EmailPrefs
    {
        [JsonProperty("is_friend_request")]
        public int IsFriendRequest { get; set; }

        [JsonProperty("is_toast")]
        public int IsToast { get; set; }

        [JsonProperty("is_comment")]
        public int IsComment { get; set; }
    }
}