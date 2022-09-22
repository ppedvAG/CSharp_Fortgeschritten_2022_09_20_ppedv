using System.Collections.Concurrent;

namespace LinqErweiterungsmethoden;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Erstellt eine Liste von Start mit einer bestimmten Anzahl Elementen
		//(5, 20) -> Start bei 5, 20 Elemente -> 5-24
		List<int> ints = Enumerable.Range(0, 20).ToList();

		Console.WriteLine(ints.Average());
		Console.WriteLine(ints.Min());
		Console.WriteLine(ints.Max());

		Console.WriteLine(ints.Sum());

		Console.WriteLine(ints.First()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(ints.FirstOrDefault()); //null wenn Liste leer

		Console.WriteLine(ints.Last()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(ints.LastOrDefault()); //null wenn Liste leer

		Console.WriteLine(ints.Single(e => e == 2)); //Einziges Element mit Bedingung, Exception wenn leer oder mehr als ein Element
		Console.WriteLine(ints.SingleOrDefault(e => e == 2)); //Einziges Element mit Bedingung, null wenn leer und Exception wenn mehr als ein Element
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs mit Foreach
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnlich Schreibweise (alt)
		List<Fahrzeug> bmws = (from f in fahrzeuge
							   where f.Marke == FahrzeugMarke.BMW
							   select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		#region Linq Methoden
		//Alle Fahrzeuge mit MaxV > 200
		fahrzeuge.Where(e => e.MaxGeschwindigkeit > 200);

		//Alle VWs mit MaxV > 200
		fahrzeuge.Where(e => e.MaxGeschwindigkeit > 200 && e.Marke == FahrzeugMarke.VW);

		fahrzeuge.Select(e => e.MaxGeschwindigkeit);

		//fahrzeuge.Select(e => new Schiff(e.MaxGeschwindigkeit));

		//fahrzeuge.Select(e => (Schiff) e);

		//Autos sortieren nach Automarke
		fahrzeuge.OrderBy(e => e.Marke);

		fahrzeuge.OrderByDescending(e => e.MaxGeschwindigkeit);

		//Nach mehreren Kriterien sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxGeschwindigkeit);

		fahrzeuge.OrderBy(e => e.MaxGeschwindigkeit).First(); //langsamstes
		fahrzeuge.OrderBy(e => e.MaxGeschwindigkeit).Last(); //schnellstes

		//Welche Automarken gibt es?
		fahrzeuge.Select(e => e.Marke).Distinct();

		//Liste einzigartig machen nach Kriterium
		fahrzeuge.DistinctBy(e => e.Marke);

		//Können alle Autos schneller als 200 fahren?
		fahrzeuge.All(e => e.MaxGeschwindigkeit > 200);

		//Gibt es ein Fahrzeug das schneller als 300 fahren kann?
		fahrzeuge.Any(e => e.MaxGeschwindigkeit > 300);

		//Hat die Liste Elemente?
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Zähle die Anzahl an VWs
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW);

		//Die kleinste Geschwindigkeit
		fahrzeuge.Min(e => e.MaxGeschwindigkeit);

		//Das langsamste Fahrzeug
		fahrzeuge.MinBy(e => e.MaxGeschwindigkeit);

		//Liste in 5er Teile aufteilen (letztes Array hat den Rest)
		fahrzeuge.Chunk(5);

		//Überspringe die ersten 3 Fahrzeuge und gib den Rest aus (9 Fahrzeuge)
		fahrzeuge.Skip(3);

		//Die "mittleren" 5
		fahrzeuge.Skip(3).Take(5);

		//Gibt eine neue verkehrte Liste zurück (hier Generic um die Linq Funktion zu erzwingen)
		fahrzeuge.Reverse<Fahrzeug>();

		List<Fahrzeug> concat = new()
		{
			new Fahrzeug(324, FahrzeugMarke.Audi),
			new Fahrzeug(338, FahrzeugMarke.BMW),
			new Fahrzeug(291, FahrzeugMarke.VW)
		};

		//Originale Liste bleibt unverändert
		IEnumerable<Fahrzeug> concatted = fahrzeuge.Concat(concat);
		fahrzeuge = fahrzeuge.Concat(concat).ToList(); //originale Liste anpassen

		//concatted außer die Elemente in der concat Liste
		concatted.Except(concat);

		//Alle Elemente die in beiden Listen enthalten sind
		concat.Intersect(concat);

		//Originale Liste mit einer anderen Liste zu einer Tupel-Liste kombinieren
		fahrzeuge.Zip(Enumerable.Range(0, fahrzeuge.Count));

		//Richtige Reihenfolge (ID links, Fahrzeug rechts)
		IEnumerable<(int ID, Fahrzeug Fzg)> x = Enumerable.Range(0, fahrzeuge.Count).Zip(fahrzeuge);

		//Obere Liste zu einem Dictionary konvertieren
		Dictionary<int, Fahrzeug> dict = x.ToDictionary(x => x.ID, x => x.Fzg);

		//Linq kann auch auf Dictionary angewendet werden
		dict.Where(e => e.Key % 2 == 0);

		//Liste nach Gruppen gruppieren (Audi-Gruppe, BMW-Gruppe, VW-Gruppe)
		IEnumerable<IGrouping<FahrzeugMarke, Fahrzeug>> group = fahrzeuge.GroupBy(e => e.Marke);
		
		//Aus einer Gruppe die Fahrzeuge entnehmen
		group.First().ToList();

		//Group zu einem Dictionary konvertieren
		Dictionary<FahrzeugMarke, List<Fahrzeug>> groupDict = group.ToDictionary(e => e.Key, e => e.ToList());

		string output = fahrzeuge.Aggregate(string.Empty, (agg, fzg) => agg + $"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxGeschwindigkeit} fahren.\n");

		Console.WriteLine(output);

		fahrzeuge.Aggregate(0, (agg, fzg) => agg + fzg.MaxGeschwindigkeit);

		List<List<Fahrzeug>> fahrzeugs = new();
		fahrzeugs.Add(fahrzeuge);
		fahrzeugs.Add(concat);
		fahrzeugs.Add(concatted.ToList());

		//Liste von Listen glätten zu einer einzelnen Liste
		fahrzeugs.SelectMany(e => e);
		#endregion

		#region Erweiterungsmethoden
		328975.Quersumme();
		int zahl = 345829;
		zahl.Quersumme();

		fahrzeuge.OrderBy(e => Random.Shared.Next()); //Liste mischen
		fahrzeuge.Shuffle(); //Neue gemischte Liste

		Console.WriteLine(fahrzeuge[0].Marke.Print());
		#endregion
	}
}

public class Fahrzeug
{
	public int MaxGeschwindigkeit;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxGeschwindigkeit = v;
		Marke = fm;
	}
}

//public class Schiff : Fahrzeug
//{
//	public Schiff(int v, FahrzeugMarke fm) : base(v, fm) { }
//}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}