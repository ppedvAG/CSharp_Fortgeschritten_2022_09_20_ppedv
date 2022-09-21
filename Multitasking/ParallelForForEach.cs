using System.Diagnostics;

namespace Multitasking;

internal class ParallelForForEach
{
	static void Main(string[] args)
	{
		int[] durchgänge = { 1000, 10000, 50000, 100000, 250000, 500000, 1000000, 5000000, 10000000, 100000000 };
		foreach (int i in durchgänge)
		{
			Stopwatch sw = Stopwatch.StartNew();
			RegularFor(i);
			sw.Stop();
			Console.WriteLine($"For Durchgänge {i}: {sw.ElapsedMilliseconds}");

			Stopwatch sw2 = Stopwatch.StartNew();
			ParallelFor(i);
			sw2.Stop();
			Console.WriteLine($"Parallel For Durchgänge {i}: {sw2.ElapsedMilliseconds}");
		}

		/*
			For Durchgänge 1000: 0
			Parallel For Durchgänge 1000: 37
			For Durchgänge 10000: 3
			Parallel For Durchgänge 10000: 65
			For Durchgänge 50000: 22
			Parallel For Durchgänge 50000: 25
			For Durchgänge 100000: 38
			Parallel For Durchgänge 100000: 32
			For Durchgänge 250000: 92
			Parallel For Durchgänge 250000: 127
			For Durchgänge 500000: 199
			Parallel For Durchgänge 500000: 235
			For Durchgänge 1000000: 477
			Parallel For Durchgänge 1000000: 477
			For Durchgänge 5000000: 2548
			Parallel For Durchgänge 5000000: 1449
			For Durchgänge 10000000: 2538
			Parallel For Durchgänge 10000000: 2544
			For Durchgänge 100000000: 21986
			Parallel For Durchgänge 100000000: 17808
		 */
	}

	static void RegularFor(int iterations)
	{
		double[] erg = new double[iterations];
		for (int i = 0; i < iterations; i++)
			erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100);
	}

	static void ParallelFor(int iterations)
	{
		double[] erg = new double[iterations];
		//int i = 0; i < iterations; i++
		Parallel.For(0, iterations, i => erg[i] = (Math.Pow(i, 0.333333333333) * Math.Sin(i + 2) / Math.Exp(i) + Math.Log(i + 1)) * Math.Sqrt(i + 100));
	}
}
