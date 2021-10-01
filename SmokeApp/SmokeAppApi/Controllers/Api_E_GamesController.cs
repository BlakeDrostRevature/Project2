using Microsoft.AspNetCore.Mvc;
using SmokeApp_Domain.Models;
using SmokeApp_Storage.ExternalApiModels;
using SmokeApp_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmokeApp_Storage.Repositories;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmokeAppApi.Controllers
{

  [Route("[controller]")]
  [ApiController]
  public class Api_E_GamesController : ControllerBase
  {
    private static readonly RawgRepository rawgRepo = RawgRepository.Instance;
    private const string _logFilePath = @"..\data\log.txt";

        // GET: api/<Api_E_GamesController>

        [HttpGet ("allgames")]
    public async Task<Api_E_Game[]> GetGamesAsync()
    {
        Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();
        var games = await rawgRepo.GetGamesAsync();
        if (games != null) Log.Information("Games Successfully Retrieved");
        else Log.Information("Games not Successfully Retrieved");
        return games;


    }

    // GET api/<Api_E_GamesController>/5
    [HttpGet("{id}")]
    public async Task<Api_E_Game> GetGameAsync(int id)
    {
       Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();
      //Task<List<ViewUser>> users = rawgRepo.SendRequestAsync<ViewUser>();
     // List<ViewUser> users1 = await users;
      var games = await rawgRepo.GetGameAsync(id);
      if (games != null) Log.Information("Game Successfully Retrieved");
      else Log.Information("Game not Successfully Retrieved");
      return games;
      //return "value";
    }

    // POST api/<Api_E_GamesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<Api_E_GamesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<Api_E_GamesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
