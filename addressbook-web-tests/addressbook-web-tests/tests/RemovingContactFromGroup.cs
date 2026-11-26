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

			List<GroupData> groups = GroupData.GetAll();
			int emptyGroupContacts = (group.GetContacts()).Count;

			List<GroupData> group_whith_contacts = groups.FindAll(g => (g.GetContacts()).Count != 0); // получить список групп с контактами

			if (group_whith_contacts.Count != 0) // если есть группы с контактами взять первую попавшуюся

			{ group = group_whith_contacts[0]; }
			else // если нет групп с контактами, надо добавить
			{
				ContactData free_contact = ContactData.GetAll().First();
				app.Contact.AddContactToGroup(free_contact, group); 

				}




			List<ContactData> oldGroupContacts = group.GetContacts(); // получить начальный список контактов в группе

			ContactData contact = oldGroupContacts.First(); // первый попавшийся сонтакт в группе

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
