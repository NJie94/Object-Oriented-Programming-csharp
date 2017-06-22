using System;

namespace SwinwardsSchoolMagic
{
	class MainClass
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// Contains a series of 5 array which call out different spell when chanting was chant
		/// and then cast all 5 spell 
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
			Spellbook TheSpellBook = new Spellbook();


			TheSpellBook.AddSpell (new Teleport ("Mitch's mighty mover"));
			TheSpellBook.AddSpell (new Heal ("Paul's potent poultice"));
			TheSpellBook.AddSpell (new Invisibility ("David's dashing disapperance"));
			TheSpellBook.AddSpell (new Teleport ("Stan's stunning shifter <Teleport>"));
			TheSpellBook.AddSpell (new Heal ("Lachlan's lavish longevity <Heal>"));

			Spell[] spellbook =TheSpellBook.Spells.ToArray();

			CastAllSpell (spellbook);

			Console.ReadLine ();
		
		}

		public static void CastAllSpell(Spell[] spellBook)
		{
			foreach (Spell s in spellBook) {
				Console.WriteLine (s.Castspell());
			}
		}
		/// <summary>
		/// Casts all spell.
		/// wrtite on screen of return string in cast spell, both spell name and castspell
		/// <param name="Castspells">Castspells.</param>

	}


}
