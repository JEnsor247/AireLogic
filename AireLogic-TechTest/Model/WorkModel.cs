using System;

namespace AireLogic_TechTest.Model
{
    public class WorkModel : ModelBase
    {
        public DateTime Created { get; set; }
        public int Count { get; set; }
        public int Offset { get; set; }
        public Work[] Works { get; set; }
    }
}
