//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterClone
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public Person()
        {
            this.Tweets = new HashSet<Tweet>();
            this.Person1 = new HashSet<Person>();
            this.People = new HashSet<Person>();
        }
    
        public string user_Id { get; set; }
        public string Password { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public System.DateTime joined { get; set; }
        public Nullable<bool> active { get; set; }
    
        public virtual ICollection<Tweet> Tweets { get; set; }
        public virtual ICollection<Person> Person1 { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}