using SmokeApp_Domain.Models;
using SmokeApp_Storage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Testing {
    class UserRepoMock : IUserRepo{
        public Task<ViewUser> LoginUserAsync(ViewUser vu) {
            throw new NotImplementedException();
        }

        public Task<ViewUser> RegisterUserAsync(ViewUser vu) {
            throw new NotImplementedException();
        }

        public Task<List<ViewUser>> UserListAsync() {
            List<ViewUser> vuMock = new List<ViewUser>();
            vuMock.Add(new ViewUser() {UserId=1,FirstName="Bill",LastName="Steve",Email="billsteve@yahoo.com",Dob=DateTime.Now,Username="bill.steve",Password="password" });
            return Task.FromResult(vuMock);
        }
    }
}
