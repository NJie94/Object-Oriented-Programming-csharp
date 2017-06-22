using System;

namespace Swinwarts_School_of_Magic
{
	public interface VisibleMutable
	{
		bool Visible {get;}

		string MakeInvisible();
	}
}

