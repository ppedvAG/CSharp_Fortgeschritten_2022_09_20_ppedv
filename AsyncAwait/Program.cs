using System.Diagnostics;

namespace AsyncAwait;

internal class Program
{
	static async Task Main(string[] args)
	{
		//Stopwatch sw = Stopwatch.StartNew(); //Sequentiell, ineffizient
		//Toast();
		//Geschirr();
		//Kaffee();
		//sw.Stop();
		//Console.WriteLine(sw.ElapsedMilliseconds); //7s

		//Stopwatch sw2 = Stopwatch.StartNew();
		//Task.Run(Toast);
		//Task.Run(Geschirr);
		//Task.Run(Kaffee);
		//sw2.Stop();
		//Console.WriteLine(sw2.ElapsedMilliseconds); //65ms, Main Thread läuft weiter

		//Stopwatch sw2 = Stopwatch.StartNew();
		//ToastTaskAsync(); //Methoden werden als Tasks ausgeführt weil sie als async gekennzeichnet sind
		//GeschirrTaskAsync();
		//KaffeeTaskAsync();
		//sw2.Stop();
		//Console.WriteLine(sw2.ElapsedMilliseconds); //65ms, Main Thread läuft weiter

		Stopwatch sw2 = Stopwatch.StartNew();
		//Toast t = await ToastAsync(); //Objekt aus Task entnehmen mit await <Task>, wenn der Task fertig ist kommt das Objekt heraus
		Task<Toast> toastTask = ToastAsync();
		Task<Tasse> tasseTask = GeschirrAsync();
		Tasse tasse = await tasseTask; //Erstmal warten bis Tasse fertig ist
		Task<Kaffee> kaffeeTask = KaffeeAsync(tasse); //KaffeeAsync(await tasseTask); auch möglich
		Kaffee k = await kaffeeTask;
		Toast t = await toastTask;
		sw2.Stop();
		Console.WriteLine(sw2.ElapsedMilliseconds); //4s
	}

	static void Toast()
	{
		Thread.Sleep(4000);
		Console.WriteLine("Toast fertig");
	}

	static void Geschirr()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static void Kaffee()
	{
		Thread.Sleep(1500);
		Console.WriteLine("Kaffee zubereitet");
	}

	static async void ToastTaskAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
	}

	static async void GeschirrTaskAsync()
	{
		await Task.Delay(2000);
		Console.WriteLine("Geschirr hergerrichtet");
	}

	static async void KaffeeTaskAsync()
	{
		await Task.Delay(2000);
		Console.WriteLine("Kaffee zubereitet");
	}

	static async Task<Toast> ToastAsync()
	{
		await Task.Delay(4000);
		Console.WriteLine("Toast fertig");
		return new Toast();
	}

	static async Task<Tasse> GeschirrAsync()
	{
		await Task.Delay(1500);
		Console.WriteLine("Geschirr hergerrichtet");
		return new Tasse();
	}

	static async Task<Kaffee> KaffeeAsync(Tasse t)
	{
		await Task.Delay(1500);
		Console.WriteLine("Kaffee zubereitet");
		return new Kaffee();
	}
}

public class Toast { }

public class Tasse { }

public class Kaffee { }