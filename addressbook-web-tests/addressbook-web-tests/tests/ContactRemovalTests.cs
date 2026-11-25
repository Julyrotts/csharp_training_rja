using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactRemovalTests : ContactTestBase
	{


		[Test]
		public void ContactRemovalTest()
		{
			// подготовка
			// если надо, создаем
			app.Contact.IsNeedToContactCreate();
			//List<ContactData> oldContacts = app.Contact.GetContactList(); // получить начальный список контактов
			List<ContactData> oldContacts = ContactData.GetAll();
			ContactData toBeRemoved = oldContacts[0];

			//действие			

			//app.Contact.Remove(0);
			app.Contact.Remove(toBeRemoved);

			// проверка
			Assert.AreEqual(oldContacts.Count-1, app.Contact.GetContactsCount());

			//List<ContactData> newContacts = app.Contact.GetContactList();
			List<ContactData> newContacts = ContactData.GetAll();

			oldContacts.RemoveAt(0);
			oldContacts.Sort();
			newContacts.Sort();
			
			Assert.AreEqual(oldContacts, newContacts);
			//Assert.AreEqual(oldContacts.Count, newContacts.Count);


		}

	}
}