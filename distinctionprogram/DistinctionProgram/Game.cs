using System;
using System.Collections.Generic;

namespace DistinctionProgram
{
	public class Game
	{
		private GameBoard _square;
		private List<Player> _players;

		/// <summary>
		/// Initializes a new instance of the Game class.
		/// </summary>
		public Game ()
		{
			_square=new GameBoard(20);
			_players=new List<Player>();
		}

		/// <summary>
		/// Returns the BoardSize of the Game
		/// </summary>
		/// <returns>The board size.</returns>
		public int GameBoardSize()
		{
			return _square.BoardSize ;
		}

		/// <summary>
		/// Gets the List of Player Playing the Game
		/// </summary>
		/// <value>The participants.</value>
		public List<Player> Participants
		{
			get{ return _players; }
		}

		/// <summary>
		/// Player Entering Game
		/// </summary>
		/// <param name="player">Player.</param>
		public void EnterGame(Player player)
		{
			_players.Add (player);
			_square [1].Enter (player);
		}

		/// <summary>
		/// Player Leaving Game
		/// </summary>
		/// <param name="player">Player.</param>
		public void LeaveGame(Player player)
		{
			_players.Remove (player);
			for (int x = 1; x <= _square.BoardSize; x++) 
			{
				_square [x].Leave (player);
			}
		}

		/// <summary>
		/// Players roll the die.
		/// </summary>
		/// <param name="player">Player.</param>
		public void PlayerRollDie(Player player)
		{
			player.Move (player.RollDie ());
			_square.LeaveAndEnter (player, player.CurrentPosition);
		}

		/// <summary>
		/// Determines whether the Game Has Finished
		/// </summary>
		/// <returns><c>true</c> if this instance has won; otherwise, <c>false</c>.</returns>
		public Boolean HasWon()
		{
			return _square.LastSquare().IsOccupied ();
		}

		/// <summary>
		/// The Winner Of the Game
		/// </summary>
		public string Winner()
		{
			return (_square.LastSquare().ContainPlayers [0]).Name;
		}
			
	}
}

