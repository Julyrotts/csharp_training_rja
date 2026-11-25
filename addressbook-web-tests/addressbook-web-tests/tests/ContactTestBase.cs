using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	public class ContactTestBase : AuthTestBase
	{
		[TearDown]
		public void CompareContactsUI_DB()   // постпроверка для contact tests
		{
			if (PERFORM_LONG_UI_CHECKS)
			{
				List<ContactData> DB_Contacts = ContactData.GetAll();
				List<ContactData> UI_Contacts = app.Contact.GetContactList();
				DB_Contacts.Sort();
				UI_Contacts.Sort();
				Assert.AreEqual(DB_Contacts, UI_Contacts);

			}
		}


	}
}
