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

string s = args[0]; //Auf args zugreifen mit dem Args Keyword


void Test(int w = 0, int x = 0, int y = 0, int z = 0) => Console.WriteLine(x + y + z);

public class Person { } //Klassen/Enums müssen darunter sein