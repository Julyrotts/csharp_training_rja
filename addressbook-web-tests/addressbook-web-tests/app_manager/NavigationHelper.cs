using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	public class NavigationHelper : HelperBase
	{
		public string baseURL;
		public NavigationHelper(IWebDriver driver, string baseURL) : base(driver) 
		{
			this.baseURL=baseURL;
		}
		public void GoToHomePage()
		{
			driver.Navigate().GoToUrl(baseURL + "/addressbook");
		}
		public void GoToGroupsPage()
		{
			driver.FindElement(By.LinkText("groups")).Click();
			driver.Navigate().GoToUrl("http://localhost/addressbook/group.php");
		}
		public void GoToContacts()
		{
			driver.FindElement(By.LinkText("home")).Click();
		}


	}
}
