namespace AireLogic_TechTest.Model
{
    public class Work
    {
        public string id { get; set; }
        public string type { get; set; }
        public int score { get; set; }
        public string title { get; set; }
        public string language { get; set; }
        public string[] iswcs { get; set; }
        public Alias[] aliases { get; set; }
        public Relation[] relations { get; set; }
        public string[] languages { get; set; }
    }

}
