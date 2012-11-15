using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Settings
    {
        [JsonProperty("badge")]
        public ShareBadgeSettings ShareBadgeSettings { get; set; }

        [JsonProperty("checkin")]
        public ShareCheckinSettings ShareCheckinSettings { get; set; }

        [JsonProperty("navigation")]
        public Navigation Navigation { get; set; }

        [JsonProperty("user_birthday")]
        public string UserBirthday { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("is_map")]
        public int IsMap { get; set; }
    }
}