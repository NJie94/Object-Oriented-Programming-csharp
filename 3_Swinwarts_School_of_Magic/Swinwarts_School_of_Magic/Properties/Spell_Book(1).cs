using System;
using System.Collections.Generic;

namespace Swinwarts_School_of_Magic
{
	public class Spell_Book
	{
		private List<Spell> _spells=new List<Spell>();
		private int _spellscount;

		public Spell_Book ()
		{

		}

		public void AddSpells(Spell s)
		{
			_spells.Add (s);
			_spellscount++;
		}

		public void RemoveSpells(Spell s)
		{
			_spells.Remove (s);
			_spellscount--;
		}

		public Spell this[int i]
		{
			get
			{
				return _spells [i];
			}
		}
	}
}

