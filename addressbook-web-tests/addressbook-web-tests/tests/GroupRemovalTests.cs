using System;
using System.Collections.Generic;
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
			List<GroupData> oldGroups = app.Groups.GetGroupList();
			app.Groups.IsNeedToGroupCreate();
			//действие		

		app.Groups.Remove(0);

		// проверка
			List<GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups.RemoveAt(0);
			Assert.AreEqual(oldGroups.Count, newGroups.Count);

			//app.Auth.Logout();
		}

	}
}


