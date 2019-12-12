using System;

namespace ConsoleApp7
{
	internal class MailManager
	{
		public event EventHandler<NewMailEventArgs> NewMail;

		#region
		//private EventHandler<NewMailEventArgs> NewMail = null;

		//public void add_NewMail(EventHandler<NewMailEventArgs> value)
		//{
		//	EventHandler<NewMailEventArgs> prevHandler;
		//	var newMail = NewMail;
		//	do
		//	{
		//		prevHandler = newMail;
		//		var newHandler = (EventHandler<NewMailEventArgs>)Delegate.Combine(prevHandler, value);
		//		newMail = Interlocked.CompareExchange(ref NewMail, newHandler, prevHandler);

		//	}
		//	while(newMail != prevHandler);
		//}

		//public void remove_NewMail(EventHandler<NewMailEventArgs> value)
		//{
		//	EventHandler<NewMailEventArgs> prevHandler;
		//	var newMail = NewMail;
		//	do
		//	{
		//		prevHandler = newMail;
		//		var newHandler = (EventHandler<NewMailEventArgs>)Delegate.Remove(prevHandler, value);
		//		newMail = Interlocked.CompareExchange(ref NewMail, newHandler, prevHandler);

		//	}
		//	while(newMail != prevHandler);
		//}
		#endregion
		protected virtual void OnNewMail(NewMailEventArgs e)
		{
			//_ = e ?? throw new ArgumentNullException(nameof(e));

			// Вариант 1
			// Может быть уязвимость при многопоточности
			//NewMail?.Invoke(this, e);

			// Вариант 2
			// Решает проблему, но поведение компилятора может измениться
			var temp = NewMail;
			temp?.Invoke(this, e);

			// Сохранить ссылку на делегата во временной переменной
			// для обеспечения безопасности потоков
			//Volatile.Read(ref NewMail)?.Invoke(this, e);
		}

		public void SimulateNewMail(string from, string to, string subject)
		{
			// Проверить входные данные на корректность.

			// Создать объект для хранения информации, которую
			// нужно передать получателям уведомления
			var e = new NewMailEventArgs(from, to, subject);

			// Вызвать виртуальный метод, уведомляющий объект о событии
			// Если ни один из производных типов не переопределяет этот метод,
			// объект уведомит всех зарегистрированных получателей уведомления
			OnNewMail(e);
		}
	}
}