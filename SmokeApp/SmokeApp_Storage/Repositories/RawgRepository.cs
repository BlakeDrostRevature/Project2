using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmokeApp_Storage.ExternalApiModels;
using SmokeApp_Storage.Models;
using System;
using System.Linq;
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
    public dynamic data { get; private set; }


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


    public async Task<string> SendRequestAsync<T>(string query) where T : Result
    {
      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, query);

      HttpResponseMessage response = await client.SendAsync(request);
      //HttpResponseMessage response = await client.GetAsync(request.RequestUri.AbsoluteUri);
      //HttpResponseMessage response = await client.GetStreamAsync(request.RequestUri);

     // if (response.StatusCode == HttpStatusCode.NotFound)
     //   return new Result().Initialize(response.StatusCode, this) as T;

      string content = await response.Content.ReadAsStringAsync();
            JObject obj = JObject.Parse(content);
           
           
            data = JsonConvert.DeserializeObject<dynamic>(content);
            return content;//.Initialize(HttpStatusCode.OK, this) as T;
      /*try
      {
        bool redirect = data.redirect;
        return await SendRequestAsync<T>(Endpoint + $"games/{data.slug}");
      }
      catch
      {
        JObject jObject = JObject.Parse(content);
        JToken jGame = jObject["game"];
        var test = JsonConvert.DeserializeObject<Api_E_Game>(content);
                // T temp = test.Initialize(HttpStatusCode.OK, this) as T;
                return content;//.Initialize(HttpStatusCode.OK, this) as T;
      }*/


    }

    
        public async Task<Api_E_Game[]> GetGamesAsync()
        {

            string games = await SendRequestAsync<Api_E_Game>(Endpoint + $"games?key={apiKey}");
            Api_E_Game[] returnArray = new Api_E_Game[20];
            
            JObject obj = JObject.Parse(games);

            JToken[] temp = obj["results"].ToArray();
            int count = temp.Length;
            
            for(int i = 0; i < count; i++)
            {            
            var jtoken = obj["results"][i].ToString();

            var returnobj = JsonConvert.DeserializeObject<dynamic>(jtoken);
            var tempo = returnobj["id"];
            var id = Int32.Parse(tempo.ToString());
            returnArray[i] = new Api_E_Game(id, Convert.ToString(returnobj["name"]), Convert.ToString(returnobj["description"]),
            Convert.ToString(returnobj["released"]), Convert.ToString(returnobj["background_image"]), Convert.ToString(returnobj["rating"]));
            }
            
            return returnArray;//.Initialize();
        }

        public async Task<Api_E_Game> GetGameAsync(int ID)
        {

            string games = await SendRequestAsync<Api_E_Game>(Endpoint + $"games/{ID}?key={apiKey}");
            Api_E_Game returnGame;

            JObject obj = JObject.Parse(games);      

            var jtoken = obj.ToString();

            var returnobj = JsonConvert.DeserializeObject<dynamic>(jtoken);
            var tempo = returnobj["id"];
            var id = Int32.Parse(tempo.ToString());
            returnGame = new Api_E_Game(id, Convert.ToString(returnobj["name"]), Convert.ToString(returnobj["description"]),
            Convert.ToString(returnobj["released"]), Convert.ToString(returnobj["background_image"]), Convert.ToString(returnobj["rating"]));
            

            return returnGame;//.Initialize();
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