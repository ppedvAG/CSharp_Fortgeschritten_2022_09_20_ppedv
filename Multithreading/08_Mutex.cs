namespace Multithreading;

internal class _08_Mutex
{
	static void Main(string[] args)
	{
		Mutex m;
		if (Mutex.TryOpenExisting("08", out m)) //Überprüfen ob Mutex bereits belegt ist
		{
			Console.WriteLine("Anwendung läuft bereits");
			Environment.Exit(0); //Anwendung beenden
		}
		else //Wenn noch nicht belegt
		{
			m = new Mutex(true, "08"); //Mutex belegen
		}

		m.ReleaseMutex(); //Mutex entfernen bei beenden der Applikation
	}
}
