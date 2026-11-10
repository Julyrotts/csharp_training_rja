using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
			SelectContact(p + 2);
			RemoveContact();
			//CloseAlert();
			manager.Navigator.GoToContacts(); ;

			return this;
		}
		public ContactHelper Modify(int p, ContactData modContact)
		{
			manager.Navigator.GoToContacts();
			InitContactModification(p);
			ModifyInContact(modContact);
			SubmitContactModification();
			//CloseAlert();
			manager.Navigator.GoToContacts();

			return this;
		}
		public ContactHelper InitContactModification(int index)
		{
			//driver.FindElement(By.XPath("//tr[" + index + "]/td[8]/a/img")).Click();
			driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7].FindElement(By.TagName("a")).Click();
			return this;
		}
		public ContactHelper SubmitContactModification()
		{
			driver.FindElement(By.Name("update")).Click();
			contactCache = null;
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

			// для выбора из выпадающих списков создать отдельный общий метод 

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
			driver.FindElement(By.Name("submit")).Click();
			contactCache = null;
			return this;
		}
		public ContactHelper SelectContact(int index)
		{
			driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
			return this;
		}

		public ContactHelper RemoveContact()
		{
			driver.FindElement(By.Name("delete")).Click();
			contactCache = null;
			return this;
		}
		public ContactHelper CloseAlert()
		{
			driver.SwitchTo().Alert().Accept();
			return this;
		}

		public ContactHelper IsNeedToContactCreate()  // необходимо ли создать контакт?

		{
			if (!IsContactCreated())  // если контактов нет 
			{
				ContactData newCont = new ContactData("надо имя", "надо фамилию");
				Create(newCont);  // создать хоть один контакт
				return this;
			}
			return this;
		}

		public bool IsContactCreated() // есть ли хоть одна группа да/нет?
		{
			manager.Navigator.GoToContacts();
			//return IsElementPresent(By.XPath("//tr[2]/td[8]/a/img"));
			return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input"));


		}

		private List<ContactData> contactCache = null;
		public List<ContactData> GetContactList()
		{
			if (contactCache == null)
			{
				contactCache = new List<ContactData>();
				manager.Navigator.GoToContacts();
				ICollection<IWebElement> elementsFirstname = driver.FindElements(By.CssSelector("tr[name=\"entry\"]>td:nth-child(3)"));  // находит столбец с именами
				ICollection<IWebElement> elementsLastname = driver.FindElements(By.CssSelector("tr[name=\"entry\"]>td:nth-child(2)")); // находит столбец с фамилиями
				ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=\"entry\"]")); // находит всю строку

				//foreach (IWebElement elementF in elementsFirstname)

				foreach (IWebElement elementF in elementsFirstname)
				{

					contactCache.Add(new ContactData(elementF.Text, elementF.Text));

				}
				int i = 0;
				foreach (IWebElement elementL in elementsLastname)
				{
					contactCache[i].Lastname = elementL.Text;
					i++;
					//contacts.Add(new ContactData(elementL.Text, elementL.Text));

				}
			}
			return new List<ContactData>(contactCache);

		}


		public int GetContactsCount()  // сколько элементов в списке

		{
			return driver.FindElements(By.CssSelector("tr[name=\"entry\"]")).Count;
		}

		public ContactData GetContactInformationFromTable(int index)
		{
			manager.Navigator.GoToContacts();

			IList<IWebElement> cells =
			driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

			string lastname = cells[1].Text;
			string firstname = cells[2].Text;
			string address = cells[3].Text;

			string allPhones = cells[5].Text;
			string allEmails = cells[4].Text;
			return new ContactData(firstname, lastname)
			{
				Address = address,
				AllPhones = allPhones,
				AllEmails = allEmails,
			};

		}

		public ContactData GetContactInformationFromEditForm(int index)
		{
			manager.Navigator.GoToContacts();
			InitContactModification(0);
			string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
			string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
			string address = driver.FindElement(By.Name("address")).GetAttribute("value");

			string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
			string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
			string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

			string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
			string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
			string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

			return new ContactData(firstname, lastname)
			{
				Address = address,
				Home = homePhone,
				Mobile = mobilePhone,
				Work = workPhone,
				Email = email1,
				Email2 = email2,
				Email3 = email3

			};

		}


	}
}
