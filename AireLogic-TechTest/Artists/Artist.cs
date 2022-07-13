using AireLogic_TechTest.Interfaces;
using AireLogic_TechTest.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AireLogic_TechTest.Artists
{
    internal class Artist
    {
        public string ArtistName { get; set; }
        private string ArtistId { get; set; }
        public Artist(string artistName)
        {
            ArtistName = artistName;
        }

        public string GetArtistId()
        {
            IQueryString artistQuery = new ArtistQuery(ArtistName, 1);

            GetArtistInformation(artistQuery).Wait();
            return ArtistId;
        }
        private async Task GetArtistInformation(IQueryString query)
        {
            using (var client = new HttpBase(new ArtistRequest()).HttpClient)
            {
                var response = await ModelBase.GetResponse(client, query.QueryString());
                if (response.IsSuccessStatusCode)
                {
                    var result = ModelBase.Deserialize<ArtistModel>(response).Result;
                    var artist = result.Artists.FirstOrDefault();
                    ArtistId = artist.Id;
                    ArtistName = artist.Name;
                }
                else
                {
                    Console.WriteLine($"Unable to find the Artist {ArtistName}");
                }
            }
        }
    }
}
