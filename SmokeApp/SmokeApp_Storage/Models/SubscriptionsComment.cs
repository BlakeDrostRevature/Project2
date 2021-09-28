using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class SubscriptionsComment
    {
        public SubscriptionsComment()
        {
            Comments = new HashSet<Comment>();
        }

        public int SubscriptionsCommentsId { get; set; }
        public int SubscriptionId { get; set; }

        public virtual Subscription Subscription { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
