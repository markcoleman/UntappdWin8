using Newtonsoft.Json;

namespace Untappd.Api.Models
{
    public class NotificationsResponse
    {
        [JsonProperty("notifications")]
        public NotificationsList Notifications { get; set; }

        [JsonProperty("news")]
        public NewsList News { get; set; }
    }
}