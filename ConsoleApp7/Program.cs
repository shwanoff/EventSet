using System;

namespace ConsoleApp7
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var mailManager = new MailManager();
			mailManager.NewMail += MailManagerNewMail;

			var printer = new Printer(mailManager);

			#region
			var sms = new SMS();
			mailManager.NewMail += sms.MmNewMail;


			Console.Write("Введите ваше имя: ");
			var sender = Console.ReadLine();

			Console.Write("С кем вы хотите связаться? Введите имя: ");
			var target = Console.ReadLine();

			Console.WriteLine("Введите текст сообщения:");
			var message = Console.ReadLine();

			mailManager.SimulateNewMail(sender, target, message);
			Console.ReadLine();
			#endregion

			#region
			var typeWithLotsOfEvents = new TypeWithLotsEvents();
			typeWithLotsOfEvents.Foo += TypeWithLotsOfEvents_Foo;
			typeWithLotsOfEvents.SimulateFoo();
			Console.ReadLine();
			#endregion
		}

		private static void TypeWithLotsOfEvents_Foo(object sender, FooEventArgs e)
		{
			Console.WriteLine("Произошло событие Foo!");
		}

		private static void MailManagerNewMail(object sender, NewMailEventArgs e)
		{
		}
	}
}