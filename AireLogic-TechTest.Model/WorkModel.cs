using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AireLogic_TechTest.Model
{

    public class WorkModel : ModelBase
    {
        public DateTime created { get; set; }
        public int count { get; set; }
        public int offset { get; set; }
        public Work[] works { get; set; }
    }
}
