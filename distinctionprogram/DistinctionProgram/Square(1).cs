using System;
using System.Collections.Generic;

namespace DistinctionProgram
{
	public abstract class Square
	{
		protected List<Player> _player=new List<Player>();

		/// <summary>
		/// Initializes a new instance of the Square Class
		/// </summary>
		public Square ()
		{
		}

		/// <summary>
		/// Determines whether this square is occupied.
		/// </summary>
		/// <returns><c>true</c> if this instance is occupied; otherwise, <c>false</c>.</returns>
		public Boolean IsOccupied()
		{
			return !(_player.Count==0);
		}

		/// <summary>
		/// Enter the specified player into the Square
		/// </summary>
		/// <param name="player">Player.</param>
		public virtual void Enter(Player player)
		{
			_player.Add (player);
		}

		/// <summary>
		/// Leave the specified player out from the Square
		/// </summary>
		/// <param name="player">Player.</param>
		public virtual void Leave (Player player)
		{
			_player.Remove (player);
		}
			
		/// <summary>
		/// Gets the contain lists of the players
		/// </summary>
		/// <value>The contain players.</value>
		public List<Player> ContainPlayers
		{
			get{return _player;}
		}

	}
}

