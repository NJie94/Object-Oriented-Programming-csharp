using System;
using System.Collections.Generic;


namespace SwinwardsSchoolMagic
{
	public class Teleport :Spell
	{
		private static Random _random= new Random();


		public Teleport (string name): base (name)
		{}



		public override string Castspell ()
		{
			if (_random.Next (0,2) >= 1) {
				return ("Poof... you appear somewhere else");
			} 
			else 
			{
				return( "Arrr....I'm too tired to move");
			}
		}
	}
}

