using NUnit.Framework;
using System;

namespace Rover
{
	[TestFixture ()]
	public class BatteryTest
	{
		[Test ()]
		public void TestBatteryBatteryPowerCanBeChange ()
		{

			Battery battery = new Battery ();
			Assert.AreEqual (battery.Power,20);
			battery.Charge ();
			Assert.AreEqual (battery.Power,21);
			battery.Discharge (10);
			Assert.AreEqual (battery.Power,11);
		}
	}
}