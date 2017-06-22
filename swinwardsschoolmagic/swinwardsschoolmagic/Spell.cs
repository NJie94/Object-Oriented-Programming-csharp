using System;

namespace SwinwardsSchoolMagic
{

	public abstract class Spell
	{
		/// initialize name and kind

		private string _name;
		private SpellKind _kind;

		/// <summary>
		/// Initializes a new instance of the <see cref="SwinwardsSchoolMagic.Spell"/> class.
		/// assign equal value
		/// <param name="name">Name.</param>
		/// <param name="kind">Kind.</param>
		public Spell(string name)
		{
			_name = name;
		
		}

		/// <summary>
		/// Gets the spellname.
		/// <value>The spellname.</value>
		public string Spellname
		{
			get {return _name;}

		}

		/// <summary>
		/// Castspell this instance.
		/// Abstract case to be overide by childrent class
		///cast the 
		public abstract string Castspell();

//		{
//			switch (_kind)
//			{
//			case SpellKind.Teleport:
//				return "Poof... you appear somewhere else";
//			case SpellKind.Heal:
//				return "Ahhh... you feel better";
//			case SpellKind.Invisibility:
//				return "Zippp... where am I?";
//			default:
//				return "Invalid";
//			
//			}

//		}
	}
}

