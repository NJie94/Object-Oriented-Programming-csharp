using System;

namespace DistinctionProgram
{
	public class NormalSquare:Square
	{
		public NormalSquare ()
		{
		}

		/// <summary>
		/// Enter the specified player into the NormalSquare
		/// </summary>
		/// <param name="player">Player.</param>
		public override void Enter (Player player)
		{
			base.Enter (player);

			if (_player.Count == 2)
			{
				Console.WriteLine ("{0} has been kicked back to Start\n",_player[0].Name);
				_player [0].ReturnToFirstBox ();
				Leave (_player [0]);
			}
		}

		/// <summary>
		/// Leave the specified player out from the Square
		/// </summary>
		/// <param name="player">Player.</param>
		public override void Leave (Player player)
		{
			base.Leave (player); //do the same as the parent class i.c. Square Class
		}
	}
}

