namespace AireLogic_TechTest.Model
{
    public class Relation
    {
        public string type { get; set; }
        public string typeid { get; set; }
        public string direction { get; set; }
        public Artist artist { get; set; }
        public Recording recording { get; set; }
    }

}
