namespace Untappd.Api.Models
{
    public class FriendRequest
    {
        public string friendship_hash { get; set; }
        public string created_at { get; set; }
        public User user { get; set; }
    }
}