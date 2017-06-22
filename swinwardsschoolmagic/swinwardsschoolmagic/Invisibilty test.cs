using NUnit.Framework;
using System;

namespace SwinwardsSchoolMagic
{
	[TestFixture ()]
	public class Invisibilty_test
	{
		[Test ()]
		public void TestCase ()
		{
			Spell Spells = new Spell ("David's dashing disappearance", SpellKind.Invisibility);
			StringAssert.AreEqualIgnoringCase ("Zippp... where am I?",  Spells.Castspell());
		}
	}
}

