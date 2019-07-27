using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArboPop.Models.Complaints
{
    public class NewComplaint
    {
        public int userId { get; }
        public string timeOfDay { get; set; }
        public int zipcode { get; set; }
        public string bitingSource { get; set; }
        public string AddtlNotes { get; set; }
        public DateTime creationDate { get; set; }
    }
}
