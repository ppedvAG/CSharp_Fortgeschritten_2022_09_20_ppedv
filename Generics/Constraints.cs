namespace Generics;

internal class Constraints
{
	public Constraints(int x) { } //Standardkonstruktor wird entfernt wenn ein Konstruktor mit Parameter erstellt wird

	public Constraints() { }

	static void Main(string[] args)
	{
		DataStore4<Constraints> ds4; //Nicht möglich ohne Standardkonstruktor
		DataStore5<DayOfWeek> ds5;
		DataStore5<DayOfWeek.Friday> ds52; //Nicht möglich
	}

	public class DataStore1<T> where T : class { } //Referenztyp erzwingen

	public class DataStore2<T> where T : struct { } //Wertetyp erzwingen

	public class DataStore3<T> where T : Constraints { } //Vererbungshierarchie erzwingen

	public class DataStore4<T> where T : new() { } //Nur Typen die einen Default Konstruktor haben

	public class DataStore5<T> where T : Enum { } //Nur Enums (keine Enumwerte)

	public class DataStore6<T> where T : Delegate { } //Nur Delegatetypen (Action, Predicate, Func, eigenes Delegate, ...)

	public class DataStore7<T> where T : unmanaged { } //Bestimmte Typen (int, bool, double, ...)
	//https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/unmanaged-types

	public class DataStore8<T> where T : class, new() { } //Mehrere Constraints (ein Referenztyp mit Default Konstruktor)

	public class DataStore9<T1, T2> //Mehrere Constraints auf mehrere Generics
		where T1 : class, new()
		where T2 : struct
	{ }

	public class DataStore10<T1, T2, T3, T4, T5, T6> { } //Beliebig viele Generics möglich
}
