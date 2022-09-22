using System.Collections;
using System.Diagnostics;
using System.Text;

Zug z = new();
z++;
z++;
z++;
z++;

Zug z2 = new();
z2++;
z2++;

z += z2;
Console.WriteLine();

foreach (Wagon w in z)
{
	Console.WriteLine(w.ToString());
}

//z[3] = new Wagon();
//Console.WriteLine(z[20, "Rot"].ToString());

Stopwatch sw = Stopwatch.StartNew();
string str = "";
for (int i = 0; i < 1000; i++)
	str += i;
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds); //61s

Stopwatch sw2 = Stopwatch.StartNew();
StringBuilder sb = new();
for (int i = 0; i < 1000000; i++)
	sb.Append(i);
sb.ToString();
sw2.Stop();
Console.WriteLine(sw2.ElapsedMilliseconds);//150ms

System.Timers.Timer t = new System.Timers.Timer();
t.Elapsed += (sender, e) => Console.WriteLine("Eine Sekunde vergangen");
t.Interval = 1000;
t.Start();

Console.ReadKey();

public class Zug : IEnumerable
{
	private List<Wagon> wagons = new();

	public Zug()
	{
		//var x = wagons.Select(e => new { e.Farbe, HC = e.GetHashCode() });
		//Console.WriteLine(x.First().HC);
	}

	public static Zug operator ++(Zug z)
	{
		z.wagons.Add(new Wagon());
		return z;
	}

	public static Zug operator +(Zug z1, Zug z2)
	{
		z1.wagons.AddRange(z2.wagons);
		z2.wagons.Clear();
		return z1;
	}

	public IEnumerator GetEnumerator()
	{
		return wagons.GetEnumerator();
	}

	public Wagon this[int x]
	{
		get => wagons[x];
		set => wagons[x] = value;
	}

	public Wagon this[int sitze, string farbe]
	{
		get => wagons.First(e => e.AnzSitze == sitze && e.Farbe == farbe);
	}
}

public class Wagon
{
	public int AnzSitze { get; set; }

	public string Farbe { get; set; }

	public static bool operator ==(Wagon w1, Wagon w2)
	{
		return w1.AnzSitze == w2.AnzSitze && w1.Farbe == w2.Farbe; 
	}

	public static bool operator !=(Wagon w1, Wagon w2)
	{
		return !(w1 == w2);
	}
}