using SmokeApp_Storage.ExternalApiModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SmokeApp_Storage.Repositories
{
  public class RawgRepository
  {
        private static RawgRepository _rawgRepository;
        private static readonly HttpClient client = new HttpClient();


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

        public static async Task searchGamesAsync(string path)
    {
            Api_E_Games games = null;
            HttpResponseMessage response = await client.GetAsync(path);
          
            
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