using System;
using SmokeApp_Storage.Repositories;

namespace SmokeApp_Storage.ExternalApiModels
{
  public class Api_E_Game : Result
  {
        

    public int? Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Released { get; }
    public string BackgroundImage { get; }
    public string Rating { get; }
    public Object[] Platforms { get; }


        public override string ToString()
        {
            string release = GetValue(Released);

            return $"Title: {Name}\n" +
                $"ID: {Id}\n" +
                $"Released: {release}";
        }
    }
}