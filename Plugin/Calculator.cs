using PluginBase;

namespace Plugin;

public class Calculator : ICalculatorPlugin
{
	public string Name { get => "Mein Rechner"; }

	public string Description { get => "Ein Rechner der addieren und subtrahieren kann"; }

	public int Addiere(int z1, int z2)
	{
		return z1 + z2;
	}

	public int Subtrahiere(int z1, int z2)
	{
		return z1 - z2;
	}
}