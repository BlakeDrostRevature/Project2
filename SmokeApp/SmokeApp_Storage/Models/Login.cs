using System;
using System.Collections.Generic;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
