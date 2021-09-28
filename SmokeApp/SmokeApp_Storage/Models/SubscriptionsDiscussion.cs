using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class SubscriptionsDiscussion
    {
        public SubscriptionsDiscussion()
        {
            Discussions = new HashSet<Discussion>();
        }

        public int SubscriptionsDiscussionsId { get; set; }
        public int SubscriptionId { get; set; }

        public virtual Subscription Subscription { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
    }
}
