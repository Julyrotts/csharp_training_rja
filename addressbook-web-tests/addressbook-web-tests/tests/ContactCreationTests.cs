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
using NUnit.Framework;
using LinqToDB;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactCreationTests : AuthTestBase
	{

		public static IEnumerable<ContactData> RandomContactDataProvider()
		{

			List<ContactData> contact = new List<ContactData>();
			for (int i = 0; i < 5; i++)
			{
				contact.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
				{
					Middlename = GenerateRandomString(30),
					Nickname = GenerateRandomString(10),
					Address = GenerateRandomString(100),
					Home = GenerateRandomString(10),
					Mobile = GenerateRandomString(10),
					Work = GenerateRandomString(10),
					Email = GenerateRandomString(10)+ "@"+GenerateRandomString(4)+"\\."+ GenerateRandomString(4),
					Email2= GenerateRandomString(20),
					Email3 = GenerateRandomString(20),
					Title = GenerateRandomString(50),
					Company = GenerateRandomString(20),
					Homepage = GenerateRandomString(30)
					
				});

			}

			return contact;
		}

		public static IEnumerable<ContactData> ContactDataFromCSVFile()
		{
			List<ContactData> contact = new List<ContactData>();
			string[] lines = File.ReadAllLines(@"contacts.csv");
			foreach (string l in lines)
			{
				string[] parts = l.Split(',');
				contact.Add(new ContactData(parts[0], parts[1]) { 
				Mobile = parts[2], Email = parts[3] });

			}
			return contact;
		}

		public static IEnumerable<ContactData> ContactDataFromXMLFile()
		{
			return (List<ContactData>)
			new XmlSerializer(typeof(List<ContactData>)).
			Deserialize(new StreamReader(@"contacts.xml"));
		}

		public static IEnumerable<ContactData> ContactDataFromJSONFile()
		{
			return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contacts.json"));
		}

				
		[Test, TestCaseSource("ContactDataFromCSVFile")]
		
		public void  ContactCreationCSVTest(ContactData contact)
		{							
			/* ContactData contact = new ContactData("Myname", "Mysurname");
			contact.Mobile = "+79119494760";
			contact.Email = "rotc_ya@utisitgroup.ru"; */
			
			List<ContactData> oldContacts = app.Contact.GetContactList(); // получить начальный список контактов


			app.Contact.Create(contact);
			//app.Auth.Logout();

			// проверка
			Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactsCount());

			List<ContactData> newContacts = app.Contact.GetContactList();
			oldContacts.Add(contact);
			oldContacts.Sort();
			newContacts.Sort();
			//Contact.Count;
			Assert.AreEqual(oldContacts, newContacts);
			//Assert.AreEqual(oldContacts.Count, newContacts.Count);

		}


		[Test, TestCaseSource("ContactDataFromXMLFile")]

		public void ContactCreationXMLTest(ContactData contact)
		{
			List<ContactData> oldContacts = app.Contact.GetContactList(); // получить начальный список контактов

			app.Contact.Create(contact);
			//app.Auth.Logout();

			// проверка
			Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactsCount());

			List<ContactData> newContacts = app.Contact.GetContactList();
			oldContacts.Add(contact);
			oldContacts.Sort();
			newContacts.Sort();
			
			Assert.AreEqual(oldContacts, newContacts);
			
		}

		[Test, TestCaseSource("ContactDataFromJSONFile")]

		public void ContactCreationJSONTest(ContactData contact)
		{
			List<ContactData> oldContacts = app.Contact.GetContactList(); // получить начальный список контактов


			app.Contact.Create(contact);
			
			// проверка
			Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactsCount());

			List<ContactData> newContacts = app.Contact.GetContactList();
			oldContacts.Add(contact);
			oldContacts.Sort();
			newContacts.Sort();
			
			Assert.AreEqual(oldContacts, newContacts);
			
		}



	}
}