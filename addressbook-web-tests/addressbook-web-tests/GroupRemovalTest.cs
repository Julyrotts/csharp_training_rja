using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class GroupRemovalTests : TestBase
	{
		

		[Test]
		public void GroupRemovalTest() 
		{
			navigator.GoToHomePage();
			loginHelper.Login(new AccountData("admin", "secret"));
			navigator.GoToGroupsPage();
			groupHelper.SelectGroup(1);
			//driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
			groupHelper.RemoveGroup();
			groupHelper.ReturnToGroupsPage();
			//driver.FindElement(By.LinkText("Logout")).Click();
		}
										
	}
}
