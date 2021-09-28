using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class User
    {
        public User()
        {
            DiscussionReplies = new HashSet<DiscussionReply>();
            Logins = new HashSet<Login>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }

        public virtual ICollection<DiscussionReply> DiscussionReplies { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
