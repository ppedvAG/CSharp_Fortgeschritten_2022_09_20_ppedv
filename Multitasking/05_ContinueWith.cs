namespace Multitasking;

internal class _05_ContinueWith
{
	static void Main(string[] args)
	{
		Task<int> t1 = Task.Run(() => 1);
		t1.ContinueWith(task => Console.WriteLine(task.Result * 5)); //Tasks verketten, Code wird ausgeführt wenn Originaltask fertig
		t1.ContinueWith(task => Console.WriteLine(task.Result * 10), TaskContinuationOptions.OnlyOnFaulted); //Folgetask, wenn Unhandled Exception
		t1.ContinueWith(task => Console.WriteLine(task.Result * 20), TaskContinuationOptions.OnlyOnRanToCompletion); //Folgetask, wenn keine Exception
		t1.ContinueWith(task => Console.WriteLine(task.Result * 40), TaskContinuationOptions.NotOnFaulted); //Folgetask, wenn keine Unhandled Exception

		Console.ReadKey();
	}
}
