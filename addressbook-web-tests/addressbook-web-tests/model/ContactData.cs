using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
	{
		private string firstname; // имя v		
		private string lastname; // фамилия v
		//private string middlename = ""; // отчество v
		//private string nickname = ""; // ник v
		//private string title = "";  // название v
		//private string company = "";  // компания v
		//private string address = "";  // адрес v
		//private string home = "";  // домашний тел v
		//private string mobile = ""; // мобильный v
		//private string work = ""; // рабочий v
		//private string email = ""; // email v
		//private string email2 = ""; // email 2 v
		//private string email3 = ""; // email 3 v
		//private string homepage = ""; // сайт? v
		private string bday = "5"; // день рождения v
		private string bmonth = "March"; // месяц рождения v
		private string byear = "1987"; // год рождения v
		private string aday = "-"; // день годовщины v
		private string amonth = "-"; // месяц годовщины v
		private string ayear = "-"; // год годовщины v
		private string new_group = ""; // группа v
		public string allPhones;
		public string allEmails;
		public string fio; // ФИО
		public string contactDetails; // все о контакте
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

		public string Middlename { get; set; }
				
		public string Nickname { get; set; }

		public string Title { get; set; }

		public string Company { get; set; }

		public string Address { get; set; }

		public string Home { get; set; }

		public string Mobile { get; set; }

		public string Work { get; set; }

		public string Email { get; set; }

		public string Email2 { get; set; }

		public string Email3 { get; set; }

		public string Homepage { get; set; }

		public string AllPhones {
			get
			{
				if (allPhones != null) { return allPhones; }
				else { return (CleanUpPhone(Home) + CleanUpPhone(Mobile) + CleanUpPhone(Work)).Trim(); }

			}

			set {	allPhones = value; 	}
		} 


		public string AllEmails
		{
			get
			{
				if (allEmails != null) { return allEmails; }
				else { return (CleanUpPhone(Email) + CleanUpPhone(Email2) + CleanUpPhone(Email3)).Trim(); }
			}

			set
			{ allEmails=value;	}
		}
		public string CleanUpPhone(string phone)
		{
			if (phone == null || phone == "") { return ""; }

			//return Regex.Replace(phone, @"[ -()]", "") + "\r\n";
			return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
		}

		public string Bday

		{
			get	{	return bday;   }			
			set	{	bday = value;	}

		}
		public string Bmonth

		{
			get	{	return bmonth;	}
			set	{	bmonth = value;	}

		}
		public string Byear

		{
			get	{	return byear;	}
			set	{	byear = value;	}

		}
		public string Aday

		{
			get	{	return aday;	}
			set	{	aday = value;	}

		}
		public string Amonth

		{
			get	{	return amonth;	}
			set	{	amonth = value;	}

		}
		public string Ayear

		{
			get	{	return ayear;	}
			set	{	ayear = value;	}

		}
		public string New_group

		{
			get {	return new_group;	}
			set	{	new_group = value;	}

		}


		public string FIO  // кконструктор для ФИО - склейка
		{
			get
			{
				if (fio != null) { return fio; }
				else { return (CleanUpFIO(Firstname) + CleanUpFIO(Middlename) + CleanUpFIO(Lastname)).Trim(); }

			}

			set { fio = value; }
		}
		public string CleanUpFIO(string fio)
		{
			if (fio == null || fio == "") { return ""; }

			//return Regex.Replace(phone, @"[ -()]", "") + "\r\n";
			return fio.Replace("\\r\\n", "")+ " ";
		}

		public string ContactDetails // кконструктор для подробностей - склейка
		{
			get
			{
				if (contactDetails != null) { return contactDetails; }
				else {
					if (Amonth != null) {

						TextInfo ti = new CultureInfo("en-US", false).TextInfo;
						Amonth = ti.ToTitleCase(Amonth);
						 }	
					

				return (Firstname+Middlename+Lastname+Nickname+Title+Company+Address+Home+Mobile+Work+
				Email+Email2+Email3+Homepage+Bday+Bmonth+Byear+Aday+Amonth + Ayear).Trim(); }

			}

			set { contactDetails = value; }
		}

		public string CleanUpDetails(string fio)
		{
			if (fio == null || fio == "") { return ""; }

			//return Regex.Replace(phone, @"[ -()]", "") + "\r\n";
			return fio.Replace("\\r\\n", " ");
		}




		public bool Equals(ContactData other)
		{
			if (Object.ReferenceEquals(other, null))
			{ return false; }
			if (Object.ReferenceEquals(this, other))
			{ return true; }
			return (Firstname == other.Firstname) && (Lastname == other.Lastname);
		}

		public override int GetHashCode()
		{
			int hash = Firstname.GetHashCode()+ Lastname.GetHashCode();
			//return (Firstname.GetHashCode());
			return hash;
		}

		public override string ToString()
		{
			return "Firstname=" + Firstname + "   Lastname=" + Lastname;
		}

		public int CompareTo(ContactData other) //  сравниваем, возвращает -1 0 1
		{
			if (Object.ReferenceEquals(other, null)) //  если объект равен null, будет true, надо вернуть fail
			{	return 1;}
			if (Lastname.CompareTo(other.Lastname)!=0) // если не совпало, то fail
			 {
				int compareL = Lastname.CompareTo(other.Lastname);
				return compareL; // -1 1
			}
			int compareF = Firstname.CompareTo(other.Firstname); // возвращаю сравнение по имени
			return compareF; // -1 0 1
		}		

	

	}
}
