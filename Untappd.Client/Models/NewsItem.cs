using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class NewsItem
    {
        [JsonProperty("news_id")]
        public int NewsId { get; set; }

        [JsonProperty("news_title")]
        public string NewsTitle { get; set; }

        [JsonProperty("news_link")]
        public string NewsLink { get; set; }

        [JsonProperty("news_text")]
        public string NewsText { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("news_type")]
        public string NewsType { get; set; }
    }
}