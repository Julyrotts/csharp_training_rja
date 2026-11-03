using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class GroupModificationTests : AuthTestBase
	{
		[Test]
		public void GroupModificationTest()
		{

			// подготовка
			// если надо, создаем
			app.Groups.IsNeedToGroupCreate();
			List<GroupData> oldGroups = app.Groups.GetGroupList();

			//действие		

			GroupData newData = new GroupData("Modify_group");
			newData.Header = "Mod_group_h";
			newData.Footer = "Mod_group_f";

			app.Groups.Modify(0, newData);


			List<GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups[0].Name= newData.Name;
			oldGroups.Sort();
			newGroups.Sort();
			// проверка
			Assert.AreEqual(oldGroups, newGroups);

		}
	}
}
