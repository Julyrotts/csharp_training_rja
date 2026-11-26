using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Relational;
using NUnit.Framework;
using ZstdSharp.Unsafe;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactInformationTests : AuthTestBase
	{
		[Test]
		public void ContactInformationTest()
		{

			// подготовка
			// если надо, создаем
			app.Contact.IsNeedToContactCreate();

			List<ContactData> tableContacts = ContactData.GetAll();
			ContactData tcontact = tableContacts[0]; 

			//ContactData fromTable = app.Contact.GetContactInformationFromTable(0);
			//ContactData fromForm = app.Contact.GetContactInformationFromEditForm(0);

			ContactData fromTable = app.Contact.GetContactInformationFromTable(tcontact.Id);
			ContactData fromForm = app.Contact.GetContactInformationFromEditForm(tcontact.Id);


			// проверка
			Assert.AreEqual(fromTable, fromForm);
			Assert.AreEqual(fromTable.Address, fromForm.Address);
			Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
			Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
						

		}

		[Test]
		public void ContactDetailsTest()
		{

			// подготовка
			List<ContactData> tableContacts = ContactData.GetAll();
			ContactData tcontact = tableContacts[0];

			ContactData fromDetail = app.Contact.GetContactInformationFromDetails(tcontact.Id);
			ContactData fromFullForm = app.Contact.GetFullInformationFromEditForm(0);


			// проверка
			
			Assert.AreEqual(fromDetail.FIO, fromFullForm.FIO);
			Assert.AreEqual(fromDetail.ContactDetails, fromFullForm.ContactDetails);

		}


	}
}
