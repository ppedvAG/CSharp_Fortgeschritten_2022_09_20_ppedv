namespace Multitasking;

internal class _03_TaskBeenden
{
	static void Main(string[] args)
	{
		CancellationTokenSource cts = new CancellationTokenSource();
		CancellationToken token = cts.Token;

		Task t = new Task(Run, token); //Hier Token direkt übergeben
		t.Start();

		Thread.Sleep(500);

		cts.Cancel();

		Console.ReadKey();
	}

	static void Run(object o)
	{
		if (o is CancellationToken token)
		{
			for (int i = 0; i < 100; i++)
			{
				if (token.IsCancellationRequested)
					token.ThrowIfCancellationRequested(); //Task wirft Exception ist aber nicht sichtbar

				Console.WriteLine($"Task {i}");
				Thread.Sleep(100);
			}
		}
	}
}
