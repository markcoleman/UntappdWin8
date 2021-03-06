using System.Collections.Generic;
using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class PendingFriendResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("items")]
        public List<FriendRequest> Items { get; set; }
    }
}