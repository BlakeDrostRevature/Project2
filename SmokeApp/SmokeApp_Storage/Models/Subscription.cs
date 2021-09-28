using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class Subscription
    {
        public Subscription()
        {
            SubscriptionsComments = new HashSet<SubscriptionsComment>();
            SubscriptionsDiscussions = new HashSet<SubscriptionsDiscussion>();
        }

        public int SubscriptionId { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<SubscriptionsComment> SubscriptionsComments { get; set; }
        public virtual ICollection<SubscriptionsDiscussion> SubscriptionsDiscussions { get; set; }
    }
}
