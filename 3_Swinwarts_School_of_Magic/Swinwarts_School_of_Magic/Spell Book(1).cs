using System;
using System.Collections.Generic;
using System.IO;

namespace Swinwarts_School_of_Magic
{
	/// <summary>
	/// Spell book class
	/// </summary>
	public class SpellBook
	{
		private const string Filepath=@"C:\Users\Dominic\Desktop\";
		/// <summary>
		/// The list of spells.
		/// </summary>
		private List<Spell> _spells=new List<Spell>();

		/// <summary>
		/// Initializes a new instance of the Spell_book  class.
		/// </summary>
		public SpellBook ()
		{
		
		}

		/// <summary>
		/// Gets the spells.
		/// </summary>
		/// <value>The spells.</value>
		public List<Spell> Spells
		{
			get{return _spells;}
		}

		/// <summary>
		/// Gets the spell count in the list
		/// </summary>
		/// <value>The spell count.</value>
		public int SpellCount
		{
			get{  return _spells.Count; }
		}

		/// <summary>
		/// Adds the spells to the list of spell
		/// </summary>
		/// <param name="s">S.</param>
		public void AddSpells(Spell s)
		{
			_spells.Add (s);

		}

		/// <summary>
		/// Removes the spells.
		/// </summary>
		/// <param name="s">spells that you want to remove from the list </param>
		public void RemoveSpells(Spell s)
		{
			_spells.Remove (s);

		}

		/// <summary>
		/// Gets the Spell in the list with the specified i.
		/// </summary>
		/// <param name="i">The index.</param>
		public Spell this[int i]
		{
			get
			{
				return _spells [i];
			}
		}
		/// <summary>
		/// Save the specified filename.
		/// </summary>
		/// <param name="filename"> The filename that you want to save as </param>
		public void Save (string filename)
		{
			StreamWriter writer = new StreamWriter (Filepath+filename);
			try
			{
				writer.WriteLine (SpellCount);
				foreach (Spell s in _spells)
				{
					s.SaveTo (writer);
				}
			}
			finally
			{
				writer.Close ();
			}
		}

		/// <summary>
		/// Load the specified filename.
		/// </summary>
		/// <param name="filename">Filename that you want to load</param>
		public void Load(string filename)
		{
			int _count, i;
			//because c# very stupid 
			Spell s = null;
			string kind;


			StreamReader reader = new StreamReader (Filepath+filename);
			try{
				_count=reader.ReadInteger();

				for (i = 0; i < _count; i++)
				{	
					kind = reader.ReadLine ();
					s=Spell.CreateSpell (kind);
					s.LoadFrom(reader);
					AddSpells (s);	
				}
			}
			finally
			{
				reader.Close ();
			}
		}


			
	}
}

