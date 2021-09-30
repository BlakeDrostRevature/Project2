using Microsoft.EntityFrameworkCore;
using SmokeApp_Domain.Models;
using SmokeApp_Storage.Interfaces;
using SmokeApp_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Repositories {
    public class DiscussionRepo : IDiscussionRepo{

        private readonly SmokeDBContext _context;

        public DiscussionRepo(SmokeDBContext context) {
            _context = context;
        }

        public async Task<Discussion> ViewToEF(ViewDiscussion view) {
            Discussion u1 = await _context.Discussions.FromSqlRaw<Discussion>("SELECT * FROM Discussions WHERE DiscussionID = {0}", view.DiscussionID).FirstOrDefaultAsync();
            return u1;
        }

        public async Task<ViewDiscussion> EFToView(Discussion u) {
            Console.WriteLine(u.SubscriptionsDiscussionsId);
            Subscription s = await _context.Subscriptions.FromSqlRaw<Subscription>("SELECT * FROM Subscriptions WHERE SubscriptionID = {0}", u.SubscriptionsDiscussionsId).FirstOrDefaultAsync();
            ViewDiscussion vu = new ViewDiscussion {
                DiscussionID = u.DiscussionsId,
                SubscriptionID = u.SubscriptionsDiscussionsId,
                title = u.DiscussionsTitle,
                Date = u.DiscussionsDate,
                context = u.DiscussionsContext,
                GameID = s.GameId
            };
            return vu;
        }

        public async Task<List<ViewDiscussion>> DiscussionListAsync() {
            List<Discussion> dis = await _context.Discussions.FromSqlRaw<Discussion>("SELECT * FROM Discussions").ToListAsync();
            List<ViewDiscussion> vdis = new List<ViewDiscussion>();
            foreach(Discussion d in dis) {
                ViewDiscussion curvd = await EFToView(d);
                vdis.Add(curvd);
            }
            return vdis;
        }
    }
}
