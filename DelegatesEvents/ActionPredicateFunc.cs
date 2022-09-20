namespace DelegatesEvents;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Addiere; //Action: Methode mit void und bis zu 16 Parametern
		action += Subtrahiere; //Methode anhängen
		action(4, 6); //Aufruf wie bei Delegate
		action?.Invoke(4, 2); //Ausführen mit Null-Check

		DoSomething(5, 2, Addiere); //Verhalten von Methoden anpassen
		DoSomething(5, 2, Subtrahiere); //Unterschiedliche Actions als Parameter
		DoSomething(5, 2, action); //Action Parameter mit mehreren Methoden

		Predicate<int> predicate = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		predicate += CheckForOne; //Letztes Ergebnis wird in Variable geschrieben
		bool b = predicate(3); //Ergebnis in bool Variable schreiben
		bool? b2 = predicate?.Invoke(0); //Hier bool? weil ?.Invoke könnte null sein wenn Predicate null ist

		DoSomething(3, CheckForZero);
		DoSomething(3, CheckForOne);

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert, bis zu 16 Parameter, Rückgabe muss letztes Generic sein
		func += Dividiere;
		double d = func(8, 3); //Hier auch wieder letztes Ergebnis
		double? d2 = func?.Invoke(8, 3); //Zuweisung wie bei Predicate

		DoSomething(3, 2, Multipliziere);
		DoSomething(3, 2, Dividiere);

		func += delegate (int x, int y) { return x + y; }; //Anonyme Methode

		func += (int x, int y) => { return x + y; }; //Kürzere Form

		func += (x, y) => { return x - y; };

		func += (x, y) => (double) x / y;

		Action<int, int> a = (int x, int y) => Console.WriteLine(x + y); //Anonyme Methode
		a += (x, y) => Console.WriteLine(x - y);

		DoSomething(3, 7, (x, y) => Console.WriteLine(x + y)); //Anonyme Action
		DoSomething(3, (x) => x != 0); //Anonymes Predicate
		DoSomething(3, 7, (x, y) => x * y); //Anonyme Func
	}

	#region Action
	private static void Addiere(int arg1, int arg2) => Console.WriteLine(arg1 + arg2);

	private static void Subtrahiere(int arg1, int arg2) => Console.WriteLine(arg1 - arg2);

	private static void DoSomething(int z1, int z2, Action<int, int> action) => action?.Invoke(z1, z2);
	#endregion

	#region Predicate
	private static bool CheckForZero(int z) => z == 0;

	private static bool CheckForOne(int z) => z == 1;

	private static bool DoSomething(int z, Predicate<int> pred) => pred(z);
	#endregion

	#region Func
	private static double Multipliziere(int z1, int z2) => z1 * z2;

	private static double Dividiere(int arg1, int arg2) => (double) arg1 / arg2;

	private static double DoSomething(int z1, int z2, Func<int, int, double> func) => func(z1, z2);
	#endregion
}
