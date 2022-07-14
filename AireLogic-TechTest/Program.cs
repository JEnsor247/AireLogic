using System;
using System.Collections.Generic;
using System.Linq;

namespace AireLogic_TechTest
{
    internal class Program
    {
        // This sets the number of songs that are returned by the query. This is set as 2 due to poor performance of the API
        public const int SongLimit = 2;
        public static string ArtistName { get; set; }
        public static List<string> WorkTitles = new List<string>();

        static void Main(string[] args)
        {
            GetUserInput();

            var artist = new Artists.Artist(ArtistName);
            var artistId = artist.GetArtistId();

            if (artist.ArtistName != default)
            {
                var artistsWorks = new Works.Works(artist.ArtistName);
                WorkTitles = artistsWorks.GetWorkTitles(artist, SongLimit);
                if (WorkTitles.Any())
                {
                    var songArtist = new Songs.Lyrics(artist.ArtistName);
                    var allSongsCounts = songArtist.GetAllLyricsCountsForSongs(WorkTitles.Distinct().ToList());
                    OutputResults(allSongsCounts);
                }
            }

            Exit();

        }

        private static void GetUserInput()
        {
            Console.Write("Please Enter an Artist Name: ");
            ArtistName = Console.ReadLine();
        }

        private static void Exit()
        {
            Console.WriteLine();
            Console.WriteLine("Press Any key to Exit");
            Console.ReadKey();
        }

        private static void OutputResults(Dictionary<string, int> allSongsCounts)
        {
            Console.WriteLine("");
            Console.WriteLine($"{"Song Title",-30} {"Count",-10}");

            foreach (var item in allSongsCounts)
            {
                Console.WriteLine($"{item.Key,-30} {item.Value,-10}");
            }

            var average = Calculations.Average(allSongsCounts.Sum(x => x.Value), SongLimit);
            Console.WriteLine("");
            Console.WriteLine($"Given that we have used {allSongsCounts.Count} songs, the average word count is {average} words per song");
        }
    }
}

