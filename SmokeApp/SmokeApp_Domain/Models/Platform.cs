using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Domain.Models
{
  class Platform
  {
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }

    public string DOB { get; set; }
    public Platform()
    {

    }
  }
}
