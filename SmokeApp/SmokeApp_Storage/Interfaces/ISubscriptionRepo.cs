using SmokeApp_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Interfaces {
    public interface ISubscriptionRepo {
        Task<List<ViewSubscription>> SubscriptionListAsync();
        Task<List<ViewSubscription>> GetCurrentSubsForUserAsync(String username);
        Task<ViewSubscription> MakeASubscription(string username, int gameid);
    }
}
