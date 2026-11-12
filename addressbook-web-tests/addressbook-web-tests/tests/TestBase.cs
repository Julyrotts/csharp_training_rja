using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests

{
	public class TestBase
	{
		protected ApplicationManager app;
				

		[SetUp]
		public void SetupApplicationManager()   // предустановки для тестов
		{
			app= ApplicationManager.GetInstance();  // запустить менеджер приложения
			//app.Auth.Login(new AccountData("admin", "secret"));

		}

		public static Random rnd = new Random(); // генератор случайного числа

		public static string GenerateRandomString(int max)  // генератор случайной строки
		{
		
		int l = Convert.ToInt32 (rnd.NextDouble()*max);  // число от 0 до максимального
		StringBuilder builder = new StringBuilder();  // генератор строки
		for (int i = 0; i<l; i++)
		{
				builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));  // 223 32 коды символов в соответствии с таблицей ASCII
		}

			return  builder.ToString();
		}



	}
}
