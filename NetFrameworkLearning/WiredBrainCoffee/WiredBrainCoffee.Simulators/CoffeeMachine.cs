using System;
using WiredBrainCoffee.Storage;

namespace WiredBrainCoffee.Simulators
{
	public class CoffeeMachine
	{
		public int CounterCappuccino { get; private set; }

		public void MakeCappuccino()
		{
			CounterCappuccino++;
			Console.WriteLine("aaa");
		}

		public void Save()
		{
			var saveProvide = new CoffeeMachineStateSaver();
			var coffeeState = new CoffeeMachineState { CounterCappuccino = CounterCappuccino };
			saveProvide.Save(coffeeState);
			// saveProvide.ShowStoredJson();
		}
	}
}