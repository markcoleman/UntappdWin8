using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class UserInfoResponse
    {
        [JsonProperty("user")]
        public UserInfo User { get; set; }
    }
}