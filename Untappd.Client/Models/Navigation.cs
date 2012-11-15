using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Navigation
    {
        [JsonProperty("default_to_checkin")]
        public int DefaultToCheckin { get; set; }
    }
}