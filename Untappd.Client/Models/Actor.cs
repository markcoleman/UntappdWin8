using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Actor
    {
        [DataMember(Name = "uid")]
        public int Uid { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("user_avatar")]
        public string UserAvatar { get; set; }

        [JsonProperty("contact")]
        public object Contact { get; set; }
    }
}