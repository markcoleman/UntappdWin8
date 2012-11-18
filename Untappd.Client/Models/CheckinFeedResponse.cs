using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class CheckinFeedResponse
    {
        [JsonProperty("checkins")]
        public CheckinList Checkins { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }
    }
}