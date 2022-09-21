namespace Multithreading;

internal class _03_ThreadBeenden
{
	static void Main(string[] args)
	{
		try
		{
			Thread t = new Thread(Run);
			t.Start();

			Thread.Sleep(2000); //Warte 2 Sekunden am Main Thread

			t.Interrupt(); //Beende den Thread, wirft ThreadInterruptedException
			//t.Abort(); //deprecated
		}
		catch (ThreadInterruptedException)
		{
			//Funktioniert hier nicht
		}
	}

	static void Run()
	{
		try
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine(i);
				Thread.Sleep(100); //10 Sekunden insgesamt
			}
		}
		catch (ThreadInterruptedException) //Exception kann nur hier unten gefangen werden
		{
			Console.WriteLine("Thread wurde gestoppt");
		}
	}
}
