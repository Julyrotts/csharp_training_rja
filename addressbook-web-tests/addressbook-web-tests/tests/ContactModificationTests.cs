using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactModificationTests : AuthTestBase
	{
		[Test]
		public void ContactModificationTest()
		{

			// подготовка
			// если надо, создаем
			app.Contact.IsNeedToContactCreate();

			//действие	

			ContactData modContact = new ContactData("July", "Ceasare");
			modContact.Mobile = "+7 40904";
			modContact.Email = "mail_ya@mail.ru";

			app.Contact.Modify(5, modContact);

		}
	}
}
