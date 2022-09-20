namespace Generics;

internal class Program
{
	static void Main(string[] args)
	{
		List<string> list = new(); //Generic: T wird nach unten übernommen (hier T = string) 
		list.Add("123"); //T wird durch string ersetzt: Add(T) -> Add(string)

		List<int> intList = new();
		intList.Add(123); //Add(T) -> Add(int)

		Dictionary<string, int> dictionary = new(); //Klasse mit 2 Generics: TKey (string), TValue (int)
		dictionary.Add("123", 123); //Add übernimmt string und int
	}
}

public class DataStore<T> :
	IProgress<T>, //T hier übergeben
	IEquatable<int> //int hier übergeben (fixer Typ)
{
	private T[] data = new T[10]; //Array/Variable vom Typ T

	public List<T> Data => data.ToList(); //T nach unten in ein weiteres Generic übergeben

	public void Add(int idx, T item) => data[idx] = item; //Generic in Methodenparameter

	public T GetIndex(int idx) //T als Rückgabewert
	{
		if (idx < 0 || idx >= data.Length)
			return default(T); //default(T): Standardwert von T (int: 0, string: null, bool: false, ...)
		return data[idx];
	}

	public void PrintType<MyType>() //Generic bei Methode
	{
		Console.WriteLine(typeof(MyType)); //Typ Objekt vom Generic holen
		Console.WriteLine(nameof(MyType)); //String aus MyType erzeugen ("MyType")
		Console.WriteLine(default(MyType));	//Standardwert von MyType

		if (MyType is int) //Nicht möglich
		{

		}

		if (typeof(MyType) == typeof(int)) //Typvergleiche müssen mit typeof(...) gemacht werden
		{

		}
	}

	public void Report(T value) //T als Parameter durch Vererbung
	{
		throw new NotImplementedException();
	}

	public bool Equals(int other) //Hier int statt T da oben hardcoded
	{
		throw new NotImplementedException();
	}
}

public class DataStore2<T> : DataStore<T> { } //Klassen mit T vererben: braucht wieder T beim Klassennamen