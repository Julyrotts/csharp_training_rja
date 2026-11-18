using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;
using Excel = Microsoft.Office.Interop.Excel;


namespace addressbook_test_data_generators
{
	internal class Program
	{
		static void Main(string[] args)
		{

			System.Console.Out.Write("Manual. Please enter 4 params:");
			System.Console.Out.Write("data type: group or contact");
			System.Console.Out.Write("quantity of test elements: integer");
			System.Console.Out.Write("file name: xxxxx.xxx");
			System.Console.Out.Write("file extension");
			string dataType = args[0];
			int count = Convert.ToInt32(args[1]);
			string filename = args[2];
			string format = args[3];

			if (dataType == "group")
			{

				List<GroupData> groups = new List<GroupData>();
				for (int i = 0; i < count; i++)
				{
					groups.Add(new GroupData(TestBase.GenerateRandomString(10))
					{
						Header = TestBase.GenerateRandomString(10),
						Footer = TestBase.GenerateRandomString(10)
					});

					/*	writer.WriteLine(String.Format("${0},${1},${2}",
						TestBase.GenerateRandomString(10),
						TestBase.GenerateRandomString(10),
						TestBase.GenerateRandomString(10)));*/
				}


				if (format == "excel")
				{
					WriteGroupsToExcelFile(groups, filename);
				}
				else
				{
					StreamWriter writer = new StreamWriter(filename);

					if (format == "csv")
					{ WriteGroupsToCsvFile(groups, writer); }
					else if (format == "xml")
					{ WriteGroupsToXMLFile(groups, writer); }
					else if (format == "json")
					{ WriteGroupsToJSONFile(groups, writer); }
					else
					{ System.Console.Out.Write("Unrecognized format - " + format); }

					writer.Close();
				}
			}

			if (dataType == "contact")
			{

				List<ContactData> contact = new List<ContactData>();
				for (int i = 0; i < count; i++)
				{
					contact.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
					{
						Middlename = TestBase.GenerateRandomString(10),
						Nickname = TestBase.GenerateRandomString(10),
						Address = TestBase.GenerateRandomString(30),
						Home = TestBase.GenerateRandomString(10),
						Mobile = TestBase.GenerateRandomString(10),
						Work = TestBase.GenerateRandomString(10),
						Email = TestBase.GenerateRandomString(10),
						Email2 = TestBase.GenerateRandomString(20),
						Email3 = TestBase.GenerateRandomString(20),
						Title = TestBase.GenerateRandomString(10),
						Company = TestBase.GenerateRandomString(20),
						Homepage = TestBase.GenerateRandomString(10)

					});

				}

				StreamWriter writer = new StreamWriter(filename);

				if (format == "csv")
				{ WriteContactToCsvFile(contact, writer); }
				else if (format == "xml")
				{ WriteContactToXMLFile(contact, writer); }
				else if (format == "json")
				{ WriteContactToJSONFile(contact, writer); }
				else
				{ System.Console.Out.Write("Invalid format - " + format);
				  System.Console.Out.Write("Contacts accepts only csv, xml or json");
				}

				writer.Close();
			}

			else
			{
			System.Console.Out.Write("One or more input error. Manual. Please enter 4 params:");
			System.Console.Out.Write("data type: group or contact");
			System.Console.Out.Write("quantity of test elements: integer");
			System.Console.Out.Write("file name: xxxxx.xxx");
			System.Console.Out.Write("file extension"); 
			 }

		}

		static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
		{ 
		foreach (GroupData group in groups) 
		{
				writer.WriteLine(String.Format("${0},${1},${2}",
				group.Name, group.Header, group.Footer));
		}
		}

		static void WriteGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
		{
			new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
		
		}

		static void WriteGroupsToJSONFile(List<GroupData> groups, StreamWriter writer)
		{
			writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));

		}


		static void WriteGroupsToExcelFile(List<GroupData> groups, string filename)
		{
			Excel.Application app = new Excel.Application();
			app.Visible= true;
			Excel.Workbook wb = app.Workbooks.Add();
			Excel.Worksheet sheet = wb.ActiveSheet;

			int row = 1;
			foreach (GroupData group in groups)
			{
				sheet.Cells[row, 1] = group.Name;
				sheet.Cells[row, 2] = group.Header;
				sheet.Cells[row, 3] = group.Footer;
				row++;
			}
			
			string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
			File.Delete(fullpath);
			wb.SaveAs(fullpath);
			wb.Close();
			app.Visible = false;
			app.Quit();
		}

		static void WriteContactToCsvFile(List<ContactData> contacts, StreamWriter writer)
		{
			foreach (ContactData contact in contacts)
			{
				writer.WriteLine(String.Format("${0},${1},${2},${3}",
				contact.Firstname, contact.Lastname, contact.Mobile, contact.Email));
			}
		}

		static void WriteContactToXMLFile(List<ContactData> contact, StreamWriter writer)
		{
			new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contact);

		}

		static void WriteContactToJSONFile(List<ContactData> contact, StreamWriter writer)
		{
			writer.Write(JsonConvert.SerializeObject(contact, Newtonsoft.Json.Formatting.Indented));

		}


	}
}
