using System;
using System.IO;
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

			//действие			

			app.Contact.Remove(3);

			//app.Auth.Logout();
		}

	}
}