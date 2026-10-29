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
		public ContactHelper(ApplicationManager manager) : base(manager) { }

		public ContactHelper Create(ContactData contact)
		{
			AddNewContact();
			FillContactForm(contact);
			SubmitContactCreation();
			manager.Navigator.GoToContacts();

			return this;
		}
		public ContactHelper Remove(int p)
		{
			manager.Navigator.GoToContacts();
			SelectContact(p);
			InitContactModification();
			RemoveContact();
			//CloseAlert();
			manager.Navigator.GoToContacts(); ;

			return this;
		}
		public ContactHelper Modify(int p, ContactData modContact)
		{
			manager.Navigator.GoToContacts();
			SelectContact(p);
			InitContactModification();
			ModifyInContact(modContact);
			SubmitContactModification();
			//CloseAlert();
			manager.Navigator.GoToContacts(); 

			return this;
		}
		public ContactHelper InitContactModification()
		{
			driver.FindElement(By.XPath("//tr[5]/td[8]/a/img")).Click();
			return this;
		}
		public ContactHelper SubmitContactModification()
		{
			driver.FindElement(By.Name("update")).Click();
			return this;
		}

		public ContactHelper AddNewContact()
		{
			driver.FindElement(By.LinkText("add new")).Click();
			return this;

		}

		public ContactHelper FillContactForm(ContactData contact)
		{
			Type(By.Name("firstname"), contact.Firstname);
			Type(By.Name("middlename"), contact.Middlename);
			Type(By.Name("lastname"), contact.Lastname);
			Type(By.Name("nickname"), contact.Nickname);
			Type(By.Name("title"), contact.Title);
			Type(By.Name("company"), contact.Company);
			Type(By.Name("address"), contact.Address);
			Type(By.Name("home"), contact.Home);
			Type(By.Name("mobile"), contact.Mobile);
			Type(By.Name("work"), contact.Work);
			Type(By.Name("email"), contact.Email);
			Type(By.Name("email2"), contact.Email2);
			Type(By.Name("email3"), contact.Email3);
			Type(By.Name("homepage"), contact.Homepage);
			Type(By.Name("address"), contact.Address);
			Type(By.Name("address"), contact.Address);
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

			return this;
		}
		public ContactHelper ModifyInContact(ContactData contact)
		{
			Type(By.Name("firstname"), contact.Firstname);
			Type(By.Name("middlename"), contact.Middlename);
			Type(By.Name("lastname"), contact.Lastname);
			Type(By.Name("nickname"), contact.Nickname);
			Type(By.Name("title"), contact.Title);
			Type(By.Name("company"), contact.Company);
			Type(By.Name("address"), contact.Address);
			Type(By.Name("home"), contact.Home);
			Type(By.Name("mobile"), contact.Mobile);
			Type(By.Name("work"), contact.Work);
			Type(By.Name("email"), contact.Email);
			Type(By.Name("email2"), contact.Email2);
			Type(By.Name("email3"), contact.Email3);
			Type(By.Name("homepage"), contact.Homepage);			
			/*Type(By.Name("bday"), contact.Bday);
			Type(By.Name("bmonth"), contact.Bmonth);
			Type(By.Name("byear"), contact.Byear);
			Type(By.Name("aday"), contact.Aday);
			Type(By.Name("amonth"), contact.Amonth);
			Type(By.Name("ayear"), contact.Ayear);*/

			// для выбора из выпадающих списков нужен отдельный общий метод 

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

			//driver.FindElement(By.Name("photo")).Click();					


			return this;
		}

	
		public ContactHelper SubmitContactCreation()
		{
			driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
			return this;
		}
		public ContactHelper SelectContact(int index)
		{
			//driver.FindElement(By.Id("index")).Click();
			//driver.FindElement(By.XPath("//div[@id='content']/form/input[19]")).Click();
			driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+index+"]/td/input")).Click();
			return this;
		}

		public ContactHelper RemoveContact()
		{
			driver.FindElement(By.Name("delete")).Click();
			return this;
		}
		public ContactHelper CloseAlert()
		{
			driver.SwitchTo().Alert().Accept();
			return this;
		}
		

	}
}
