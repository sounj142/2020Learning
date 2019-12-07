using System;
using System.Threading;
using WiredBrainCoffee.Simulators;

namespace WiredBrainCoffee.ConsoleAppNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread t = new Thread(() =>
            {
                var coffeeMachine = new CoffeeMachine();
                coffeeMachine.MakeCappuccino();
                coffeeMachine.MakeCappuccino();

                Console.WriteLine($"Count Cappuccino: {coffeeMachine.CounterCappuccino}");
                Console.ReadKey();
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
    }
}
