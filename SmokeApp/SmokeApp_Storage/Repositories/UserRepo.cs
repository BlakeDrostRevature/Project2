using Microsoft.EntityFrameworkCore;
using SmokeApp_Domain.Models;
using SmokeApp_Domain.ViewModels;
using SmokeApp_Storage.Interfaces;
using SmokeApp_Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Repositories {
    public class UserRepo: IUserRepo {

        private readonly SmokeDBContext _context;


        public UserRepo(SmokeDBContext context) {
            _context = context;
        }

        public async Task<User> ViewToEF(ViewUser view) {
            User u1 = await _context.Users.FromSqlRaw<User>("SELECT * FROM Users WHERE Username = {0}", view.Username).FirstOrDefaultAsync();
            return u1;
        }

        public ViewUser EFToView(User u) {
            
            

            
            ViewUser vu = new ViewUser {
                
                UserId = u.UserId,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Username = u.Username,
                Email = u.Email,
                Dob = u.Dob,
                Password = u.Password
            };

            return vu;
        }

        public async Task<ViewUser> LoginUserAsync(ViewUser vu) {
            var u1 = await _context.Users.FromSqlRaw<User>("SELECT * FROM Users WHERE Username = {0} AND [Password] = {1}", vu.Username, vu.Password).FirstOrDefaultAsync();
            //Console.WriteLine(u1.LastName);

            if (u1 == null) return null;

            ViewUser vu1 = EFToView(u1);
            return vu1;
        }

        public async Task<List<ViewUser>> UserListAsync() {
            List<User> users = await _context.Users.FromSqlRaw<User>("SELECT * FROM Users").ToListAsync();
            List<ViewUser> vu = new List<ViewUser>();
            foreach( User u in users) {
                vu.Add(EFToView(u));
            }
            return vu;
        }

        public async Task<ViewUser> RegisterUserAsync(ViewUser vu) {
            int response = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Users(FirstName, LastName, Email, DOB, Username, [Password]) VALUES ({0},{1},{2},{3},{4},{5})", vu.FirstName, vu.LastName, vu.Email, vu.Dob, vu.Username, vu.Password);
            if (response != 1) return null;
            return await LoginUserAsync(vu);
        }

        public async Task<ViewSubscription> SubscribeToAGame(int aGameID, string username) {
            //assuming the aGameID is the ID of the external API Game
            //we need to get the GameID that corresponds to that aGameID
            Game g = await _context.Games.FromSqlRaw<Game>("SELECT * FROM Games WHERE ExternalAPIGameID = {0}", aGameID).FirstOrDefaultAsync();
            User u = await _context.Users.FromSqlRaw<User>("SELECT * FROM Users WHERE Username = {0}", username).FirstOrDefaultAsync();
            
            int response = await _context.Database.ExecuteSqlRawAsync("INSERT INTO Subscriptions(GameID, UserID) VALUES({0},{1})", g.GameId, u.UserId);
            if (response != 1) return null;
            Subscription s = await _context.Subscriptions.FromSqlRaw<Subscription>("SELECT * FROM Subscriptions WHERE GameID = {0} AND UserID = {1}", g.GameId, u.UserId).FirstOrDefaultAsync();

            ViewSubscription vs = new ViewSubscription() {
                SubscriptionID = s.SubscriptionId,
                GameID = s.GameId,
                UserID = s.UserId
            };

            return vs;
        }

        public async Task<List<ViewGame>> UserSubscribedGamesAsync(string username) {
            //1st get the user id for the username
            User u = await _context.Users.FromSqlRaw<User>("SELECT * FROM Users WHERE Username = {0}", username).FirstOrDefaultAsync();
            //2nd get the subscriptions for the userID
            List<Subscription> subscriptions = await _context.Subscriptions.FromSqlRaw<Subscription>("SELECT * FROM Subscriptions WHERE UserID = {0}", u.UserId).ToListAsync();
            //make a list of Game based on the GameID from subscriptions
            List<int> gameIDs = new List<int>();
            foreach(Subscription s in subscriptions) {
                gameIDs.Add(s.GameId);
            }
            List<Game> games = new List<Game>();
            for(int i = 0; i < gameIDs.Count; i++) {
                Game curGame = await _context.Games.FromSqlRaw<Game>("SELECT * FROM Games WHERE GameID = {0}", gameIDs[i]).FirstOrDefaultAsync();
                games.Add(curGame);
            }
            List<ViewGame> viewGames = new List<ViewGame>();
            foreach(Game g in games) {
                //convert g into a view game
                ViewGame curViewGame = new ViewGame() {
                    GameID = g.GameId,
                    ExternalID = g.ExternalAPIGameId
                };
                //add the view game to viewGames
                viewGames.Add(curViewGame);
            }
            return viewGames;
        }
    }
}
