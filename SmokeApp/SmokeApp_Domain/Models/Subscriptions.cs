using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Domain.Models
{
  class Subscription
  {
    public int SubscriptionID { get; set; }
    public int UserID { get; set; }
    public string GameID { get; set; }
    public Subscription()
    {

    }
  }
}
