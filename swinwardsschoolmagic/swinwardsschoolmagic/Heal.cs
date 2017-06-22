using System;

namespace SwinwardsSchoolMagic
{
	public class Heal : Spell
	{
		public Heal (string name): base(name)
		{
			
		}

		public override string Castspell ()
		{
			return ("Ahhh... you feel better");
		}
	}
}

