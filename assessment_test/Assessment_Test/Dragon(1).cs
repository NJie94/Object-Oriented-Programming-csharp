using System;
using System.Collections.Generic;

namespace Assessment_Test
{
	public class Dragon:Entity
	{
		private int _shots;
		private string _name;

		public Dragon ()
		{
			_shots=3;
			_name = "Dragon";
		}

		public void Call()
		{
			if (_shots > 0) {
				Console.WriteLine ("Shooting");
				_shots--;
			} else {
				Console.WriteLine ("Out of bullets");
			}
		}
			
		public string Name{
			get{ return _name;}
		}
	}
}

