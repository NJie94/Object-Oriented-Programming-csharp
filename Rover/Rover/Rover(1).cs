using System;
using System.Collections.Generic;

namespace Rover
{
	public class Rover
	{

		private List<Battery> _batteries = new List<Battery> ();
		private List<Device> _devices=new List<Device>();


		public Rover ()
		{
			Battery battery = new Battery ();
			_batteries.Add (battery);
		

		}

		public void Operate()
		{
			if (_devices.Count != 0) {
				foreach (Device device in _devices) {
						device.Operate ();
				}
			} else {
				Console.WriteLine ("Please Connect device");
			}
		}

		public List<Battery> Batteries {
			get {
				return _batteries;
			}
		}

		public Battery this[int i]
		{
			get{ return _batteries [i];}
		}
			
		public void addBattery()
		{
			Battery battery = new Battery ();
			_batteries.Add (battery);
		
		}
	
		public void Attach(Device device)
		{
			_devices.Add (device);
		}

		public void Detached(Device device)
		{
			_devices.Remove (device);
		}




	}
}

