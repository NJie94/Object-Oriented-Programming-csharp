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
			Teleport myTeleport = new Teleport ("Mitch's mighty mover");
			string TeleportTest = myTeleport.Castspell ();

			Assert.IsTrue (TeleportTest== "Poof... you appear somewhere else"|| TeleportTest == "Arrr....I'm too tired to move");
		}

		[Test ()]
		public void Healingtest ()
		{
			Spell HealTest = new Heal ("Paul's potent poultice");
			Assert.AreEqual (HealTest.Castspell (),"Ahhh... you feel better");
		}

		[Test ()]
		public void INvisTest ()
		{
			Spell Invistest = new Invisibility ("David's dashing disappearance");
			Assert.AreEqual (Invistest.Castspell (),"Zipppp...where am I?");
		}

		[Test ()]
		public void Spellbook()
		{
			Spellbook myBook = new SwinwardsSchoolMagic.Spellbook ();

			Teleport myTeleport = new Teleport ("Mitch's mighty mover");

			Heal myHeal = new Heal ("Paul's potent poultice");

			Invisibility myInvisibility = new Invisibility ("David's dashing disapperance");

			myBook.AddSpell (myTeleport);
			myBook.AddSpell (myHeal);
			myBook.AddSpell (myInvisibility);

			Assert.AreEqual (myTeleport, myBook [0]);
			Assert.AreEqual (myHeal, myBook [1]);
			Assert.AreEqual (myInvisibility, myBook [2]);

		}
	}
}

