using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactCreationTests : TestBase
	{
		
		
		[Test]
		public void  ContactCreationTest()
		{
							
			ContactData contact = new ContactData("Myname", "Mysurname");
			contact.Mobile = "+79119494760";
			contact.Email = "rotc_ya@utisitgroup.ru";
			app.Contact.AddNewContact()
				.FillContactForm(contact)
				.SubmitContactCreation();
			app.Navigator.GoToContacts();
			app.Auth.Logout();
		}

						
	}
}