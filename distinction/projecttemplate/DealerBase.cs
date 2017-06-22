using System;

namespace MyGame
{
	public class DealerBase : BasePlayerClass
	{
		public DealerBase ()
		{
			this.Round = new Round (Dealer: true);
		}
	}
}

