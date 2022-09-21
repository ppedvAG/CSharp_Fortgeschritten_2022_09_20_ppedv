﻿namespace Multitasking;

internal class _04_TaskExceptions
{
	static void Main(string[] args)
	{
		try
		{
			Task t1, t2, t3, t4;

			t1 = Task.Run(Exception1);
			t2 = Task.Run(Exception2);
			t3 = Task.Run(Exception3);
			t4 = Task.Run(KeineException);

			Task.WaitAll(t1, t2, t3, t4); //Auf Tasks warten um Exceptions zu sehen

			if (t1.IsFaulted) { } //Wenn eine Exception aufgetreten ist und diese nicht gehandled wurde

			if (t2.IsCanceled) { } //Wenn mit Token gecancelled

			if (t3.IsCompleted) { } //Wenn Task fertig ist, egal ob gecrasht oder nicht

			if (t4.IsCompletedSuccessfully) { } //Ohne Exception fertig
		}
		catch (AggregateException e)
		{
			foreach (Exception ex in e.InnerExceptions)
				Console.WriteLine(ex.Message);
		};
	}

	static void Exception1()
	{
		Thread.Sleep(1000);
		throw new DivideByZeroException();
	}

	static void Exception2()
	{
		Thread.Sleep(2000);
		throw new StackOverflowException();
	}

	static void Exception3()
	{
		Thread.Sleep(3000);
		throw new OutOfMemoryException();
	}

	static void KeineException()
	{
		Console.WriteLine("Alles OK");
	}
}
