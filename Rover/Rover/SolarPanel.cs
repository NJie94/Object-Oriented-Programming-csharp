using System;

namespace Rover
{
	public class SolarPanel:Device
	{
		public SolarPanel ()
		{
		}

		public override void Operate()
		{
			if (_attachedBattery) {
				Battery.Charge ();
				Console.WriteLine ("Charging");
			} else
				Console.WriteLine ("Please connect device Solar Panel to a Battery!");

		}
	}
}

