using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
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
			List<ContactData> oldContacts = app.Contact.GetContactList(); // получить начальный список контактов


			app.Contact.Create(contact);
			//app.Auth.Logout();

			// проверка
			List<ContactData> newContacts = app.Contact.GetContactList();
			oldContacts.Add(contact);
			oldContacts.Sort();
			newContacts.Sort();
			//groups.Count;
			Assert.AreEqual(oldContacts, newContacts);
			//Assert.AreEqual(oldContacts.Count, newContacts.Count);

		}


	}
}