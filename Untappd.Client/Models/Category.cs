using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Category
    {
        [JsonProperty("category_name")]
        public string CategoryName { get; set; }

        [JsonProperty("category_id")]
        public string CategoryId { get; set; }

        [JsonProperty("is_primary")]
        public bool IsPrimary { get; set; }
    }
}