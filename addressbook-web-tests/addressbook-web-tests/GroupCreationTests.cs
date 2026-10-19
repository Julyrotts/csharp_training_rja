using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class GroupCreationTests : TestBase
	{
		

		[Test]
		public void GroupCreationTest()
		{
			GoToHomePage();
			Login(new AccountData("admin","secret"));
			GoToGroupsPage();
			InitGroupCreation();
			GroupData group = new GroupData("group1");
			group.Header = "group_h";
			group.Footer = "group_f";
			FillGroupForm(group);
			SubmitGroupCreation();
			ReturnToGroupsPage();
		}		
		
		
	}
}
