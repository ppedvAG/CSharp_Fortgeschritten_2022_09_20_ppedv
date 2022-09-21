namespace Multithreading;

internal class _05_ThreadMitReturn
{
	static string Text = "Ein Text";

	static string ReturnValue;

	static void Main(string[] args)
	{
		ParameterizedThreadStart pt = new ParameterizedThreadStart(ToUpper);
		Thread t = new Thread(pt);
		t.Start((string ret) => Console.WriteLine(ret)); //Rückgabewert über Callback
	}

	static void ToUpper(object o) //Action
	{
		if (o is Action<string> a)
		{
			a(Text.ToUpper());
			ReturnValue = Text.ToUpper();
		}
	}
}
