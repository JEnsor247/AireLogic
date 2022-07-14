using AireLogic_TechTest.Artists;
using AireLogic_TechTest.Interfaces;
using AireLogic_TechTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AireLogic_TechTest.Works
{
    public class Works
    {
        private string ArtistName {get; set;}

        public static List<string> SongTitles = new List<string>();

        public Works(string artistName)
        {
            ArtistName = artistName;
        }

        internal List<string> GetWorkTitles(Artists.Artist artist, int noSongTitles)
        {
            IQueryString query = new WorkQuery(artist.GetArtistId(), noSongTitles);
            GetWorksInformation(query).Wait();
            return SongTitles;
        }
        async Task GetWorksInformation(IQueryString query)
        {
            Console.WriteLine($"Getting Related Works by {ArtistName}");
            using (var client = new HttpBase(new ArtistRequest()).HttpClient)
            {
                var response = await ModelBase.GetResponse(client, query.QueryString());
                if (response.IsSuccessStatusCode)
                {
                    var initialResult = ModelBase.Deserialize<WorkModel>(response).Result;
                    
                    // Potentially add in batching here to get all results from response, 
                    // instead of giving user the option
                    //var batchSize = 25;

                    //Console.WriteLine($"We found a total of {initialResult.Count} results. NOTE:Duplicates will be removed.");
                    //for (int y = 0; y < Math.Ceiling((decimal)initialResult.Count / batchSize); y++)
                    //{
                    //    var splitResponse = await ModelBase.GetResponse(client, query.QueryString(batchSize));
                    //    var result = ModelBase.Deserialize<WorkModel>(response).Result;

                        foreach (var item in initialResult.Works.Distinct().ToList())
                        {
                            SongTitles.Add(item.Title);
                            Console.WriteLine($"Adding Song \"{item.Title}\" to our process list");
                        }
                 //   }
                    Console.WriteLine($"Now processing lyrics for the songs");
                }
                else
                {
                    Console.WriteLine($"Unable to find the Works for {ArtistName}");
                }
            }
        }
    }
}
