using System;
using System.Collections.Generic;

namespace Assessment_Test
{
	public class Wolf:Entity
	{
		private string _name;

		public Wolf()
		{
			_name="Wolf";
		}
		public void Call()
		{
			Console.WriteLine ("Sonaring");
		}

		public string Name{
			get{return _name;}
		}
	}
}

