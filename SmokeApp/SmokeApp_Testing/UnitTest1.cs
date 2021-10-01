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
    public class UnitTest1 {

        public DbContextOptions<SmokeDBContext> options { get; set; } = new DbContextOptionsBuilder<SmokeDBContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        [Fact]
        public async void Test1() {
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

                List<ViewUser> result = await ur.UserListAsync();

                Assert.Equal(3, result.Count);
                Assert.True(result.Count == 3);
                Assert.True(result[2].FirstName == "Joe");
                Assert.Contains("oe", result[2].FirstName);

            }

        }
    }
}
