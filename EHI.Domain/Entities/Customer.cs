using EHI.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EHI.Domain.Entities
{
	public class Customer  
	{
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set;  }
		public bool Status { get; set; }
	}

    //public class Name
    //{
    //    public string First { get; set; }

    //    public string Last { get; set; }

    //    public Name(string first, string last)
    //    {
    //        if (string.IsNullOrWhiteSpace(first)) throw new Exception("First name is invalid");
    //        if (string.IsNullOrWhiteSpace(last)) throw new Exception("Last name is invalid");

    //        First = first;
    //        Last = last;
    //    }
    //}
}
