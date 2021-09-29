using SmokeApp_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Interfaces {
    public interface IUserRepo {

        Task<List<ViewUser>> UserListAsync();

        Task<ViewUser> LoginUserAsync(ViewUser vu);
    }
}
