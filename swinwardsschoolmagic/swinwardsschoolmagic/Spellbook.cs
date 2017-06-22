using System;
using System.Collections.Generic;

namespace SwinwardsSchoolMagic
{
	public class Spellbook
	{
		private List<Spell> _spells =new List<Spell>();

		public List<Spell> Spells
		{
			get{return _spells;}
		}


		public int SpellNumber
		{
			get
			{
				return _spells.Count;
			}
		}

		public Spell this [int i]
		{
			get
			{
				return _spells [i];
			}
		}


		public Spellbook ()
		{
			_spells = new List<Spell> ();
		}

		public void AddSpell (Spell s)
		{
			_spells.Add (s);
		}

		public void RemoveSpell (Spell s)
		{
			_spells.Remove (s);
		}

	}
}

