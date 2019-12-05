using System;
using WiredBrainCoffee.Simulators;

namespace WiredBrainCoffee.ConsoleApp
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var coffeeMachine = new CoffeeMachine();
			coffeeMachine.MakeCappuccino();
			coffeeMachine.MakeCappuccino();

			Console.WriteLine($"Count Cappuccino: {coffeeMachine.CounterCappuccino}");

			//var anfa = new NETFrameworkTestLib.Anfa("abbccdd");
			//Console.WriteLine(anfa.Message);
		}
	}
}