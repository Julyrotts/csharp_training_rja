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
	public class GroupHelper : HelperBase
	{
			public GroupHelper(ApplicationManager manager) : base(manager) {	}
		
			public GroupHelper Create(GroupData group)
			{
			manager.Navigator.GoToGroupsPage();
			InitGroupCreation();
			FillGroupForm(group);
			SubmitGroupCreation();
			ReturnToGroupsPage();

			return this;
			}
			public GroupHelper Remove (int p)
			{
			manager.Navigator.GoToGroupsPage();
			SelectGroup(p);
			RemoveGroup();
			ReturnToGroupsPage();

			return this;
		}
		public GroupHelper Modify(int p, GroupData newData)
		{
			manager.Navigator.GoToGroupsPage();
			/*if (! IsGroupCreated())
			{	GroupData newgroup = new GroupData("group1");
				Create(newgroup);
			return this; } */
			SelectGroup(p);
			InitGroupModification();
			FillGroupForm(newData);
			SubmitGroupModification();
			ReturnToGroupsPage();

			return this;
		}
		public GroupHelper InitGroupModification()
		{
			driver.FindElement(By.Name("edit")).Click();
			return this;
		}
		public GroupHelper SubmitGroupModification()
		{
			driver.FindElement(By.Name("update")).Click();
			return this;
		}

		public GroupHelper InitGroupCreation()
		{
			driver.FindElement(By.Name("new")).Click();
			return this;
		}
		public GroupHelper SelectGroup(int index)
		{
			driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
			return this;
			}
		public GroupHelper RemoveGroup()
		{
			driver.FindElement(By.XPath("//input[5]")).Click();
			return this;
		}

		public GroupHelper SubmitGroupCreation()
		{
			driver.FindElement(By.Name("submit")).Click();
			return this;
		}

		public GroupHelper FillGroupForm(GroupData group)
		{
			Type(By.Name("group_name"), group.Name);
			Type(By.Name("group_header"), group.Header);
			Type(By.Name("group_footer"), group.Footer);
			
			return this;
		}
			

		public GroupHelper ReturnToGroupsPage()
		{
			driver.FindElement(By.LinkText("group page")).Click();
			return this;
		}


		public GroupHelper IsNeedToGroupCreate()  // необходимо ли создать группу?

		{
			//manager.Navigator.GoToGroupsPage();
			if (! IsGroupCreated())  // если группы нет ни одной
			{	GroupData newgroup = new GroupData("need_group");
				Create(newgroup);  // создать хоть одну группу
			return this;  }
			return this;
		}

		public bool IsGroupCreated () // есть ли хоть одна группа да/нет?
		{
			manager.Navigator.GoToGroupsPage();
			return driver.Url == manager.Navigator.baseURL + "/addressbook/group.php"
			&& IsElementPresent(By.XPath("//div[@id='content']/form/span[1]/input"));
			//Create(GroupData group);
		}



	}

}
