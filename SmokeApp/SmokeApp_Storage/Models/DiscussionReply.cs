using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class DiscussionReply
    {
        public int DiscussionRepliesId { get; set; }
        public string DiscussionRepliesContext { get; set; }
        public int UserId { get; set; }
        public int DiscussionsId { get; set; }

        public virtual Discussion Discussions { get; set; }
        public virtual User User { get; set; }
    }
}
