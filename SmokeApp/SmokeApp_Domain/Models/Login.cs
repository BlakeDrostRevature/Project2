using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Domain.Models
{
  class Login
  {
    public int UserName { get; set; }
    public string Password { get; set; }

    public string PasswordHash { get; set; }
    public int UserID { get; set; }
    public Login()
    {

    }
  }
}
