using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Source
    {
        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("app_website")]
        public string AppWebsite { get; set; }
    }
}