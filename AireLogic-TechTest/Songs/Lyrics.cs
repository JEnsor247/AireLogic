using AireLogic_TechTest.Artists;
using AireLogic_TechTest.Interfaces;
using AireLogic_TechTest.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AireLogic_TechTest.Songs
{
    public class Lyrics
    {
        public string Artist { get; set; }
        private Dictionary<string, int> WordCountBySong;
        private string Title { get; set; }
        private int WordCount { get; set; }

        public Lyrics(string artist)
        {
            Artist = artist;
        }

        public Dictionary<string, int> GetAllLyricsCountsForSongs(List<string> songTitles)
        {
            WordCountBySong = new Dictionary<string, int>();    
            foreach (var title in songTitles)
            {
                var currentSong = new Lyrics(Artist);
                currentSong.Title = title;
                currentSong.GetLyrics(title);
                if(currentSong.WordCount > 0)
                {
                    WordCountBySong.Add(currentSong.Title, currentSong.WordCount);
                }
                
            }

            return WordCountBySong;
        }
        public void GetLyrics(string songTitle)
        {
            var lyrics = new LyricsQuery(Artist, songTitle);
            GetLyricsInformation(lyrics, songTitle).Wait();
        }
        async Task GetLyricsInformation(IQueryString query, string songTitle)
        {
            using (var client = new HttpBase(new LyricRequest()).HttpClient)
            {
                var response = await ModelBase.GetResponse(client, query.QueryString());
                if (response.IsSuccessStatusCode)
                {
                    var result = ModelBase.Deserialize<Model.Songs>(response).Result;
                    string[] Lyrics = SplitLyricsByCharacter(result);

                    WordCount = Lyrics.Length;

                }
                else
                {
                    Console.WriteLine($"Unable to find lyrics for the song \"{songTitle}\" for {Artist}");
                }
            }


        }

        public static string[] SplitLyricsByCharacter(Model.Songs result, char splitChar = ' ')
        {
            return result.Lyrics.Split(splitChar);
        }
    }
}
