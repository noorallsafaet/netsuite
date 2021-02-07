using NetSuiteApi.com.netsuite.webservices;
using NetSuiteApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NetSuiteApi.Controllers
{
    public class CustomersController : ApiController
	{
		// POST: api/Customers
		[HttpPost]
        public string Post([FromBody]CustomerModel model)
        {
			string Id = string.Empty;

			NetSuiteService netSuiteService = new NetSuiteService();
			netSuiteService.CookieContainer = new CookieContainer();
			Passport passport = new Passport();
			passport.account = "XXX";
			passport.email = "";
			RecordRef recordRef = new RecordRef();
			recordRef.internalId = "123";
			passport.role = recordRef;
			passport.password = "12345";

			Customer customer = new Customer();
			customer.firstName = model.FirstName;
			customer.lastName = model.LastName;
			customer.email = model.Email;
			customer.phone = model.Phone;

			RecordRef subsidiary = new RecordRef();
			subsidiary.internalId = "4";
			customer.subsidiary = subsidiary;
			WriteResponse response = netSuiteService.add(customer);

			if(response.status.isSuccess)
			{
				Id = customer.entityId; //Customer Id will be entityId or internalId
				Id = customer.internalId; //Customer Id will be internalId or entityId
			}

			return Id;
        }
    }
}
