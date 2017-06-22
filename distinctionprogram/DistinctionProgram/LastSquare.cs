using System;

namespace DistinctionProgram
{
	public class LastSquare:Square
	{
		public LastSquare ()
		{
		}

		/// <summary>
		/// Enter the specified player into the LastSquare
		/// </summary>
		/// <param name="player">Player.</param>
		public override void Enter (Player player)
		{
			if(_player.Count==0)
				base.Enter (player);
		}

		/// <summary>
		/// Leave the specified player out from the LastSquare
		/// </summary>
		/// <param name="player">Player.</param>
		public override void Leave (Player player)
		{

		}
	
	}
}

