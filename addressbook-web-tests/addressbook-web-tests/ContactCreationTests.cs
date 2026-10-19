using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactCreationTests : TestBase // наследник
	{
		
		[Test]
		public void  ContactCreationTest()
		{
			GoToHomePage();
			Login(new AccountData("admin", "secret"));
			AddNewContact();			
			ContactData contact = new ContactData("Myname", "Mysurname");
			contact.Mobile = "+79119494760";
			contact.Email = "rotc_ya@utisitgroup.ru";
			FillContactForm(contact);
			SubmitContactCreation();
			GoToContacts();
			Logout();
		}
					

		
	}
}