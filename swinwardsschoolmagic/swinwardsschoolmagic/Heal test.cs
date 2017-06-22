using NUnit.Framework;
using System;

namespace SwinwardsSchoolMagic
{
	[TestFixture ()]
	public class Heal_test
	{
		[Test ()]
		public void TestCase ()
		{
			Spell Spells = new Spell ("Paul's potent poultice", SpellKind.Heal);
			StringAssert.AreEqualIgnoringCase ("Ahhh... you feel better",  Spells.Castspell());
		}
	}
}

