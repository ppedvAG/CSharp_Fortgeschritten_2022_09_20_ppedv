using System.Reflection;

namespace Reflection;

internal class Program
{
	public string EinString;

	public int EinInt { get; set; }

	static void Main(string[] args)
	{
		//Program p = new Program();
		//Type pt = p.GetType(); //Typ holen mit GetType() über Objekt

		Type t = typeof(Program); //Typ holen durch typeof(Klassenname)

		object o = Activator.CreateInstance(t); //Objekt erstellen über Type

		t.GetMethod("Test").Invoke(o, null); //Methode aufrufen über Type mit Objekt als Parameter

		t.GetMethod("Test2").Invoke(o, new[] { "Zwei Test" }); //Methode aufrufen mit Parameter

		t.GetField("EinString").SetValue(o, "Drei Test"); //Feld ansprechen und Wert setzen

		Console.WriteLine(t.GetField("EinString").GetValue(o) as string); //Wert auslesen aus Feld

		t.GetProperty("EinInt").SetValue(o, 23);

		t.GetProperty("EinInt").GetValue(o);

		object o2 = Activator.CreateInstance("Reflection", "Reflection.Program"); //Objekt nur über Strings erstellen

		Assembly a = Assembly.GetExecutingAssembly(); //Derzeitiges Assembly holen

		List<TypeInfo> types = a.DefinedTypes.ToList(); //Alle Types aus dem Assembly auslesen

		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_09_20\DelegatesEvents\bin\Debug\net6.0\DelegatesEvents.dll";

		Assembly de = Assembly.LoadFrom(path); //DLL laden

		Type componentType = de.DefinedTypes.First(e => e.Name == "Component").AsType(); //Typ der Komponente
		
		object component = Activator.CreateInstance(componentType); //Objekt von Komponente erstellen
		component.GetType().GetEvent("ProcessCompleted").AddEventHandler(component, () => Console.WriteLine("Prozess fertig")); //Events registrieren
		component.GetType().GetEvent("ValueChanged").AddEventHandler(component, (int i) => Console.WriteLine($"Prozessfortschritt: {i}"));
		component.GetType().GetMethod("StartProcess").Invoke(component, null); //Methode aufrufen
	}

	public void Test() => Console.WriteLine("Ein Test");

	public void Test2(string output) => Console.WriteLine(output);
}