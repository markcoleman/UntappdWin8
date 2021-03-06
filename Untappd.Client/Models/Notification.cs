using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class Notification
    {
        [JsonProperty("notification_type")]
        public string NotificationType { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("checkin_id")]
        public int CheckinId { get; set; }

        [JsonProperty("checkin_comment")]
        public string CheckinComment { get; set; }

        [JsonProperty("rating_score")]
        public int RatingScore { get; set; }

        [JsonProperty("checkin_owner")]
        public bool CheckinOwner { get; set; }

        [JsonProperty("actor")]
        public Actor Actor { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("beer")]
        public Beer Beer { get; set; }

        [JsonProperty("brewery")]
        public Brewery Brewery { get; set; }

        [JsonProperty("venue")]
        public object Venue { get; set; }

        [JsonProperty("comments")]
        public CommentList Comments { get; set; }

        [JsonProperty("toasts")]
        public ToastList Toasts { get; set; }

        [JsonProperty("media")]
        public MediaList Media { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }
    }
}