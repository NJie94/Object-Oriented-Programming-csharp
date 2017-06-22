using System;

namespace Rover
{
	public abstract class Device
	{

		protected bool _attachedBattery;
		private Battery _battery;


		public Device ()
		{
			_attachedBattery = false;
		}
			
		public abstract void Operate();

		public void ConnectBattery(Battery battery)
		{
			_attachedBattery = true;
			_battery = battery;
		}

		public void DisconnectBattery(Battery battery)
		{
			_attachedBattery= false;
			_battery = null;
		}

		public Battery Battery {
			get {
				return _battery;
			}
		}


	}
}

