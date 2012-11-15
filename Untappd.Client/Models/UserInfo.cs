using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class UserInfo
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("user_avatar")]
        public string UserAvatar { get; set; }

        [JsonProperty("is_private")]
        public int IsPrivate { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("is_supporter")]
        public int IsSupporter { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("untappd_url")]
        public string UntappdUrl { get; set; }

        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        [JsonProperty("stats")]
        public Stats Stats { get; set; }

        [JsonProperty("recent_brews")]
        public RecentBrewList RecentBrews { get; set; }

        [JsonProperty("checkins")]
        public CheckinList CheckinList { get; set; }

        [JsonProperty("media")]
        public MediaList Media { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("date_joined")]
        public string DateJoined { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }
    }
}