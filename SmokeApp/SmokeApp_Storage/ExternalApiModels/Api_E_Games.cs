using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmokeApp_Storage.Repositories;

namespace SmokeApp_Storage.ExternalApiModels
{
  public class Api_E_Games : Result
  {
    public int? Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Released { get; }
    public string BackgroundImage { get; }
    public string Rating { get; }
    public Object Platforms { get; }

        private int count;

    public Api_E_Games(int? id = null, string name = null, string description = null, string released = null, string backgroundImage = null, string rating = null, dynamic[] platforms = null)
    {
      Id = id;
      Name = name;
      Description = description;
      Released = released;
      BackgroundImage = backgroundImage;
      Rating = rating;
      Platforms = platforms;
            client = RawgRepository.Instance;

    }

    public async Task<Api_E_Game[]> GetGamesAsync()
    {
      Api_E_Game games = await client.SendRequestAsync<Api_E_Game>(RawgRepository.Endpoint + $"games/1?key={client.apiKey}");
      return games.Initialize();
    }

        //internal Api_E_Game[] Initialize()
        //{
        //    if (count <= 0)
        //        return null;

        //    var dlcs = new Api_E_Game[count];
        //    game[0] = this;
        //    for (int i = 1; i < count; i++)
        //        game[i] = new Api_E_Game(count, i, data);
        //    return dlcs;
        //}

        static async Task SearchGames()
    {

    }
  }
}
