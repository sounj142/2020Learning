using System;
using WiredBrainCoffee.Storage;

namespace WiredBrainCoffee.Simulators
{
	public class CoffeeMachine
    {
        private readonly CoffeeMachineStateSaver _coffeeMachineStateSaver;
		public int CounterCappuccino { get; private set; }

        public CoffeeMachine()
        {
            _coffeeMachineStateSaver = new CoffeeMachineStateSaver();
            var state = _coffeeMachineStateSaver.Load();
            CounterCappuccino = state.CounterCappuccino;
        }

        public void MakeCappuccino()
        {
            CounterCappuccino++;
            Console.WriteLine("Increment : " + CounterCappuccino);
            var state = new CoffeeMachineState
            {
                CounterCappuccino = CounterCappuccino
            };
            _coffeeMachineStateSaver.Save(state);
            _coffeeMachineStateSaver.ShowStoredJson();
        }
    }
}