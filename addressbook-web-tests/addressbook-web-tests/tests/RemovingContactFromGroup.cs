using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using LinqToDB;

namespace WebAddressbookTests
{
	[TestFixture]
	public class RemovingContactFromGroupTests : AuthTestBase
	{


		[Test]
		public void RemovingContactFromGroup()
		{

			//IsNeedToAddContactToGroup();
		   GroupData group = GroupData.GetAll()[0];

			List<ContactData> oldGroupContacts = group.GetContacts(); // получить начальный список контактов в группе

			ContactData contact = oldGroupContacts.First();

			// actions
			app.Contact.DeleteContactFromGroup(contact, group);

			List<ContactData> newGroupContacts = group.GetContacts(); // получить новый список контактов в группе

			oldGroupContacts.Remove(contact);
			oldGroupContacts.Sort();
			newGroupContacts.Sort();

			Assert.AreEqual(oldGroupContacts, newGroupContacts);
			//Assert.AreEqual(oldContacts.Count, newContacts.Count);

		}


	}
}
