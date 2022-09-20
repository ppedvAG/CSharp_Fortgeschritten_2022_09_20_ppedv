namespace DelegatesEvents;

internal class Events
{
	static event EventHandler TestEvent;

	static event EventHandler<TestEventArgs> ArgsEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Extra Methode anhängen ohne new, Events können nicht erstellt werden
		TestEvent(null, EventArgs.Empty);

		TestEvent += (sender, args) => Console.WriteLine("Test"); //Anonym eine Methode anhängen
		TestEvent?.Invoke(null, EventArgs.Empty); //Auch mit Invoke aufrufbar wie bei Delegate

		ArgsEvent += Events_ArgsEvent;
		ArgsEvent(null, new TestEventArgs() { Status = "Ein Status" }); //Eigenes EventArgs übergeben

		TestEvent(null, new TestEventArgs()); //TestEventArgs hier auch möglich da Vererbungshierarchie
	}

	private static void Events_TestEvent(object sender, EventArgs e) => Console.WriteLine("Test");

	private static void Events_ArgsEvent(object sender, TestEventArgs e)
	{
		Console.WriteLine(e.Status);
		e.Test();
	}
}

internal class TestEventArgs : EventArgs
{
	public string Status { get; set; }

	public void Test() => Console.WriteLine(Status);
}