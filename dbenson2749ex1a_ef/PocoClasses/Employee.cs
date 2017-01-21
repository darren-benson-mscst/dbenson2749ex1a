using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbenson2749ex1a_ef.Model
{
    public partial class Employee
    {
        public string LastFirstName
        {
            get
            {
                return Person.LastName + ", " + Person.FirstName;
            }
        }

    }
}
