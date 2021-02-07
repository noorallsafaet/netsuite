using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetSuiteApi.Models
{
	public class CustomerModel
	{
		public string ID { get; set; }
		[Required]
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[EmailAddress]
		[Required]
		public string Email { get; set; }
		public string Phone { get; set; }
		public int Age { get; set; }
	}
}