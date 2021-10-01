using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class Game
    {
        public Game()
        {
            Subscriptions = new HashSet<Subscription>();
        }

        public int GameId { get; set; }
        public int ExternalAPIGameId { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
