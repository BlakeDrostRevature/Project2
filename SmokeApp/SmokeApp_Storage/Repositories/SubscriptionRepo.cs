using Microsoft.EntityFrameworkCore;
using SmokeApp_Domain.Models;
using SmokeApp_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Repositories {
    public class SubscriptionRepo {

        private readonly SmokeDBContext _context;


        public SubscriptionRepo(SmokeDBContext context) {
            _context = context;
        }

        public async Task<Subscription> ViewToEF(ViewSubscription view) {
            Subscription s1 = await _context.Subscriptions.FromSqlRaw<Subscription>("SELECT * FROM Subscriptions WHERE UserID = {0} AND GameID = {1}", view.UserID, view.GameID).FirstOrDefaultAsync();
            return s1;
        }

        public ViewSubscription EFToView(Subscription s) {
            ViewSubscription vs = new ViewSubscription {
                SubscriptionID = s.SubscriptionId,
                GameID = s.GameId,
                UserID = s.UserId
            };
            return vs;
        }

        public async Task<List<ViewSubscription>> SubscriptionListAsync() {
            List<Subscription> subs = await _context.Subscriptions.FromSqlRaw<Subscription>("SELECT * FROM Subscriptions").ToListAsync();
            List<ViewSubscription> vs = new List<ViewSubscription>();
            foreach(Subscription s in subs) {
                vs.Add(EFToView(s));
            }
            return vs;
        }
    }
}
