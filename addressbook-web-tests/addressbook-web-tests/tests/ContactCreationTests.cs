using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	[TestFixture]
	public class ContactCreationTests : TestBase
	{
		
		
		[Test]
		public void  ContactCreationTest()
		{
			navigator.GoToHomePage();
			loginHelper.Login(new AccountData("admin", "secret"));
			contactHelper.AddNewContact();			
			ContactData contact = new ContactData("Myname", "Mysurname");
			contact.Mobile = "+79119494760";
			contact.Email = "rotc_ya@utisitgroup.ru";
			contactHelper.FillContactForm(contact);
			contactHelper.SubmitContactCreation();
			contactHelper.GoToContacts();
			loginHelper.Logout();
		}	
				
				
	}
}