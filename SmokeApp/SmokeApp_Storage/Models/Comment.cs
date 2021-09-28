using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class Comment
    {
        public int CommentsId { get; set; }
        public string CommentsContext { get; set; }
        public bool CommentsRating { get; set; }
        public int SubscriptionsCommentsId { get; set; }

        public virtual SubscriptionsComment SubscriptionsComments { get; set; }
    }
}
