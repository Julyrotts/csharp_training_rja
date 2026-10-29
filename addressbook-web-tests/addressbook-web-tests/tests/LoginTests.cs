using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class LoginTests : TestBase
	{


		[Test]
		public void LoginWhishValidCredentials()
		{
			// подготовка
			app.Auth.Logout();
			// действие
			AccountData account = new AccountData("admin", "secret");
			app.Auth.Login(account);

			// проверка
			Assert.IsTrue(app.Auth.IsLoggedIn(account));
		}


		[Test]
		public void LoginWhishInvalidCredentials()
		{
			// подготовка
			app.Auth.Logout();
			// действие
			AccountData account = new AccountData("admin", "NOpass");
			app.Auth.Login(account);

			// проверка
			Assert.IsFalse(app.Auth.IsLoggedIn(account));
		}


	}
}