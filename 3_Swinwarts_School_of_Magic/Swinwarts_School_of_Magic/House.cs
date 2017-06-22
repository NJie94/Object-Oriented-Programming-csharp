using System;

namespace Swinwarts_School_of_Magic
{
	public class House:VisibleMutable
	{
		private bool _visible=true;

		public bool Visible{get{return _visible;}}

		public string MakeInvisible()
		{
			_visible = false;
			return "House vanishes";
		}
	}
}

