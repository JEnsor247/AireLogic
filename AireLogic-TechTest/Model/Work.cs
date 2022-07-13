namespace AireLogic_TechTest.Model
{
    public class Work
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int Score { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string[] Iswcs { get; set; }
        public Alias[] Aliases { get; set; }
        public Relation[] Relations { get; set; }
        public string[] Languages { get; set; }
    }

}
