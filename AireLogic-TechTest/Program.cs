using System;
using System.Collections.Generic;
using System.Linq;

namespace AireLogic_TechTest
{
    internal class Program
    {
        public static string ArtistName { get; set; }
        public const int SongLimit = 2;
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
                    Console.WriteLine("");
                    Console.WriteLine($"{"Song Title", -30} {"Count", -10}");

                    foreach (var item in allSongsCounts)
                    {
                        Console.WriteLine($"{item.Key, -30} {item.Value, -10}");
                    }

                    var average = Calculations.Average(allSongsCounts.Sum(x => x.Value), SongLimit);
                    Console.WriteLine("");
                    Console.WriteLine($"Given that we have used {allSongsCounts.Count} songs, the average word count is {average} words per song");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press Any key to Exit");
            Console.ReadKey();

        }
    }
}

