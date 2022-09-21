using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitWPF;

public partial class MainWindow : Window
{
	string[] Words;

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			Thread.Sleep(25);
			Progress.Value++;
		} //Thread.Sleep verhindert UI updates
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Task.Run(() =>
		{
			Dispatcher.Invoke(() => Progress.Value = 0); //Dispatcher.Invoke: UI ansprechen aus unterschiedlichen Threads/Tasks, ohne Dispatcher.Invoke funktionieren keine UI updates
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(25);
				Dispatcher.Invoke(() => Progress.Value++);
			}
		}); //funktioniert schonmal
	}

	private async void Button_Click_2(object sender, RoutedEventArgs e)
	{
		Progress.Value = 0;
		for (int i = 0; i < 100; i++)
		{
			await Task.Delay(25);
			Progress.Value++;
		} //funktioniert auch ohne Dispatcher.Invoke
	}

	private async void Button_Click_3(object sender, RoutedEventArgs e)
	{
		HttpClient client = new();
		string s = await client.GetStringAsync(@"http://www.gutenberg.org/files/54700/54700-0.txt");
	
		HttpResponseMessage resp = await client.GetAsync(@"http://www.gutenberg.org/files/54700/54700-0.txt");
		string s2 = await resp.Content.ReadAsStringAsync();
		Words = s2.Split(new char[] { ' ', '\n', ',', '.', ';', ':', '-', '_', '/' }, StringSplitOptions.RemoveEmptyEntries);

		List<Task> tasks = new List<Task>() { GetLongestWord(), GetCountForWord("sleep"), GetMostCommonWords() };
		await Task.WhenAll(tasks);
	}

	private async void Button_Click_4(object sender, RoutedEventArgs e)
	{
		List<int> ints = Enumerable.Range(1, 100).ToList();
		await Parallel.ForEachAsync(ints, (i, ct) =>
		{
			Console.WriteLine(i * 10);
			return ValueTask.CompletedTask;
		});
	}

	async Task GetLongestWord()
	{
		Console.WriteLine(Words.OrderByDescending(e => e.Length).First());
	}

	async Task GetCountForWord(string word)
	{
		Console.WriteLine(Words.Count(e => e.Equals(word, StringComparison.OrdinalIgnoreCase)));
	}

	async Task GetMostCommonWords()
	{
		Console.WriteLine
		(
			Words
			.Where(e => e.Length >= 7)
			.GroupBy(e => e.ToLower())
			.ToDictionary(e => e.Key, e => e.Count())
			.OrderByDescending(e => e.Value)
			.Take(10)
			.Aggregate("", (agg, kv) => agg + $"{kv.Key}: {kv.Value}\n")
		);
	}
}
