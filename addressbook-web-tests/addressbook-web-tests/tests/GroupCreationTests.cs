using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]
	public class GroupCreationTests : AuthTestBase
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
			//List<GroupData> groups = new List<GroupData>();
			//string[] lines = File.ReadAllLines(@"group.csv");
			return (List<GroupData>) 
			new XmlSerializer(typeof(List<GroupData>)).
			Deserialize(new StreamReader(@"groups.xml"));
			
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

	}
}
