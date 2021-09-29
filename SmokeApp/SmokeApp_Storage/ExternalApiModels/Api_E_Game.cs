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

    private int index;
    private int count;
    private dynamic data;

        public Api_E_Game(int count = 0, int index = 0, params dynamic[] results/*int? id = null, string name = null, string description = "", string released = null, string backgroundImage = null, string rating = null, dynamic[] platforms = null*/)
        {
            //Id = id;
            //Name = name;
            //Description = description;
            //Released = released;
            //BackgroundImage = backgroundImage;
            //Rating = rating;
            //Platforms = platforms;

            if (count <= 0)
                return;

            this.count = count;
            data = results;


            Name = data[index].name;
            Id = data[index].id;
            //Released = DateTime.TryParse(data[index].released.ToString(), out DateTime time) ? time as DateTime? : null;

        }
      

        /// <summary>
        ///     Gets list of games
        /// </summary>
        /// <returns>An array of games</returns>
        internal Api_E_Game[] Initialize()
        {
            if (count <= 0)
                return null;

            var games = new Api_E_Game[count];
            games[0] = this;

            for (int i = 1; i < count; i++)
             games[i] = new Api_E_Game(count, i, data);
            return games;
        }

        public override string ToString()
        {
            string release = GetValue(Released);

            return $"Title: {Name}\n" +
                $"ID: {Id}\n" +
                $"Released: {release}";
        }
    }
}