using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Swinwarts_School_of_Magic
{

	/// <summary>
	/// Spells can be cast inorder to have an affect on their surroundings.
	/// There are a number of different kinds of spells, each with their
	/// own affects.
	/// </summary>
	public abstract class Spell
	{
		/// <summary>
		/// The spell class registry.
		/// </summary>
		public static Dictionary<string,Type> _SpellClassRegistry = new Dictionary<string, Type> ();

		/// <summary>
		/// Registers the spell.
		/// </summary>
		/// <param name="name">Name of spell</param>
		/// <param name="t"> The type of spell </param>
		public static void RegisterSpell(string name, Type t)
		{
			_SpellClassRegistry [name] = t;
		}

		/// <summary>
		/// Creates the spell.
		/// </summary>
		/// <returns>The spell.</returns>
		/// <param name="name">Name of spell </param>
		public static Spell CreateSpell(string name)
		{
			return (Spell)Activator.CreateInstance (_SpellClassRegistry [name]);
		}

		/// <summary>
		/// Keies the type.
		/// </summary>
		/// <returns>The type.</returns>
		/// <param name="key"> the type of the key </param>
		public static string KeyType(Type key)
		{
			string spells = "";
			Dictionary<string, Type> DicSpells = new Dictionary<string, Type> ();
			DicSpells.Add ("Invisibility", typeof(Invisibility));
			DicSpells.Add ("Heal", typeof(Heal));
			DicSpells.Add ("Teleport", typeof(Teleport));

			foreach(KeyValuePair<string, Type > keytypes in _SpellClassRegistry )
			{
				if (key == keytypes.Value)
				{
					spells = keytypes.Key;
				}
			}
			return spells;
		}

		/// <summary>
		/// The _name.
		/// </summary>
		protected string _name;

//		protected bool _spellsucceed=true;

		/// <summary>
		/// Initializes a new instance of the <see cref="Swinwarts_School_of_Magic.Spell"/> class.
		/// </summary>
		/// <param name="Name">Name of the spell</param>
		public Spell (String Name)
		{
			_name = Name;
		}

		/// <summary>
		/// Initializes a new instance of the spell class.
		/// </summary>
		public Spell ()
		{

		}
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name of the spell </value>
		public string Name 
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

//		public virtual bool SpellsucceededOrNot {
//			get {
//				return _spellsucceed;
//			}
//			set {
//				_spellsucceed = value;
//			}
//		}

		/// <summary>
		/// Cast this spell, causing it to have an effect
		/// on its surroundings. 
		/// </summary>
		/// <returns> description of the effect </returns>
	
		public abstract string Cast ();
		public abstract string Cast (object target);

		public void SaveTo (StreamWriter writer)
		{
			string key=KeyType (GetType ());
			writer.WriteLine (key);
			writer.WriteLine (_name);
//			writer.WriteLine (SpellsucceededOrNot);
		}

		public void LoadFrom(StreamReader reader)
		{
			_name = reader.ReadLine ();
			Console.WriteLine (_name+"---"+Cast());
		}	

	}
}	
	
