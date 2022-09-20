using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;
using static System.Environment;

namespace Serialisierung;

internal class Program
{
	static void Main(string[] args)
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//StreamWriterReader();

		//NewtonsoftJson();

		//SystemJson();

		//Xml();

		//Binary();

		//CSV();
	}

	public static void StreamWriterReader()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		using (StreamWriter sw = new StreamWriter(filePath) { AutoFlush = true }) //Stream öffnen zu Pfad, AutoFlush: Nach jedem WriteLine in das File schreiben
		{
			sw.WriteLine("Test1"); //Stream füllen
			sw.WriteLine("Test2"); //Stream füllen
			sw.WriteLine("Test3"); //Stream füllen
			sw.Flush(); //Streaminhalt in das File schreiben
		}

		using StreamReader sr = new StreamReader(filePath);

		List<string> allLines = new();
		string currentLine = sr.ReadLine();
		allLines.Add(currentLine);
		while (!sr.EndOfStream) //File Zeile für Zeile einlesen
		{
			currentLine = sr.ReadLine();
			allLines.Add(currentLine);
		}

		sr.BaseStream.Position = 0; //Stream auf Position 0 zurücksetzen

		string str = sr.ReadToEnd(); //Alles einlesen
		List<string> lines = str.Split(Environment.NewLine).ToList(); //Aus gesamtem string eine Liste von Zeilen machen
	}

	public static void NewtonsoftJson()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//JsonSerializerSettings jss = new() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Objects }; //TypeNameHandling: Vererbungshierarchie beachten

		//string json = JsonConvert.SerializeObject(fahrzeuge, jss); //Json String aus Objektliste generieren (Alle Felder zum Serialisieren müssen Properties sein)
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath); //Json einlesen
		//List<Fahrzeug> readFzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson);

		//JToken jt = JToken.Parse(readJson); //JToken erzeugen zum navigieren vom Json
		//foreach (JToken children in jt.Children()) //children = einzelne Fahrzeuge
		//{
		//	Console.WriteLine(children["ID"].Value<int>()); //mit [] auf Property vom Objekt zugreifen, mit .Value<T>() Rückgabewert von [] konvertieren

		//	Fahrzeug f = JsonConvert.DeserializeObject<Fahrzeug>(children.ToString()); //Einzelnen Token zu Objekt machen
		//}
	}

	public static void SystemJson()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//string json = JsonSerializer.Serialize(fahrzeuge);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson);

		//JsonDocument doc = JsonDocument.Parse(json); //JsonDocument statt JToken
		//ArrayEnumerator ae = doc.RootElement.EnumerateArray(); //Json Elemente als "Liste" speichern
		//foreach (JsonElement je in ae) //JsonElement statt JToken
		//{
		//	Console.WriteLine(je.GetProperty("ID").GetInt32());

		//	Fahrzeug f = je.Deserialize<Fahrzeug>(); //Hier JsonElement direkt deserialisieren
		//}
	}

	public static void Xml()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		XmlSerializer xmlS = new XmlSerializer(fahrzeuge.GetType()); //typeof(List<Fahrzeug>)
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
		{
			xmlS.Serialize(fs, fahrzeuge);
		}

		using (FileStream rs = new FileStream(filePath, FileMode.Open))
		{
			List<Fahrzeug> readFzg = xmlS.Deserialize(rs) as List<Fahrzeug>;
		}

		XmlDocument doc = new XmlDocument();
		doc.LoadXml(File.ReadAllText(filePath));

		foreach (XmlNode node in doc.ChildNodes[1].OfType<XmlNode>()) //Fahrzeuge in einer Liste
		{
			Console.WriteLine(node.ChildNodes.OfType<XmlNode>().First(e => e.Name == "MaxGeschwindigkeit").InnerText); //ChildNodes um Werte zu iterieren, InnerText um Wert zu holen
		}
	}

	public static void Binary()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		BinaryFormatter formatter = new();
		using FileStream fs = new FileStream(filePath, FileMode.Create);
		formatter.Serialize(fs, fahrzeuge);

		using FileStream rs = new FileStream(filePath, FileMode.Open);
		List<Fahrzeug> readFzg = formatter.Deserialize(rs) as List<Fahrzeug>; //1:1 wie bei Xml
	}

	public static void CSV()
	{
		string desktop = GetFolderPath(SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		TextFieldParser tfp = new(filePath);
		tfp.SetDelimiters(";");
		List<string> lines = tfp.ReadToEnd().Split(Environment.NewLine).ToList();

		string str = fahrzeuge.Aggregate("", (agg, fzg) => agg + $"{string.Join(';', fzg.GetType().GetProperties().Select(e => e.GetValue(fzg)))}{Environment.NewLine}"); //CSV aus Liste erstellen
	}
}

//public record Fahrzeug(int ID, int MaxGeschwindigkeit, FahrzeugMarke Marke);

[Serializable] //Für Binary notwendig
public class Fahrzeug
{
	//[JsonIgnore] //Ignoriere dieses Feld beim Json Serialisieren (bei beiden Frameworks)
	[JsonPropertyName("Identifier")] //Feld beim Serialisieren einen anderen Namen geben (System.Text)
	[JsonProperty("Identifier")] //Feld beim Serialisieren einen anderen Namen geben (Newtonsoft)
	public int ID { get; set; }

	[field: NonSerialized] //Binary ignore
	public int MaxGeschwindigkeit { get; set; }

	[XmlIgnore]
	[XmlAttribute] //Attribut statt Feld
	[XmlElement("Marke")] //Eigenen Namen festlegen für Feld
	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int id, int v, FahrzeugMarke fm)
	{
		ID = id;
		MaxGeschwindigkeit = v;
		Marke = fm;
	}

	public Fahrzeug() { } //Für XML
}

public enum FahrzeugMarke { Audi, BMW, VW }