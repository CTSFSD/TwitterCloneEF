using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Person
    {
        public string user_id { get; set; }
        public string password { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string joined { get; set; }
        public bool active { get; set; }
    }
}