using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using LinqToDB;

namespace WebAddressbookTests
{
	[TestFixture]
	public class TestDBConnectivityTests : GroupTestBase
	{

	
		[Test]
		public void TestDBConnectivity()
		{
			DateTime start = DateTime.Now;
			List<GroupData> groupDataFromUI = app.Groups.GetGroupList();
			DateTime end = DateTime.Now;
			System.Console.Out.Write(end.Subtract(start) + "\r\n");
			//System.Console.Out.Writeline(end.Subtract(start));
			//Console.Writeline(end.Subtract(start));


			start = DateTime.Now;

			List<GroupData> GroupDataFromDB = GroupData.GetAll();
			end = DateTime.Now;
			System.Console.Out.Write(end.Subtract(start) + "\r\n");

			//ContactData contact = ContactData.GetAll().First();
			//System.Console.Out.Write(contact.Deprecated + "\r\n");
			foreach (ContactData contact in ContactData.GetAll())

			{ System.Console.Out.Write(contact.Lastname + "\r\n"); }

			List<ContactData> all_cont = ContactData.GetAll();

			foreach (ContactData gcontact in GroupData.GetAll()[0].GetContacts())

			{ System.Console.Out.Write(gcontact + "\r\n"); }

		}


	}
}
