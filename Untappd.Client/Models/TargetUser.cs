namespace Untappd.Api.Models
{
    public class TargetUser
    {
        public int uid { get; set; }
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string location { get; set; }
        public string url { get; set; }
        public string bio { get; set; }
        public string user_avatar { get; set; }
        public string account_type { get; set; }
        public Contact contact { get; set; }
    }
}