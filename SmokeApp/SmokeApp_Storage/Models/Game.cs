using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class Game
    {
        public Game()
        {
            GamesPlatforms = new HashSet<GamesPlatform>();
            Subscriptions = new HashSet<Subscription>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }

        public virtual ICollection<GamesPlatform> GamesPlatforms { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
