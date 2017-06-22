using System;
using System.IO;
namespace Swinwarts_School_of_Magic
{
	public class Heal:Spell
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Swinwarts_School_of_Magic.Heal"/> class.
		/// </summary>
		public Heal ()
		{
			_name = "Default Heal";
		}

		public Heal (String Name)
		{
			_name = Name;
		}

		/// <summary>
		/// Cast this spell, causi it to have an effect
		/// on its surroundings.
		/// </summary>
		/// <returns>description of the effect</returns>
		public override string Cast()
		{
			return "Ahhh...you feel better";
		}
			
		/// <summary>
		/// Cast this spell, causing it to have an effect
		/// on its surroundings.
		/// </summary>
		/// <returns>description of the effect</returns>
		/// <param name="target">an object that is cat, house etc.</param>
		public override string Cast(object target)
		{
			{
				return "Ahhh...you feel better";
			}
		}
	}
}

