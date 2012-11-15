using System.Collections.Generic;
using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class ToastList
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("auth_toast")]
        public bool AuthToast { get; set; }

        [JsonProperty("items")]
        public List<object> Items { get; set; }
    }
}