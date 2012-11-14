namespace Untappd.Api.Models
{
    public class RequestFriendsResponse
    {
        public string result { get; set; }
        public string request_type { get; set; }
        public string friendship_type { get; set; }
        public TargetUser target_user { get; set; }
    }
}
