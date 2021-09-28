using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class Discussion
    {
        public Discussion()
        {
            DiscussionReplies = new HashSet<DiscussionReply>();
        }

        public int DiscussionsId { get; set; }
        public DateTime DiscussionsDate { get; set; }
        public string DiscussionsTitle { get; set; }
        public string DiscussionsContext { get; set; }
        public int SubscriptionsDiscussionsId { get; set; }

        public virtual SubscriptionsDiscussion SubscriptionsDiscussions { get; set; }
        public virtual ICollection<DiscussionReply> DiscussionReplies { get; set; }
    }
}
