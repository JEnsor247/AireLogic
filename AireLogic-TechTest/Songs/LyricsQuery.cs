using AireLogic_TechTest.Interfaces;

namespace AireLogic_TechTest.Artists
{
    internal class LyricsQuery : IQueryString
    {
        private string artistName { get; set; }
        private string songTitle { get; set; }
        public LyricsQuery(string artistName, string songTitle)
        {
            this.artistName = artistName;
            this.songTitle = songTitle;
        }
        public string QueryString()
        {
            return $"{artistName}/{songTitle}";
        }

        public string QueryString(int offset)
        {
            // Not ideal to have this, look to alter the interface to make it more suitable for all
            throw new System.NotImplementedException();
        }
    }
}
