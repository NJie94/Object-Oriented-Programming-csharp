using NUnit.Framework;
using System;

namespace SwinwardsSchoolMagic
{
	[TestFixture ()]
	public class TESTING
	{
		[Test ()]
		public void TestTeleport ()
		{
			Teleport Spells = new Teleport ();
			StringAssert.AreEqualIgnoringCase ("Poof...you appear somewhere else", Teleport);
		}
		public void Healingtest ()
		{
			Heal Spells = new Heal ();
			StringAssert.AreEqualIgnoringCase ("Ahhh... you feel better",Heal);
		}
		[Test ()]
		public void INvisTest ()
		{
			Invisibility Spells = new Invisibility ();
			StringAssert.AreEqualIgnoringCase ("Zippp... where am I?",Invisibility);
		}
	}
}

