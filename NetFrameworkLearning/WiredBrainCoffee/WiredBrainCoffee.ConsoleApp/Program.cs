﻿using System;
using System.Threading;
using WiredBrainCoffee.Simulators;

namespace WiredBrainCoffee.ConsoleApp
{
	internal class Program
	{
		private static void Main(string[] args)
		{
            //var coffeeMachine = new CoffeeMachine();
            //coffeeMachine.MakeCappuccino();
            //coffeeMachine.MakeCappuccino();

            //         Console.WriteLine($"Count Cappuccino: {coffeeMachine.CounterCappuccino}");

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