using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Domain.Models
{
  class DiscussionComment
  {
    public int CommentID { get; set; }
    public int UserID { get; set; }
    public int DiscussionID { get; set; }
    public string comments { get; set; }

    public string context { get; set; }

    public DiscussionComment()
    {

    }
  }
}
