using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHI.WebApi.Models
{
    public class CreateCustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
