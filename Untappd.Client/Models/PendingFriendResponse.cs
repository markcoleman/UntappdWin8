using System.Collections.Generic;

namespace Untappd.Api.Models
{
    public class PendingFriendResponse
    {
        public int count { get; set; }
        public List<FriendRequest> items { get; set; }
    }
}