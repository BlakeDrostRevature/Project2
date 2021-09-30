using System;
using Microsoft.EntityFrameworkCore;
using SmokeApp_Storage.Models;
using Serilog;
using Xunit;
//using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace SmokeAppConsoleForTesting
{
  class Program
  {
    static void Main(string[] args)
    {



      using (SmokeDBContext context = new SmokeDBContext())
      {
        var users = context.Users.FromSqlRaw<User>("SELECT * FROM Users").ToList();

        foreach (var x in users)
        {
          Console.WriteLine($"The Users in the Database are FirstName: {x.FirstName} LastName: {x.LastName} Email: {x.Email} DOB: {x.Dob}");
        }
      }

      Console.WriteLine("Hello World!");
    }
        /*
    [Fact]
    public async Task Test1()
    {
      Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();
      apiKey = "529258b2f69a47c79b806e2c88a9c75f";

      client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
      client.DefaultRequestHeaders.Add("Api_Key", apiKey);
      client.Timeout = TimeSpan.FromMinutes(10);

      Api_E_Game games = await SendRequestAsync<Api_E_Game>(Endpoint + $"games?key={apiKey}");

    }*/

  }
}
