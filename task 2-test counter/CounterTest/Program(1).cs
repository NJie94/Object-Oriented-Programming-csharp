using System;

namespace CounterTest
{
	class MainClass
	{

		private static void PrintCounters (Counter[] counters)
		{
			foreach (Counter counter in counters)
			{
				Console.WriteLine ("{0} is {1} ",counter.Name, counter.Value );
			}
		}
		public static void Main (string[] args)
		{

			Counter[] myCounters = new Counter[3];
			int i;


			myCounters [0] = new Counter ("Counter 1");
			myCounters [1] = new Counter ("Counter 2");
			myCounters [2] = new Counter ("Counter 3");


			myCounters [2].Value = myCounters[0].Value;

			for (i=0; i < 4; i++) 
			{
				myCounters [0].increment();
			}

			for (i = 0; i < 9; i++)
			{
				myCounters [1].increment ();
			}

			myCounters [2].Reset ();

			PrintCounters (myCounters);
			Console.ReadLine ();
		}
	}
}


