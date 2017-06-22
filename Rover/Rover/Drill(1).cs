using System;

namespace Rover
{
	public class Drill:Device
	{

		private bool _safetyEnabled;

		public Drill ()
		{
			_safetyEnabled = false;
		}

		public override void Operate()
		{
			if (_attachedBattery) {
				if (!_safetyEnabled) {
					if (Battery.Power > 9) {
						Battery.Discharge (10);
						Console.WriteLine ("VRMM!VRMM!");
					} else
						Console.WriteLine ("Low Battery");
				} else
					Console.WriteLine ("Safety First");

			} else
				Console.WriteLine ("Please connnect device Drill to a Battery");

		}

		public void EnableSafetyToggle()
		{
			if (_safetyEnabled)
				_safetyEnabled = false;
			else
				_safetyEnabled = true;
		}



	}
}

