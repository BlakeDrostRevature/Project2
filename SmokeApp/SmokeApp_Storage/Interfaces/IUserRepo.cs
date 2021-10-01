using SmokeApp_Domain.Models;
using SmokeApp_Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Interfaces {
    public interface IUserRepo {

        Task<List<ViewUser>> UserListAsync();

        Task<ViewUser> LoginUserAsync(ViewUser vu);

        Task<ViewUser> RegisterUserAsync(ViewUser vu);

        Task<ViewSubscription> SubscribeToAGame(int aGameID, string username);

        Task<List<ViewGame>> UserSubscribedGamesAsync(string username);
    }
}
