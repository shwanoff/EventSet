using System;

namespace ConsoleApp7
{
	internal class Printer
	{
		public Printer(MailManager mailManager)
		{
			mailManager.NewMail += OnNewMailEvent;
			//mailManager.add_NewMail(new EventHandler<NewMailEventArgs>(OnNewMailEvent));
		}

		private void OnNewMailEvent(object sender, NewMailEventArgs e)
		{
			Console.WriteLine("Получено новое сообщение. Выводим на печать:");
			Console.WriteLine($"Письмо от {e.From} для {e.To}.");
			Console.WriteLine(e.Subject);
		}

		public void Unregister(MailManager mailManager)
		{
			mailManager.NewMail -= OnNewMailEvent;
		}
	}
}