using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Domain.Models
{
  class Discussion
  {
    public int DiscussionID { get; set; }
    public int SubscriptionID { get; set; }
    public int GameID { get; set; }
    public DateTime Date { get; set; }
    public string title { get; set; }

    public string context { get; set; }

    public Discussion()
    {

    }
  }
}
