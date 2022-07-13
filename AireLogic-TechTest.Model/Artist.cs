namespace AireLogic_TechTest.Model
{
    public class Artist
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Typeid { get; set; }
        public int Score { get; set; }
        public string Genderid { get; set; }
        public string Name { get; set; }
        public string Sortname { get; set; }
        public string Gender { get; set; }
        public Area Area { get; set; }
        public BeginArea Beginarea { get; set; }
        public string[] Ipis { get; set; }
        public string[] Isnis { get; set; }
        public LifeSpan Lifespan { get; set; }
        public Alias[] Aliases { get; set; }
        public Tag[] Tags { get; set; }
    }


}
