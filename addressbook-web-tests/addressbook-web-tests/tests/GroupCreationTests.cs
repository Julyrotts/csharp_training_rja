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
	public class GroupCreationTests : GroupTestBase
	{	

	public static IEnumerable<GroupData> RandomGroupDataProvider()
	{

			List<GroupData> groups = new List<GroupData>();
			for (int i = 0; i<5; i++)
			{
				groups.Add(new GroupData(GenerateRandomString(30)) 
				{ Header= GenerateRandomString(100), 
				Footer= GenerateRandomString(100) });

			}

			return groups;
	}


		public static IEnumerable<GroupData> GroupDataFromCSVFile()
		{
			List<GroupData> groups = new List<GroupData>();
			string[] lines = File.ReadAllLines(@"group.csv");
			foreach (string l in lines)
			{
				string[] parts = l.Split(',');
				groups.Add(new GroupData(parts[0]) {Header = parts[1], Footer=parts[2] });

			}
			return groups;
		}

		public static IEnumerable<GroupData> GroupDataFromXMLFile()
		{
			return (List<GroupData>)
			new XmlSerializer(typeof(List<GroupData>)).
			Deserialize(new StreamReader(@"groups.xml"));
		}

		public static IEnumerable<GroupData> GroupDataFromJSONFile()
		{			
			return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"groups.json"));
		}


		public static IEnumerable<GroupData> GroupDataFromExcelFile()
		{
			List<GroupData> groups = new List<GroupData>();
			Excel.Application app = new Excel.Application();
			app.Visible = true;
			Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.xlsx"));
			Excel.Worksheet sheet = wb.ActiveSheet;
			Excel.Range range = sheet.UsedRange;
			for (int i = 0; i<=range.Rows.Count; i++) 
			{
				groups.Add(new GroupData()
				{
				Name = range.Cells[i,1].Value,
				Header = range.Cells[i, 2].Value,
				Footer = range.Cells[i, 1].Value
				});
			}
			wb.Close();
			app.Visible = false;
			app.Quit();
			return groups;
		}




		[Test, TestCaseSource("GroupDataFromCSVFile")]
		public void GroupCreationCSVTest(GroupData group)
		{
			List<GroupData> oldGroups = app.Groups.GetGroupList();

			app.Groups.Create(group);

			// блок проверок
			Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());

			List <GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups.Add(group);
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);
		}


		[Test, TestCaseSource("GroupDataFromXMLFile")]
		public void GroupCreationXMLTest(GroupData group)
		{
			List<GroupData> oldGroups = app.Groups.GetGroupList();

			app.Groups.Create(group);

			// блок проверок
			Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

			List<GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups.Add(group);
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);
		}

		[Test, TestCaseSource("GroupDataFromJSONFile")]
		public void GroupCreationJSONTest(GroupData group)
		{
			List<GroupData> oldGroups = GroupData.GetAll(); 

			app.Groups.Create(group);

			// блок проверок
			Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

			List<GroupData> newGroups = GroupData.GetAll(); 
			oldGroups.Add(group);
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);
		}




		[Test]
		public void BadNameGroupCreationTest()
		{
			GroupData group = new GroupData("g'g");
			group.Header = "";
			group.Footer = "";

			List<GroupData> oldGroups = app.Groups.GetGroupList();

			app.Groups.Create(group);

			// блок проверок
			Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

			List<GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups.Add(group);
			oldGroups.Sort();
			newGroups.Sort();
			//groups.Count;
			Assert.AreEqual(oldGroups, newGroups);
			//app.Auth.Logout();
		}


		[Test]
		public void TestDBConnectivity()
		{
		DateTime start = DateTime.Now;			
		List<GroupData> groupDataFromUI = app.Groups.GetGroupList();
		DateTime end = DateTime.Now;
			System.Console.Out.Write(end.Subtract(start)+ "\r\n");
			//System.Console.Out.Writeline(end.Subtract(start));
			//Console.Writeline(end.Subtract(start));


			start = DateTime.Now;

			List<GroupData> GroupDataFromDB = GroupData.GetAll();
			end = DateTime.Now;
			System.Console.Out.Write(end.Subtract(start) + "\r\n");

			foreach (ContactData gcontact in GroupData.GetAll()[0].GetContacts() )

			{ System.Console.Out.Write(gcontact + "\r\n"); }

		}


	}
}
