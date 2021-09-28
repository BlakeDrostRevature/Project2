using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeApp_Storage.ExternalApiModels
{
  public class Api_E_Games
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Released { get; set; }
    public string BackgroundImage { get; set; }
    public string Rating { get; set; }
    public Object[] Platforms { get; set; }

    static async Task SearchGames()
    {

    }
  }
}
