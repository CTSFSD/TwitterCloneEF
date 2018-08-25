using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class UserTweets
    {
        public string user_id { get; set; }
        public string fullName { get; set; }
        public int TotalTweets { get; set; }
        public int FollowerTweets { get; set; }
        public int FollowingTweets { get; set; }
    }
}