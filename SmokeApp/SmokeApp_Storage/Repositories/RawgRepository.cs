using SmokeApp_Storage.ExternalApiModels;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Repositories
{
  public class RawgRepository
  {
    private static RawgRepository _rawgRepository;
    private readonly HttpClient client;
    internal const string Endpoint = "https://api.rawg.io/api/";
    private static readonly string apiKey = "529258b2f69a47c79b806e2c88a9c75f";


    public static RawgRepository Instance
    {
      get
      {
        if (_rawgRepository == null)
        {
          _rawgRepository = new RawgRepository();
        }

        return _rawgRepository;
      }
    }

    public RawgRepository()
    {
      client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
    }

    public static async Task searchGamesAsync(string path)
    {
      Api_E_Games games = null;
      HttpRequestMessage request = new HttpRequestMessage();
      request.RequestUri = uri;
      request.Method = HttpMethod.Get;
      request.Headers.Add("api_Key", apiKey);
      HttpResponseMessage response = await client.GetAsync(request);


    }

    static async Task RunAsync()
    {
      client.BaseAddress = new Uri("http://localhost/4200");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(
          new MediaTypeWithQualityHeaderValue("application/json"));
    }
  }
}