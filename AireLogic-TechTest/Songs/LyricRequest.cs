using AireLogic_TechTest.Interfaces;

namespace AireLogic_TechTest
{
    internal class LyricRequest : IHttpRequest
    {
        public string BaseUrl { get => "https://api.lyrics.ovh/v1/"; }
    }
}
