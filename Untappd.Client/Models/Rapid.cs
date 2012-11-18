using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Rapid
    {
        [JsonProperty("is_fast")]
        public bool IsFast { get; set; }

        [JsonProperty("auth_level")]
        public string AuthLevel { get; set; }

        [JsonProperty("time_left_rapid")]
        public int TimeLeftRapid { get; set; }

        [JsonProperty("time_left_reg")]
        public int TimeLeftReg { get; set; }
    }
}