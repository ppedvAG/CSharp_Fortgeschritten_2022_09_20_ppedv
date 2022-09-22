using PluginBase;
using System.Reflection;

namespace PluginClient;

internal class Program
{
	static void Main(string[] args)
	{
		string path = @"C:\Users\lk3\source\repos\CSharp_Fortgeschritten_2022_09_20\Plugin\bin\Debug\net6.0\Plugin.dll";

		Assembly calc = Assembly.LoadFrom(path);

		Type calcType = calc.DefinedTypes.First(e => e.Name == "Calculator");

		ICalculatorPlugin calculator = Activator.CreateInstance(calcType) as ICalculatorPlugin;

		Console.WriteLine(calculator.Addiere(3, 5));
	}
}