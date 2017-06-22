using System;

namespace Swinwarts_School_of_Magic
{
	public class Cat :Animal,VisibleMutable,Transportable
	{
		private bool _visible=true;
		private bool _transport=true;

		public bool Transport{get{ return _transport;}}

		public bool Visible{get{return _visible;}}

		public string MakeInvisible()
		{
			_visible = false;
			return "With a hiss... the cat vanishes";
		}

		public string MakeTransport()
		{
			_visible = false;
			return "meeow....-zip- the cat is gone!!!!!";
		}


	}
}

