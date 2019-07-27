using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArboPop.Models.Mosquito
{
    public class Mosquito
    {
        public int id { get; set; }
        public string breedingHabitat { get; set; }
        public string scientificName { get; set; }
        public string commonName { get; set; }
        public bool confirmed { get; set; }
    }
}
