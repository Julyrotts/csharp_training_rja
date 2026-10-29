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
			// если надо, создаем
			app.Groups.IsNeedToGroupCreate();
			//действие		

		app.Groups.Remove(1);

		//app.Auth.Logout();
		}

	}
}


