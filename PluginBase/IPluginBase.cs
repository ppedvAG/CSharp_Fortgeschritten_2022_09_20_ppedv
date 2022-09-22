namespace PluginBase;

public interface IPlugin
{
	string Name { get; }

	string Description { get; }
}

public interface ICalculatorPlugin : IPlugin
{
	int Addiere(int z1, int z2);

	int Subtrahiere(int z1, int z2);
}