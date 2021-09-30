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
            User u1 = await _context.Users.FromSqlRaw<User>("SELECT * FROM Users WHERE Username = {0} AND [Password] = {1}", vu.Username, vu.Password).FirstOrDefaultAsync();
            Console.WriteLine(u1.LastName);
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
    }
}
