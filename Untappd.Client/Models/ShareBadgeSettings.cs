using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class ShareBadgeSettings
    {
        [JsonProperty("badges_to_facebook")]
        public int BadgesToFacebook { get; set; }

        [JsonProperty("badges_to_twitter")]
        public int BadgesToTwitter { get; set; }
    }
}