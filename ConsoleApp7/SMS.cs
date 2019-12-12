using System;

namespace ConsoleApp7
{
	internal class SMS
	{

		public void MmNewMail(object sender, NewMailEventArgs e)
		{
			Console.WriteLine($"{sender} {e.From}");
		}

		public void Send(string message)
		{
			Console.WriteLine($"Отправляем SMS сообщение: \r\n{message}\r\n");
		}
	}
}