using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
	internal class ContactData
	{
		private string firstname; // имя v
		private string lastname; // фамилия v
		private string middlename = ""; // отчество v
		private string nickname = ""; // ник v
		private string title = "";  // название v
		private string company = "";  // компания v
		private string address = "";  // адрес v
		private string home = "";  // домашний тел v
		private string mobile = ""; // мобильный v
		private string work = ""; // рабочий v
		private string email = ""; // email v
		private string email2 = ""; // email 2 v
		private string email3 = ""; // email 3 v
		private string homepage = ""; // сайт? v
		private string bday = "5"; // день рождения v
		private string bmonth = "March"; // месяц рождения v
		private string byear = "1987"; // год рождения v
		private string aday = "-"; // день годовщины v
		private string amonth = "-"; // месяц годовщины v
		private string ayear = "-"; // год годовщины v
		private string new_group = ""; // группа v
		public ContactData(string firstname, string lastname)
		{
			this.firstname = firstname;
			this.lastname = lastname;
		}
		public string Firstname
		{
			get
			{
				return firstname;
			}
			set
			{
				firstname = value;
			}

		}		
		public string Lastname
		{
			get
			{
				return lastname;
			}
			set
			{
				lastname = value;
			}
		}
		public string Middlename

		{
			get
			{
				return middlename;
			}
			set
			{
				middlename = value;
			}

		}
		public string Nickname

		{
			get
			{
				return nickname;
			}
			set
			{
				nickname = value;
			}

		}
		public string Title

		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}

		}
		public string Company

		{
			get
			{
				return company;
			}
			set
			{
				company = value;
			}

		}
		public string Address

		{
			get
			{
				return address;
			}
			set
			{
				address = value;
			}

		}
		public string Home

		{
			get
			{
				return home;
			}
			set
			{
				home = value;
			}

		}
		public string Mobile

		{
			get
			{
				return mobile;
			}
			set
			{
				mobile = value;
			}

		}
		public string Work

		{
			get
			{
				return work;
			}
			set
			{
				work = value;
			}

		}
		public string Email

		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}

		}
		public string Email2

		{
			get
			{
				return email2;
			}
			set
			{
				email2 = value;
			}

		}
		public string Email3

		{
			get
			{
				return email3;
			}
			set
			{
				email3 = value;
			}

		}
		public string Homepage

		{
			get
			{
				return homepage;
			}
			set
			{
				homepage = value;
			}

		}
		public string Bday

		{
			get
			{
				return bday;
			}
			set
			{
				bday = value;
			}

		}
		public string Bmonth

		{
			get
			{
				return bmonth;
			}
			set
			{
				bmonth = value;
			}

		}
		public string Byear

		{
			get
			{
				return byear;
			}
			set
			{
				byear = value;
			}

		}
		public string Aday

		{
			get
			{
				return aday;
			}
			set
			{
				aday = value;
			}

		}
		public string Amonth

		{
			get
			{
				return amonth;
			}
			set
			{
				amonth = value;
			}

		}
		public string Ayear

		{
			get
			{
				return ayear;
			}
			set
			{
				ayear = value;
			}

		}
		public string New_group

		{
			get
			{
				return new_group;
			}
			set
			{
				new_group = value;
			}

		}
	}
}
