using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class CheckInMedia
    {
        [JsonProperty("is_photo")]
        public bool IsPhoto { get; set; }

        [JsonProperty("photo_data")]
        public bool photo_data { get; set; }
    }
}