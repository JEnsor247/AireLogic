using AireLogic_TechTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireLogic_TechTest.Artists
{
    internal class ArtistQuery : IQueryString, IQueryLimit
    {
        private string artistName { get; set; }
        private int queryLimit { get; set; }
        public ArtistQuery(string artistName, int queryLimit)
        {
            this.artistName = artistName;
            this.queryLimit = queryLimit;
        }
        public string QueryString()
        {
            return $"artist/?query=artist:\"{artistName}\"&limit={queryLimit}";
        }
        public int QueryLimit()
        {
            return queryLimit;
        }

        public string QueryString(int offset)
        {
            return $"artist/?query=artist:\"{artistName}\"&limit={queryLimit}&offset={offset}";
        }
    }
}
