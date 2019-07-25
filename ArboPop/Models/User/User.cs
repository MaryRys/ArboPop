using ArboPop.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArboPop.Models.User
{
    public class User : ISingleUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Uid { get; set; }
        public DateTime? CreationDate { get; set; }
    }

}
