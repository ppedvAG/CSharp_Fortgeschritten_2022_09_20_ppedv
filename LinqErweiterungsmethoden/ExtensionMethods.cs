namespace LinqErweiterungsmethoden;

internal static class ExtensionMethods
{
	public static int Quersumme(this int x) //Mit this sich auf einen Typen beziehen
	{
		return x.ToString().ToCharArray().Sum(e => (int) char.GetNumericValue(e));
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list) //Eigene Linq Methode
	{
		return list.OrderBy(e => Random.Shared.Next());
	}

	public static string Print(this FahrzeugMarke fm) //Enums Funktionen geben
	{
		return fm switch
		{
			FahrzeugMarke.Audi => "Audi",
			FahrzeugMarke.BMW => "BMW",
			FahrzeugMarke.VW => "VW",
			_ => ""
		};
	}
}
