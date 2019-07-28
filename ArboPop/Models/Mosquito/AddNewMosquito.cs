using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArboPop.Models.Mosquito
{
    public class AddNewMosquito
    {
        public string breedingHabitat { get; set; }
        public string scientificName { get; set; }
        public string commonName { get; set; }
        public bool confirmed { get; set; }
    }
}
