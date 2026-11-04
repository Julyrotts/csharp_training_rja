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
	public class ContactRemovalTests : AuthTestBase
	{


		[Test]
		public void ContactRemovalTest()
		{
			// подготовка
			// если надо, создаем
			app.Contact.IsNeedToContactCreate();
			List<ContactData> oldContacts = app.Contact.GetContactList(); // получить начальный список контактов

			//действие			

			app.Contact.Remove(0);

			// проверка
			List<ContactData> newContacts = app.Contact.GetContactList();
			oldContacts.RemoveAt(0);
			oldContacts.Sort();
			newContacts.Sort();
			//groups.Count;
			Assert.AreEqual(oldContacts, newContacts);
			//Assert.AreEqual(oldContacts.Count, newContacts.Count);



			//app.Auth.Logout();
		}

	}
}