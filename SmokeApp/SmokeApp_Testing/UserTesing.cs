using Microsoft.EntityFrameworkCore;
using SmokeApp_Storage.Models;
using SmokeApp_Storage;
using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using SmokeApp_Storage.Repositories;
using SmokeApp_Domain.Models;

namespace SmokeApp_Testing {
    public class UserTesing {

        public DbContextOptions<SmokeDBContext> options { get; set; } = new DbContextOptionsBuilder<SmokeDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        
        [Fact]
        public async void Test1() {
            using (SmokeDBContext _context = new SmokeDBContext(options)) {

                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                //User u1 = new User() { UserId = 1, FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                //User u2 = new User() { UserId = 2, FirstName = "Tim", LastName = "Mary", Email = "timmary@yahoo.com", Dob = DateTime.Now, Username = "tim.mary", Password = "password" };
                //User u3 = new User() { UserId = 3, FirstName = "Joe", LastName = "Anne", Email = "joeanne@yahoo.com", Dob = DateTime.Now, Username = "joe.anne", Password = "password" };
                User u1 = new User() { FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                User u2 = new User() { FirstName = "Tim", LastName = "Mary", Email = "timmary@yahoo.com", Dob = DateTime.Now, Username = "tim.mary", Password = "password" };
                User u3 = new User() { FirstName = "Joe", LastName = "Anne", Email = "joeanne@yahoo.com", Dob = DateTime.Now, Username = "joe.anne", Password = "password" };
                _context.Users.Add(u1);
                _context.Users.Add(u2);
                _context.Users.Add(u3);
                _context.SaveChanges();

                UserRepo ur = new UserRepo(_context);

                List<ViewUser> result = await ur.UserListAsync();

                Assert.Equal(3, result.Count);
                Assert.True(result.Count == 3);
                Assert.True(result[2].FirstName == "Joe");
                Assert.Contains("oe", result[2].FirstName);

            }
        }
        [Fact]
        public async void TestLoginUserReturnsTheLoggedInUser() {
            using (SmokeDBContext _context = new SmokeDBContext(options)) {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                User u1 = new User() { UserId = 1, FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                User u2 = new User() { UserId = 2, FirstName = "Tim", LastName = "Mary", Email = "timmary@yahoo.com", Dob = DateTime.Now, Username = "tim.mary", Password = "password" };
                User u3 = new User() { UserId = 3, FirstName = "Joe", LastName = "Anne", Email = "joeanne@yahoo.com", Dob = DateTime.Now, Username = "joe.anne", Password = "password" };
                ViewUser vu = new ViewUser() { FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Username = "bill.steve", Password="password"};
                _context.Users.Add(u1);
                _context.Users.Add(u2);
                _context.Users.Add(u3);
                _context.SaveChanges();

                UserRepo ur = new UserRepo(_context);

                ViewUser result = await ur.LoginUserAsync(vu);

                Assert.True(result.FirstName == "Bill" && result.LastName == "Steve");
            }
        }

        [Fact]
        public async void TestFailedUserLogin() {
            using (SmokeDBContext _context = new SmokeDBContext(options)) {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                User u1 = new User() { UserId = 1, FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                User u2 = new User() { UserId = 2, FirstName = "Tim", LastName = "Mary", Email = "timmary@yahoo.com", Dob = DateTime.Now, Username = "tim.mary", Password = "password" };
                User u3 = new User() { UserId = 3, FirstName = "Joe", LastName = "Anne", Email = "joeanne@yahoo.com", Dob = DateTime.Now, Username = "joe.anne", Password = "password" };
                ViewUser vu = new ViewUser() { FirstName = "Sam", LastName = "Mike", Email = "sammike@yahoo.com", Username = "sam.mike", Password = "stuffstuff" };
                _context.Users.Add(u1);
                _context.Users.Add(u2);
                _context.Users.Add(u3);
                _context.SaveChanges();

                UserRepo ur = new UserRepo(_context);

                ViewUser result = await ur.LoginUserAsync(vu);

                Assert.True(result.Username != "sam.mike");
            }
        }
        
        [Fact]
        public async void TestFailedToRegisterUser() {
            using (SmokeDBContext _context = new SmokeDBContext(options)) {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                User u1 = new User() { UserId = 1, FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                User u2 = new User() { UserId = 2, FirstName = "Tim", LastName = "Mary", Email = "timmary@yahoo.com", Dob = DateTime.Now, Username = "tim.mary", Password = "password" };
                User u3 = new User() { UserId = 3, FirstName = "Joe", LastName = "Anne", Email = "joeanne@yahoo.com", Dob = DateTime.Now, Username = "joe.anne", Password = "password" };
                ViewUser vu = new ViewUser() { FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                _context.Users.Add(u1);
                _context.Users.Add(u2);
                _context.Users.Add(u3);
                _context.SaveChanges();

                UserRepo ur = new UserRepo(_context);

                ViewUser result = await ur.RegisterUserAsync(vu);

                Assert.True(result == null);
            }
        }

        [Fact]
        public async void TestSuccessfulRegisterUser() {
            using (SmokeDBContext _context = new SmokeDBContext(options)) {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                User u1 = new User() { UserId = 1, FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                User u2 = new User() { UserId = 2, FirstName = "Tim", LastName = "Mary", Email = "timmary@yahoo.com", Dob = DateTime.Now, Username = "tim.mary", Password = "password" };
                User u3 = new User() { UserId = 3, FirstName = "Joe", LastName = "Anne", Email = "joeanne@yahoo.com", Dob = DateTime.Now, Username = "joe.anne", Password = "password" };
                ViewUser vu = new ViewUser() { FirstName = "Sam", LastName = "Mike", Email = "sammike@yahoo.com", Username = "sam.mike", Password = "password" };
                _context.Users.Add(u1);
                _context.Users.Add(u2);
                _context.Users.Add(u3);
                _context.SaveChanges();

                UserRepo ur = new UserRepo(_context);

                ViewUser result = await ur.RegisterUserAsync(vu);

                Assert.True(result != null);
            }
        }
        
        [Fact]
        public void TestUserToViewUser() {
            using (SmokeDBContext _context = new SmokeDBContext(options)) {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                //User u1 = new User() { UserId = 1, FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                //User u2 = new User() { UserId = 2, FirstName = "Tim", LastName = "Mary", Email = "timmary@yahoo.com", Dob = DateTime.Now, Username = "tim.mary", Password = "password" };
                //User u3 = new User() { UserId = 3, FirstName = "Joe", LastName = "Anne", Email = "joeanne@yahoo.com", Dob = DateTime.Now, Username = "joe.anne", Password = "password" };
                User stuff = new User() { UserId = 1, FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                //_context.Users.Add(u1);
                //_context.Users.Add(u2);
                //_context.Users.Add(u3);
                _context.Users.Add(stuff);
                _context.SaveChanges();

                UserRepo ur = new UserRepo(_context);

                ViewUser result = ur.EFToView(stuff);

                Assert.True(result is ViewUser);
            }
        }

        [Fact]
        public async void TestViewUserToUser() {
            using (SmokeDBContext _context = new SmokeDBContext(options)) {
                _context.Database.EnsureDeleted();
                _context.Database.EnsureCreated();

                User u1 = new User() { UserId = 1, FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Dob = DateTime.Now, Username = "bill.steve", Password = "password" };
                User u2 = new User() { UserId = 2, FirstName = "Tim", LastName = "Mary", Email = "timmary@yahoo.com", Dob = DateTime.Now, Username = "tim.mary", Password = "password" };
                User u3 = new User() { UserId = 3, FirstName = "Joe", LastName = "Anne", Email = "joeanne@yahoo.com", Dob = DateTime.Now, Username = "joe.anne", Password = "password" };
                _context.Users.Add(u1);
                _context.Users.Add(u2);
                _context.Users.Add(u3);
                _context.SaveChanges();

                UserRepo ur = new UserRepo(_context);
                ViewUser vu = new ViewUser() { FirstName = "Bill", LastName = "Steve", Email = "billsteve@yahoo.com", Username = "bill.steve", Password = "password" };

                User result = await ur.ViewToEF(vu);

                Assert.True(result is User);
            }
        }



    }//EOC
}//EON
