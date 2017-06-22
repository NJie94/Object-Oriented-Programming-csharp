using System;

namespace SwinwardsSchoolMagic
{
	public class Invisibility:Spell
	{
		private bool _wasCast;
		
		public Invisibility (string name): base (name)
		{
			_wasCast = false;
		}

		public Boolean wasCast
		{
			get{ return _wasCast; }
			set{ _wasCast = value; }
		}

		public override string Castspell()
		{
			if (_wasCast==false) {
				_wasCast = true;
				return ("Zipppp...where am I?");
			} else
				return ("pzzzzzzit");
		}
	}
}

