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
    public class SubscriptionRepo : ISubscriptionRepo {

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

        public async Task<List<ViewSubscription>> GetCurrentSubsForUserAsync(String username) {
            //get all subscriptions for the current username
            //get the userid for the username
            User curU = await _context.Users.FromSqlRaw<User>("SELECT * FROM Users WHERE username = {0}", username).FirstOrDefaultAsync();
            //get the list of subs for the curU
            List<Subscription> subs = await _context.Subscriptions.FromSqlRaw<Subscription>("SELECT * FROM Subscriptions WHERE UserID = {0}", curU.UserId).ToListAsync();

            //return the list of viewSubs
            List<ViewSubscription> vsubs = new List<ViewSubscription>();
            foreach(Subscription s in subs) {
                vsubs.Add(EFToView(s));
            }
            return vsubs;
        }

        public async Task<ViewSubscription> MakeASubscription(string username, int gameid) {
            //get the userid for the username
            User curU = await _context.Users.FromSqlRaw<User>("SELECT * FROM Users WHERE username = {0}", username).FirstOrDefaultAsync();

            //Add the current info to the Subscriptions Table
            int response = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Subscriptions(GameID, UserID) VALUES({0},{1})", gameid, curU.UserId);
            if (response != 1) return null;
            //send back the new record
            Subscription s = await _context.Subscriptions.FromSqlRaw<Subscription>("SELECT * FROM Subscriptions WHERE GameID = {0} AND UserID = {1}", gameid, curU.UserId).FirstOrDefaultAsync();
            return EFToView(s);        
        }
    }
}
