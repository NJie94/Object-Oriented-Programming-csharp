using NUnit.Framework;
using System;
using Swinwarts_School_of_Magic;

namespace Swinwarts_School_of_Magic
{
	[TestFixture ()]
	public class Unit_testing_Spell
	{
		[Test ()]
		public void Teleport ()
		{
			Spell testingspell1 = new  Teleport ("Mitch's mighty mover");
			Assert.AreEqual (testingspell1.Cast (), "Poof...you appear somewhere else");


		}

		[Test ()]
		public void Heal ()
		{
			Spell testingspell2 = new Heal ("Paul's potent poultice");
			Assert.AreEqual (testingspell2.Cast(),"Ahhh...you feel better");
		}

		[Test ()]
		public void Invisibility ()
		{
			Spell testingspell_3 = new Invisibility ("David's dashing disapperance");
			Assert.AreEqual(testingspell_3.Cast(),"Zipppp...where am I?");
		}

		[Test ()]
		public void ChangenameTeleport ()
		{
			Teleport testingspell1 = new Swinwarts_School_of_Magic.Teleport ("abcde");

			testingspell1.Probability = 0.5;
			Assert.AreEqual(testingspell1.Cast(), "Poof...you appear somewhere else");
			testingspell1.Name = "xyz";
			testingspell1.Probability = 0.5;
			Assert.AreEqual(testingspell1.Cast(), "Poof...you appear somewhere else");

		}

		[Test ()]
		public void ChangenameHeal ()
		{
			Spell testingspell2 = new Swinwarts_School_of_Magic.Heal("qwerty");

			Assert.AreSame (testingspell2.Cast(),"Ahhh...you feel better");
			testingspell2.Name = "xyz";
			Assert.AreSame (testingspell2.Cast(),"Ahhh...you feel better");

		}

		[Test ()]
		public void ChangenameInvisibility ()
		{
			Spell testingspell3= new Swinwarts_School_of_Magic.Invisibility ("asdf");

			Assert.AreSame(testingspell3.Cast(),"Zipppp...where am I?");
			testingspell3.Name = "xyz";
			Assert.AreSame(testingspell3.Cast(),"pzzzzzzit");

		}

		[Test ()]
		public void TeleportChanceSpell ()
		{
			Teleport tele = new Teleport ();
			Spell s = new Swinwarts_School_of_Magic.Teleport ("1. Mitch's mighty mover");
			int i = 0;
			while(i<10)
			{
				Console.WriteLine ("{0:P}",1-tele.Probability);
//				tele.SpellCast (s);
				i++;
//				Console.WriteLine ("Spell succeed="+s.SpellsucceededOrNot);
			}
				
		}

		[Test ()]
		public void HealChanceSpell ()
		{
			Heal healing = new Heal ();
			Spell s = new Swinwarts_School_of_Magic.Heal ("2. Paul's potent poultice");
			int i = 0;
			while(i<5)
			{
//				healing.SpellCast (s);
				i++;
//				Console.WriteLine ("Spell succeed="+s.SpellsucceededOrNot);
			}

		}
		[Test ()]
		public void InvisibilityChanceSpell ()
		{
			Invisibility Invi = new Invisibility ();
			Spell s = new Swinwarts_School_of_Magic.Invisibility ("3. David's dashing disapperance");
			int i =0;
			while(i<5)
			{
//				Invi.SpellCast (s);
				i++;
//				Console.WriteLine ("Spell succeed="+s.SpellsucceededOrNot);
			}

		}

		[Test ()]
		public void TeleportingCat()
		{
			object objects = new Cat ();
			Teleport teleport = new Teleport ();
			Assert.AreEqual(teleport.Cast(objects),"meeow....-zip- the cat is gone!!!!!");
			objects = new House ();
			Assert.AreEqual(teleport.Cast(objects),"Nothing ... the object is still there!");
		}

		[Test ()]
		public void MutableCat()
		{
			object objects = new Cat ();
			Invisibility invisibility = new Swinwarts_School_of_Magic.Invisibility ();
			Assert.AreEqual(invisibility.Cast(objects),"With a hiss... the cat vanishes");
			Assert.AreEqual(invisibility.Cast(objects),"pzzzzit");
		}

		[Test ()]
		public void MutableHouse()
		{
			object objects = new House ();
			Invisibility invisibility = new Swinwarts_School_of_Magic.Invisibility ();
			Assert.AreEqual (invisibility.Cast(objects),"House vanishes");
		}

	}
}

