using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class User
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("user_avatar")]
        public string UserAvatar { get; set; }

        [JsonProperty("account_type")]
        public string AccountType { get; set; }

        [JsonProperty("contact")]
        public Contact Contact { get; set; }

        [JsonProperty("email_prefs")]
        public EmailPrefs EmailPrefs { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }





        [JsonProperty("url")]
        public string Url { get; set; }



       

        [JsonProperty("is_private")]
        public int IsPrivate { get; set; }


    }
}