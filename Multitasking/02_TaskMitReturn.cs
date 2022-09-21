namespace Multitasking;

internal class _02_TaskMitReturn
{
	static void Main(string[] args)
	{
		Task<int> t = Task.Run(Run); //Task.Run nimmt automatisch Generic an
		Console.WriteLine(t.Result); //.Result blockt den Main Thread (auf Ergebnis warten)
	
		for (int i = 0; i < 100; i++) //Schleife wurde durch Result geblockt
			Console.WriteLine(i);

		Task t2 = Task.Run(() => Console.WriteLine("Etwas")); //Task mit anonymer Methode

		Task t3 = Task.Run(() => //Mehrzeiliger anonymer Task 
		{
			Console.WriteLine("1");
			Console.WriteLine("2");
			Console.WriteLine("3");
		});

		Task<int> t4 = Task.Run(() => Enumerable.Range(0, 1000).Sum()); //Anonymer Task mit Rückgabewert

		t.Wait(); //Warte auf diesen Task
		Task.WaitAll(t2, t3, t4); //Warte auf all diese Tasks
		Task.WaitAny(t2, t3, t4); //Warte auf einen dieser Tasks (int als Rückgabewert welcher Task zuerst fertig geworden ist)
	}

	static int Run()
	{
		int sum = 0;
		for (int i = 0; i < 1000; i++)
			sum += i;
		return sum;
	}
}
