using System.Collections.Generic;
using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Promotions
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public List<object> Items { get; set; }
    }
}