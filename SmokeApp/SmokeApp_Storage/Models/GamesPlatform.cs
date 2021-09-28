using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class GamesPlatform
    {
        public int GamePlatformId { get; set; }
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        public virtual Game Game { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
