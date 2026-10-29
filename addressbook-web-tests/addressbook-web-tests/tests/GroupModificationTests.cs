using System;
using System.Collections.Generic;
using System.Linq;
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
			GroupData newData = new GroupData("Modify_group");
			newData.Header = "Mod_group_h";
			newData.Footer = "Mod_group_f";

			app.Groups.Modify(1, newData);

		}
	}
}
