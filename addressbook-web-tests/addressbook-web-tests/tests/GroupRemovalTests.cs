using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class GroupRemovalTests : AuthTestBase
	{
		

		[Test]
		public void GroupRemovalTest() 
		{
			// подготовка
			//GroupData group = new GroupData("need group");
			app.Groups.NeedToGroupCreate();
			//действие		

		app.Groups.Remove(1);

		// проверка
			
			//app.Auth.Logout();
		}

	}
}


