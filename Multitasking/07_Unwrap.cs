namespace Multitasking;

internal class _07_Unwrap
{
	static void Main(string[] args)
	{
		Task<Task<int>> verschachtelt = null;
		Task<int> t = verschachtelt.Unwrap(); //Inneren Task entnehmen

		Task<Task<Task<int>>> verschachtelt2 = null;
		Task<int> t2 = verschachtelt2.Unwrap().Unwrap();
	}
}
