using System;

namespace Rover
{
	public class Battery
	{
		private int _unitPower;

		public Battery ()
		{
			_unitPower = 20;
		}

		public int Power {
			get {
				return _unitPower;
			}
		}

		public void Charge()
		{
			_unitPower++;
		}

		public void Discharge(int x)
		{
			_unitPower -= x;
		}
	}
}

