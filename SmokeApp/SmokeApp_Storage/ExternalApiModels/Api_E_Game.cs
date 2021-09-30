using System;
using Newtonsoft.Json;
using SmokeApp_Storage.Repositories;

namespace SmokeApp_Storage.ExternalApiModels
{
  public class Api_E_Game : Result
  {
        
    [JsonProperty("id")]    
    public int? id { get; set; }
    [JsonProperty("name")]  
    public string name { get; set; }
    [JsonProperty("description")] 
    public string description { get; set; }
    [JsonProperty("released")] 
    public string released { get; set; }
    [JsonProperty("background_image")] 
    public string background_image { get; set; }
    [JsonProperty("rating")] 
    public string rating { get; set; }
    [JsonProperty("platforms")] 
    public Object[] platforms { get; set; }
    public Api_E_Game(int ID, string Name, string Description, string Released, string backgroundImage, string Rating)
    {
            id = ID;
            name = Name;
            description = Description;
            released = Released;
            background_image = backgroundImage;
            rating = Rating;
        }

   public override string ToString()
   {
            string release = GetValue(released);

            return $"Title: {name}\n" +
                $"ID: {id}\n" +
                $"Released: {release}";
    }




    }
}