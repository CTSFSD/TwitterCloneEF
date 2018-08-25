using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Tweet
    {
        public int tweet_id { get; set; }
        public string user_id { get; set; }
        public string message { get; set; }
        public string created { get; set; }

    }
}