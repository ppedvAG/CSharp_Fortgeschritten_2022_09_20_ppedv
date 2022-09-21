namespace Multithreading;

internal class _07_Lock
{
	static int Zahl { get; set; } = 0;

	static object LockObject = new();

	static void Main(string[] args)
	{
		for (int i = 0; i < 1000; i++)
		{
			new Thread(ZahlPlusPlus).Start();
		}
	}

	static void ZahlPlusPlus()
	{
		for (int i = 0; i < 100; i++)
		{
			lock (LockObject) //Zahl sperren damit nicht mehrere Threads gleichzeitig draufgreifen
			{
				Zahl++;
				Console.WriteLine(Zahl); //Kein Lock/Monitor sollte Crash verursachen
			} //Lock öffnen

			Monitor.Enter(LockObject); //Monitor und Lock haben 1:1 den selben Code
			Zahl++;
			Console.WriteLine(Zahl);
			Monitor.Exit(LockObject);
		}
	}
}
