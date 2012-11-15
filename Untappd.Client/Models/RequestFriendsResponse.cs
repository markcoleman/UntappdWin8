using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class RequestFriendsResponse 
    {
        [JsonProperty("result")]
        public string result { get; set; }
        [JsonProperty("request_type")]
        public string request_type { get; set; }
        [JsonProperty("friendship_type")]
        public string friendship_type { get; set; }
        [JsonProperty("target_user")]
        public TargetUser target_user { get; set; }
    }


    public abstract class UntappdResponse
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }

    public class ResponseTime
    {
        [JsonProperty("time")]
        public double Time { get; set; }

        [JsonProperty("measure")]
        public string Measure { get; set; }
    }

    public class Meta
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("error_detail")]
        public string ErrorDetail { get; set; }

        [JsonProperty("error_type")]
        public string ErrorType { get; set; }

        [JsonProperty("response_time")]
        public ResponseTime ResponseTime { get; set; }
    }
}
