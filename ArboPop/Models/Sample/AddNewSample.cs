using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArboPop.Models.Sample
{
    public class AddNewSample
    {
        public int userId { get; }
        public DateTime date { get; set; }
        public int numOfSpecies { get; set; }
        public int totalNum { get; set; }
        public int zipcode { get; set; }
        public string trapType { get; set; }
        public string lure { get; set; }
    }
}
