using System;

namespace Rover
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			Rover rover = new Rover ();
			Battery battery = new Battery ();
			Drill drill = new Drill ();
			SolarPanel solarPanel = new SolarPanel ();
			Radar radar = new Radar ();
			Console.WriteLine(rover.Batteries.Count);
	
			rover.Attach (radar);
			radar.ConnectBattery (rover.Batteries[0]);

			rover.Operate ();
			rover.Operate ();
			rover.Operate ();
			rover.Operate ();
			rover.Operate ();
			rover.Operate ();
			rover.Operate ();
			rover.Operate ();
			rover.Operate ();

			Console.ReadLine ();


		}
	}
}
