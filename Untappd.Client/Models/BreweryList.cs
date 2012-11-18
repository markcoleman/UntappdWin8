using System.Collections.Generic;
using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class BreweryList
    {
        [JsonProperty("items")]
        public List<BreweryItem> Items { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}