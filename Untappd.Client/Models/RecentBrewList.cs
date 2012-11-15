using System.Collections.Generic;
using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class RecentBrewList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public List<RecentBrew> Items { get; set; }
    }
}