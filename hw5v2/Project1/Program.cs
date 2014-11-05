﻿//
// Asian Options Stock Pricing Program:
//
// For more info, see: http://en.wikipedia.org/wiki/Asian_option
//
using System;
using System.Collections.Generic;


namespace AsianOptionsConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("** Asian Options Stock Pricing Program **");
			Console.WriteLine();

			//
			// Simulation parameters:
			//
			double initial = 30.0;
			double exercise = 30.0;
			double up = 1.4;
			double down = 0.8;
			double interest = 1.08;
			long periods = 30;
			long sims = 5000000;
			long temp;

			Console.Write("How many simulations would you like to run (default: 5,000,000): ");
			string input = Console.ReadLine();

			// try to parse input: if it fails, defaults to valuer above:
			if (long.TryParse(input, out temp))  // parse successful:
			{
				// make sure value is reasonable, and if so, update sims to input value:
				if (temp > 0)
					sims = temp;
				//else 
				//  we leave sims alone;
			}
			//else 
			//  we leave sims alone;

			Console.WriteLine();
			Console.WriteLine("** Parameters:");
			Console.WriteLine("   Initial price:   {0:#,##0.00}", initial);
			Console.WriteLine("   Exercise price:  {0:#,##0.00}", exercise);
			Console.WriteLine("   Upper bound:     {0:#,##0.00}", up);
			Console.WriteLine("   Lower bound:     {0:#,##0.00}", down);
			Console.WriteLine("   Interest rate:   {0:#,##0.00}", interest);
			Console.WriteLine("   Time period:     {0:#,##0}", periods);
			Console.WriteLine("   Simulation runs: {0:#,##0}", sims);

			//
			// Run simulation to price option:
			//
			Console.WriteLine();
			Console.WriteLine("** Simulation running...");

			int start = System.Environment.TickCount;

			double price = AsianOptionsPricing.Simulation(initial, exercise, up, down, interest, periods, sims);

			int stop = System.Environment.TickCount;
			double elapsedTimeInSecs = (stop - start) / 1000.0;

			//
			// Done, display results:
			//
			Console.WriteLine("** Simulation complete:");
			Console.WriteLine("   Price: {0:#,##0.00}", price);
			Console.WriteLine("   Time:  {0:#,##0.00} secs", elapsedTimeInSecs);
			Console.WriteLine();
            Console.ReadKey();
		}
	}
}
