using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactModificationTests : ContactTestBase
	{
		[Test]
		public void ContactModificationTest()
		{

			// подготовка
			// если надо, создаем
			app.Contact.IsNeedToContactCreate();
			//List<ContactData> oldContacts = app.Contact.GetContactList(); // получить начальный список контактов
			List<ContactData> oldContacts = ContactData.GetAll();
			ContactData toBeModify = oldContacts[0];

			//действие	

			ContactData modContact = new ContactData("July", "Ceasare");
			modContact.Mobile = "+7 40904";
			modContact.Email = "mail_ya@mail.ru";

			//app.Contact.Modify(0, modContact);
			app.Contact.Modify(toBeModify, modContact);

			// проверка
			Assert.AreEqual(oldContacts.Count, app.Contact.GetContactsCount());

			//List<ContactData> newContacts = app.Contact.GetContactList();
			List<ContactData> newContacts = ContactData.GetAll();
			oldContacts[0].Firstname = modContact.Firstname;
			oldContacts[0].Lastname = modContact.Lastname;
			oldContacts.Sort();
			newContacts.Sort();
			//groups.Count;
			Assert.AreEqual(oldContacts, newContacts);
			//Assert.AreEqual(oldContacts.Count, newContacts.Count);

		}
	}
}
