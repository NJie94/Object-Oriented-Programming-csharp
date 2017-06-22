using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Swinwarts_School_of_Magic
{
	[TestFixture ()]
	public class Unit_testing_SpellBook
	{
		[Test ()]
		public void TestAddingSpells ()
		{
			SpellBook mySpellBook = new SpellBook ();
			Spell mySpell = new Teleport ("Testing");
			mySpellBook.AddSpells (mySpell);
			Assert.AreEqual (mySpellBook.SpellCount,1);
		}

		[Test()]
		public void TestRemoveSpells ()
		{
			SpellBook mySpellBook = new SpellBook ();
			Spell mySpell = new Teleport ("Testing");
			mySpellBook.AddSpells (mySpell);
			Assert.AreEqual (mySpellBook.SpellCount,1);
			mySpellBook.RemoveSpells (mySpell);
			Assert.AreEqual (mySpellBook.SpellCount,0);
		}

		[Test()]
		public void TestFetchingSpells()
		{
			SpellBook mySpellBook = new SpellBook ();
			Spell[] arrayofspell;
			arrayofspell = new Spell[5];
			arrayofspell [0] = new Teleport ("1. Mitch's mighty mover");
			arrayofspell [1] = new Heal ("2. Paul's potent poultice");
			arrayofspell [2] = new Invisibility ("3. David's dashing disapperance");
			arrayofspell [3] = new Teleport ("4. Stan's stunning shifter");
			arrayofspell [4] = new Heal("5. Lachlan's lavish longevity");
			foreach (Spell array0to4 in arrayofspell) 
			{
				mySpellBook.AddSpells (array0to4);
			}

			Assert.AreSame (mySpellBook [0],arrayofspell [0]);
			Assert.AreSame (mySpellBook [1],arrayofspell [1]);
			Assert.AreSame (mySpellBook [2],arrayofspell [2]);
			Assert.AreSame (mySpellBook [3],arrayofspell [3]);
			Assert.AreSame (mySpellBook [4],arrayofspell [4]);
		}
	}
}