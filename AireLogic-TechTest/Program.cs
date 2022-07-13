using AireLogic_TechTest.Artists;
using AireLogic_TechTest.Interfaces;
using AireLogic_TechTest.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace AireLogic_TechTest
{
    internal class Program
    {
        public static string ArtistName { get; set; }
        public const int SongLimit = 50;
        public static List<string> WorkTitles = new List<string>();

        static void Main(string[] args)
        {

            Console.Write("Please Enter an Artist Name: ");
            ArtistName = Console.ReadLine();

            var artist = new Artists.Artist(ArtistName);
            var artistId = artist.GetArtistId();

            if (artist.ArtistName != default)
            {
                var artistsWorks = new Works.Works(artist.ArtistName);
                WorkTitles = artistsWorks.GetWorkTitles(artist, SongLimit);
                if (WorkTitles.Any())
                {
                    List<string> songTitles = new List<string>(WorkTitles.Distinct());

                    var songArtist = new Songs.Lyrics(artist.ArtistName);
                    var allSongsCounts = songArtist.GetAllLyricsCountsForSongs(WorkTitles);

                    foreach (var item in allSongsCounts)
                    {
                        Console.WriteLine($"{item.Key, -30} {item.Key, -10}");
                    }

                    var average = allSongsCounts.Sum(x => x.Value) / SongLimit;
                    Console.WriteLine($"Given that we have used {allSongsCounts.Count} songs, the average word count is {average}");
                }
            }

        }
    }
}

