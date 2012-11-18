using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Pagination
    {
        [JsonProperty("next_url")]
        public string NextUrl { get; set; }

        [JsonProperty("max_id")]
        public int MaxId { get; set; }

        [JsonProperty("since_url")]
        public string SinceUrl { get; set; }
    }
}