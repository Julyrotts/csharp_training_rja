using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	public class ApplicationManager
	{
		protected IWebDriver driver;
		protected bool acceptNextAlert = true;
		protected string baseURL;
		protected NavigationHelper navigator;
		protected LoginHelper loginHelper;
		protected GroupHelper groupHelper;
		protected ContactHelper contactHelper;

		public ApplicationManager() // инициализация полей, которые перечислены выше
		{
			driver = new FirefoxDriver();
			baseURL = "http://localhost";
			loginHelper = new LoginHelper(driver);
			navigator = new NavigationHelper(driver, baseURL);
			groupHelper = new GroupHelper(driver);
			contactHelper = new ContactHelper(driver);
			//verificationErrors = new StringBuilder();

		}
		// блок конструкторов, чтобы методы хелперов были видны тестам, т.к. менеджер их перегородил 
		public LoginHelper Auth
		{ get { return loginHelper; } }
		public NavigationHelper Navigator
		{ get { return navigator; } }
		public GroupHelper Groups
		{ get { return groupHelper; } }
		public ContactHelper Contact
		{ get { return contactHelper; } }
		public void Stop()
		{
			try
			{
				driver.Quit();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
		}


	}
}
