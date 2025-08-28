
using System;

namespace MyMonkeyApp;

internal class Program
{
	private static readonly string monkeyAsciiArt = @"
		 .=""=.
		( o o )
		/  V  \
	   /(  _  )\
		 ^^ ^^";

	static void Main(string[] args)
	{
		Console.WriteLine("Welcome to the Monkey App!\n");
		while (true)
		{
			Console.WriteLine("Menu:");
			Console.WriteLine("1) List all monkeys");
			Console.WriteLine("2) Get details for a specific monkey by name");
			Console.WriteLine("3) Get a random monkey");
			Console.WriteLine("4) Exit");
			Console.Write("Select an option (1-4): ");
			var input = Console.ReadLine();
			Console.WriteLine();

			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetMonkeyByName();
					break;
				case "3":
					ShowMonkeyDetails(MonkeyHelper.GetRandomMonkey());
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Please try again.\n");
					break;
			}
		}
	}

	private static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine("Available Monkeys:");
		foreach (var monkey in monkeys)
		{
			var count = MonkeyHelper.GetAccessCount(monkey.Name);
			Console.WriteLine($"- {monkey.Name} (Accessed {count} time{(count == 1 ? "" : "s")})");
		}
		Console.WriteLine();
	}

	private static void GetMonkeyByName()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(name))
		{
			Console.WriteLine("No name entered.\n");
			return;
		}
		var monkey = MonkeyHelper.GetMonkeyByName(name);
		if (monkey == null)
		{
			Console.WriteLine($"Monkey '{name}' not found.\n");
		}
		else
		{
			ShowMonkeyDetails(monkey);
		}
	}

	private static void ShowMonkeyDetails(Monkey monkey)
	{
		Console.WriteLine(monkeyAsciiArt);
		Console.WriteLine($"\nName: {monkey.Name}");
		Console.WriteLine($"Location: {monkey.Location}");
		Console.WriteLine($"Population: {monkey.Population}");
		Console.WriteLine($"Details: {monkey.Details}");
		Console.WriteLine($"Accessed: {MonkeyHelper.GetAccessCount(monkey.Name)} time{(MonkeyHelper.GetAccessCount(monkey.Name) == 1 ? "" : "s")}");
		Console.WriteLine();
	}
}
