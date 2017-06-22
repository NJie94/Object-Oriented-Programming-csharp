using System;
using System.IO;

namespace Swinwarts_School_of_Magic
{
	public class Invisibility:Spell
	{
		private bool _wasCast;
		/// <summary>
		/// Initializes a new instance of the <see cref="Swinwarts_School_of_Magic.Invisibility"/> class.
		/// </summary>
		public Invisibility ()
		{
			_wasCast = false;
		}

		public Invisibility (String Name)
		{
			_name = Name;
		}
			
		/// <summary>
		/// Cast this spell, causing it to have an effect
		/// on its surroundings.
		/// </summary>
		/// <returns>description of the effect</returns>
		public override string Cast()
		{
			if (!_wasCast) {
				_wasCast = true;
				return "Zipppp...where am I?";
			} else
				return "pzzzzzzit";
		}


		/// <summary>
		/// Cast this spell, causing it to have an effect
		/// on its surroundings.
		/// </summary>
		/// <returns>description of the effect</returns>
		/// <param name="target">an object that is cat, house etc</param>
		public override string Cast(object target)
		{
			if (_wasCast)
				return "pzzzzit";
			else
			{
				if(target is VisibleMutable)
				{
					VisibleMutable tgt;
					tgt=(VisibleMutable)target;
					_wasCast = true;
					return tgt.MakeInvisible();
				}
				else
				{
					_wasCast = true;
					return "Nothing ... the object is still there!";
				}
			}
		}

	}
}

