using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB;
//using System.Data.Linq;

namespace WebAddressbookTests

{

	public class AddressbookDB : LinqToDB.Data.DataConnection
	{
		//public AddressbookDB() : base ("Addressbook")	{ }
		public AddressbookDB() : base(ProviderName.MySql, @"server=localhost; database=addressbook; port=3306; Uid=root; Pwd=; charset=utf8; Allow Zero Datetime=true") { }

	public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }
	public ITable<ContactData> Contact { get { return this.GetTable<ContactData>(); } }



	}
}
