using System;

namespace Rover
{
	public class Radar:Device
	{
		Random _random=new Random();

		public Radar ()
		{

		}

		public override void Operate()
		{
			if(_attachedBattery){
				if (Battery.Power > 3) {
					Battery.Discharge (4);
					Console.WriteLine ("PING ");
					if ((int)(_random.NextDouble() * 4 ) == 1) {
						Console.WriteLine ("PONG");
					} else {
						Console.WriteLine ("asdfkj");
					}
				} else {
					Console.WriteLine ("Low Battery");
				}
			}
			else
				Console.WriteLine("Please connect device Radar to a Battery!");
		}
	}
}

