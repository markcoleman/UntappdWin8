using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class RemoveFriendResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}