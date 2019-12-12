using System;

namespace ConsoleApp7
{
	public class FooEventArgs : EventArgs { }

	public class TypeWithLotsEvents
	{
		protected EventSet EventSet { get; } = new EventSet();

		#region FooEvent
		protected static readonly EventKey fooEventKey = new EventKey();

		public event EventHandler<FooEventArgs> Foo
		{
			add { EventSet.Add(fooEventKey, value); }
			remove { EventSet.Remove(fooEventKey, value); }
		}

		protected virtual void OnFoo(FooEventArgs e)
		{
			EventSet.Raise(fooEventKey, this, e);
		}

		public void SimulateFoo()
		{
			OnFoo(new FooEventArgs());
		}
		#endregion
	}
}
