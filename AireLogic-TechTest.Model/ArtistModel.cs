using System;

namespace AireLogic_TechTest.Model
{

    public class ArtistModel
    {
        public DateTime Created { get; set; }
        public int Count { get; set; }
        public int Offset { get; set; }
        public Artist[] Artists { get; set; }
    }
}
