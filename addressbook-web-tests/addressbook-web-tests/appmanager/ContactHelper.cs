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
	public class ContactHelper : HelperBase
	{
		public ContactHelper(IWebDriver driver) : base(driver) { }
		public void SubmitContactCreation()
		{
			driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
		}

		public void GoToContacts()
		{
			driver.FindElement(By.LinkText("home")).Click();
		}

		public void FillContactForm(ContactData contact)
		{
			driver.FindElement(By.Name("firstname")).Click();
			driver.FindElement(By.Name("firstname")).Clear();
			driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
			driver.FindElement(By.Name("middlename")).Click();
			driver.FindElement(By.Name("middlename")).Clear();
			driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
			driver.FindElement(By.Name("lastname")).Click();
			driver.FindElement(By.Name("lastname")).Clear();
			driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
			driver.FindElement(By.Name("nickname")).Click();
			driver.FindElement(By.Name("nickname")).Clear();
			driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
			//driver.FindElement(By.Name("photo")).Click();
			driver.FindElement(By.Name("title")).Click();
			driver.FindElement(By.Name("title")).Clear();
			driver.FindElement(By.Name("title")).SendKeys(contact.Title);
			driver.FindElement(By.Name("company")).Click();
			driver.FindElement(By.Name("company")).Clear();
			driver.FindElement(By.Name("company")).SendKeys(contact.Company);
			driver.FindElement(By.Name("address")).Click();
			driver.FindElement(By.Name("address")).Clear();
			driver.FindElement(By.Name("address")).SendKeys(contact.Address);
			driver.FindElement(By.Name("home")).Click();
			driver.FindElement(By.Name("home")).Clear();
			driver.FindElement(By.Name("home")).SendKeys(contact.Home);
			driver.FindElement(By.Name("mobile")).Click();
			driver.FindElement(By.Name("mobile")).Clear();
			driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
			driver.FindElement(By.Name("work")).Click();
			driver.FindElement(By.Name("email")).Click();
			driver.FindElement(By.Name("email")).Clear();
			driver.FindElement(By.Name("email")).SendKeys(contact.Email);
			driver.FindElement(By.Name("email2")).Click();
			driver.FindElement(By.Name("email3")).Click();
			driver.FindElement(By.Name("homepage")).Click();
			driver.FindElement(By.Name("homepage")).Clear();
			driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
			driver.FindElement(By.Name("bday")).Click();
			new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
			driver.FindElement(By.Name("bmonth")).Click();
			new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
			driver.FindElement(By.Name("byear")).Click();
			driver.FindElement(By.Name("byear")).Clear();
			driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
			driver.FindElement(By.Name("aday")).Click();
			new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
			driver.FindElement(By.Name("amonth")).Click();
			new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
			driver.FindElement(By.Name("ayear")).Click();
			driver.FindElement(By.Name("ayear")).Clear();
			driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
			driver.FindElement(By.Name("new_group")).Click();
			driver.FindElement(By.Name("new_group")).SendKeys(contact.New_group);
		}

		public void AddNewContact()
		{
			driver.FindElement(By.LinkText("add new")).Click();
		}


	}

}
