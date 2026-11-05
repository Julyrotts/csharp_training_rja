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
			GroupData toBeRemoved = oldGroups[0];
			app.Groups.IsNeedToGroupCreate();
			//действие		

		app.Groups.Remove(0);

			// проверка
			Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

			List<GroupData> newGroups = app.Groups.GetGroupList();
			
			oldGroups.RemoveAt(0);
			oldGroups.Sort();
			newGroups.Sort();
			//groups.Count;
			Assert.AreEqual(oldGroups, newGroups);
			//Assert.AreEqual(oldGroups.Count, newGroups.Count);
			
			foreach (GroupData group in newGroups)
			{
				Assert.AreNotEqual(group.Id, toBeRemoved.Id);
			}

		}

	}
}


