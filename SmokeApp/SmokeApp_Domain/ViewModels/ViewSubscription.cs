using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Domain.Models
{
  public class ViewSubscription
  {
    public int SubscriptionID { get; set; }
    public int UserID { get; set; }
    public int GameID { get; set; }
    public ViewSubscription()
    {

    }
  }
}
