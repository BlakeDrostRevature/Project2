using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Repositories
{
  public class RawgRepository
  {
    public string apiKey { get; set; }
    private static RawgRepository _rawgRepository;
    private readonly HttpClient client;
    internal const string Endpoint = "https://api.rawg.io/api/";


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
      apiKey = "529258b2f69a47c79b806e2c88a9c75f";

      client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip });
      client.DefaultRequestHeaders.Add("Api_Key", apiKey);
            client.Timeout = TimeSpan.FromMinutes(10);
    }

    // public static async Task searchGamesAsync(string path)
    // {
    //   Api_E_Games games = null;
    //   HttpRequestMessage request = new HttpRequestMessage();
    //   request.RequestUri = uri;
    //   request.Method = HttpMethod.Get;
    //   request.Headers.Add("api_Key", apiKey);
    //   HttpResponseMessage response = await client.GetAsync(request);


    // }


    internal async Task<T> SendRequestAsync<T>(string query) where T : Result
    {
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, query);
            Console.WriteLine(request.ToString());
            Console.WriteLine(request.RequestUri.AbsoluteUri);

            HttpResponseMessage response = await client.SendAsync(request);
            //HttpResponseMessage response = await client.GetAsync(request.RequestUri.AbsoluteUri);
            //HttpResponseMessage response = await client.GetStreamAsync(request.RequestUri);

            Console.WriteLine("something");
      if (response.StatusCode == HttpStatusCode.NotFound)
        return new Result().Initialize(response.StatusCode, this) as T;

      string content = await response.Content.ReadAsStringAsync();
      var data = JsonConvert.DeserializeObject<dynamic>(content);

      try
      {
        bool redirect = data.redirect;
        return await SendRequestAsync<T>(Endpoint + $"games/{data.slug}");
      }
      catch
      {
        return JsonConvert.DeserializeObject<T>(content).Initialize(HttpStatusCode.OK, this) as T;
      }
    }

    // static async Task RunAsync()
    // {
    //   client.BaseAddress = new Uri("http://localhost/4200");
    //   client.DefaultRequestHeaders.Accept.Clear();
    //   client.DefaultRequestHeaders.Accept.Add(
    //       new MediaTypeWithQualityHeaderValue("application/json"));
    // }
  }
}