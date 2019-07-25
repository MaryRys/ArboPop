using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArboPop.Interface
{
    public interface ISingleUser
    {
        DateTime? CreationDate { get; set; }
        string FirstName { get; set; }

        int Id { get; set; }
        string LastName { get; set; }
        string UserName { get; set; }
    }
}
