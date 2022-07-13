using AireLogic_TechTest.Artists;
using AireLogic_TechTest.Interfaces;
using AireLogic_TechTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    var batchSize = 25;

                    for (int y = 0; y < Math.Ceiling((decimal)initialResult.count / batchSize); y++)
                    {
                        var splitResponse = await ModelBase.GetResponse(client, query.QueryString(batchSize));
                        var result = ModelBase.Deserialize<WorkModel>(response).Result;

                        foreach (var item in result.works.Distinct().ToList())
                        {
                            SongTitles.Add(item.title);
                        }
                    }

                    //foreach (var item in result.works.Distinct().ToList())
                    //{
                    //    SongTitles.Add(item.title);
                    //}
                    Console.WriteLine($"We found a total of {SongTitles.Count}");
                }
                else
                {
                    Console.WriteLine($"Unable to find the Works for {ArtistName}");
                }
            }
        }
    }
}
