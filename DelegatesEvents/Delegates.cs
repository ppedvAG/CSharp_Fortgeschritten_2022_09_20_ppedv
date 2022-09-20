namespace DelegatesEvents;

internal class Delegates
{
	public delegate void Vorstellungen(string name); //Definition von Delegate, speichert Referenzen zu Methoden, können zur Laufzeit hinzugefügt oder weggenommen werden

	static void Main(string[] args)
	{
		Vorstellungen vorstellungen; //Variable
		vorstellungen = new Vorstellungen(VorstellungDE); //Delegate erstellen mit new und Initialmethode
		vorstellungen("Max"); //Delegate ausführen mit vorstellungen(parameter)

		vorstellungen += new Vorstellungen(VorstellungEN); //Methode anhängen (lang)
		vorstellungen += VorstellungEN; //Kurzform, Methoden können mehrmals angehängt werden
		vorstellungen("Max"); //Alle Methoden werden nacheinander ausgeführt

		vorstellungen -= VorstellungDE; //Methode abhängen mit -=
		vorstellungen -= VorstellungDE;
		vorstellungen -= VorstellungDE;
		vorstellungen -= VorstellungDE; //Methode die nicht dranhängt abnehmen bringt keine Fehlermeldung
		vorstellungen("Max");

		vorstellungen -= VorstellungEN;
		vorstellungen -= VorstellungEN; //Delegate ohne Methode wird null
		vorstellungen("Max"); //Exception

		if (vorstellungen is not null) //Null-Check
			vorstellungen("Max");

		vorstellungen.Invoke("Max");
		vorstellungen?.Invoke("Max"); //? vor . ist ein einfacher Null-Check (Methode wird nicht ausgeführt wenn null)

		vorstellungen = null; //Delegate entleeren

		foreach (Delegate dg in vorstellungen.GetInvocationList()) //Delegate iterieren
		{
			Console.WriteLine(dg.Method.Name); //mit dg.Method in die Methode reinschauen
		}
	}

	public static void VorstellungDE(string name) => Console.WriteLine($"Hallo mein Name ist {name}");

	public static void VorstellungEN(string name) => Console.WriteLine($"Hello my name is {name}");
}