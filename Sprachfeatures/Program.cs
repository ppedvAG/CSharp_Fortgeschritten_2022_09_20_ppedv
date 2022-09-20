using System.Text.Json.Serialization;

namespace Sprachfeatures;

[Serializable]
internal class Program
{
	static void Main(string[] args)
	{
		object o = null;
		switch (o)
		{
			case int i:
				break;
			case double i:
				break;
		}

		var (x, y) = ("", "");
		Console.WriteLine(x);
		Console.WriteLine(y);

		int z = 3_8_6_3_8_2_5_7_9;
		Console.WriteLine(z);

		double d = 38272.32_847;

		Test(0, 1, z: 3);

		string def = default;

		string name = "max";
		string upperCase = char.ToUpper(name[0]) + name[1..];
		Console.WriteLine(upperCase);

		string test = $"Mein name ist {upperCase} {name} {z}"; //Im string Code schreiben
		Console.WriteLine(test);

		string verbatim = @"\n \\"; //String wird genau so geschrieben wie er hier steht
		Console.WriteLine(verbatim);

		string pfad = "C:\\Users\\User";
		string pfad2 = @"C:\Users\lk3\Lokal"; //Vorallem für Pfade nützlich

		Program p = null;

		#region Test

		#endregion

		Dictionary<string, string> map = new();

		Person p1 = new(2, null) { ID = 2 }; //Init hier auch möglich
		//p1.ID = 3; //Init hier nicht möglich

		switch(z)
		{
			case > 10 and < 20: //boolsche Logik im Switch (kein && und ||)
				break;
			case 30 or 40: //or statt ||
				break;
		}

		//if ({ p1.Vorgesetzter.Vorgesetzter }) Statt {{{}}} einfach mit Punkten tiefer gehen
	}

	public static void Test(int w = 0, int x = 0, int y = 0, int z = 0) => Console.WriteLine(x + y + z);
}

//public class Person
//{
//	public int ID { get; init; } = 4; //Init hier möglich

//	public Person()
//	{
//		ID = 4; //Init hier auch möglich
//	}
//}

public record Person
(
	[field: JsonIgnore] int ID, //Um Properties im Record ein Attribut zu geben wird field: benötigt
	Person Vorgesetzter
); //selbiges wie oben nur in einer Zeile, kann geöffnet werden und anderen Code enthalten
