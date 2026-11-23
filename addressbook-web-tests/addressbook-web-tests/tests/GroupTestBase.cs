using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	public class GroupTestBase : AuthTestBase
	{
		[TearDown]
		public void CompareGroupsUI_DB()   // постпроверка для тестов
		{
			if (PERFORM_LONG_UI_CHECKS)
			{
				List<GroupData> DB_Groups = GroupData.GetAll();
				List<GroupData> UI_Groups = app.Groups.GetGroupList();
				DB_Groups.Sort();
				UI_Groups.Sort();
				Assert.AreEqual(DB_Groups, UI_Groups);

			}
		}


	}
}
