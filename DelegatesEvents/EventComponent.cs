namespace DelegatesEvents;

internal class EventComponent
{
	static void Main(string[] args)
	{
		Component c = new();
		c.ProcessCompleted += () => Console.WriteLine("Prozess fertig"); //Parameterlose Action mit () =>
		c.ValueChanged += (x) => Console.WriteLine($"Zähler: {x}"); //Ein Parameter der von unten über das Event zu uns kommt
		c.StartProcess();
	}
}

public class Component
{
	public event Action ProcessCompleted; //Action statt EventHandler

	public event Action<int> ValueChanged; //Action mit einem Parameter

	public void StartProcess()
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			ValueChanged?.Invoke(i);
		}
		ProcessCompleted?.Invoke();
	}
}