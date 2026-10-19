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
		private bool acceptNextAlert = true;
		protected string baseURL;
		protected LoginHelper loginHelper;
		protected NavigationHelper navigator;
		protected GroupHelper groupHelper;

	public ApplicationManager() // инициализация полей, которые перечислены выше
		{
			loginHelper = new LoginHelper(driver);
			navigator = new NavigationHelper(driver, baseURL);
			groupHelper = new GroupHelper(driver);
			driver = new FirefoxDriver();
			baseURL = "http://localhost";
			//verificationErrors = new StringBuilder();

		}
		// блок конструкторов, чтобы методы хелперов были видны тестам, т.к. менеджер их перегородил 
	public LoginHelper Auth
		{ get { return loginHelper; } }
	public NavigationHelper Navigator
	{ get { return navigator; } }
	public GroupHelper Groups
	{  get { return groupHelper; } }
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
