using AireLogic_TechTest.Interfaces;

namespace AireLogic_TechTest
{
    internal class ArtistRequest : IHttpRequest
    {
        public string BaseUrl { get => "https://musicbrainz.org/ws/2/"; }
    }
}
