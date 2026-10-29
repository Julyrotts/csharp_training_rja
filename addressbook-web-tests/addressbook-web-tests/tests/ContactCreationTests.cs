using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactCreationTests : AuthTestBase
	{
		
		
		[Test]
		public void  ContactCreationTest()
		{							
			ContactData contact = new ContactData("Myname", "Mysurname");
			contact.Mobile = "+79119494760";
			contact.Email = "rotc_ya@utisitgroup.ru";

			app.Contact.Create(contact);
			//app.Auth.Logout();
		}

						
	}
}