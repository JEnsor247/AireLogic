using AireLogic_TechTest.Interfaces;

namespace AireLogic_TechTest.Artists
{
    internal class WorkQuery : IQueryString, IQueryLimit
    {
        private string artistId { get; set; }
        private int queryLimit { get; set; }
        public WorkQuery(string artistId, int queryLimit)
        {
            this.artistId = artistId;
            this.queryLimit = queryLimit;
        }
        public string QueryString()
        {
            return $"work?query=arid:{artistId};limit={queryLimit}";
        }
        public string QueryString(int offset)
        {
            return $"work?query=arid:{artistId};limit={queryLimit};offset={offset}";
        }
        public int QueryLimit()
        {
            return queryLimit;
        }

    }
}
