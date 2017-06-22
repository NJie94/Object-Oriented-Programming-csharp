using System;
using System.Collections.Generic;

namespace DistinctionProgram
{

	public class GameBoard
	{
		private List<Square> _squares= new List<Square>();
		private int _boardSize;

		/// <summary>
		/// Initializes a new instance of the <see cref="DistinctionProgram.GameBoard"/> class.
		/// </summary>
		/// <param name="boardSize">Board size.</param>
		public GameBoard (int boardSize)
		{
			_boardSize = boardSize;
				for (int x = 1; x <=_boardSize; x++) {
					if (x == 1)
						_squares.Add (new FirstSquare ());
					else if  (x == _boardSize)
					_squares.Add (new LastSquare ());
					else 
					_squares.Add (new NormalSquare ());
				}
		}

		/// <summary>
		/// Gets the Square at the specified index of the GameBoard
		/// </summary>
		/// <param name="index">Index.</param>
		public Square this[int index]
		{
			get
			{
				return _squares [index-1];
			}
		}

		/// <summary>
		/// Gets the size of the board.
		/// </summary>
		/// <value>The size of the board.</value>
		public int BoardSize {
			get {
				return _boardSize;
			}
		}

		/// <summary>
		/// Leaves the and enter a Box
		/// </summary>
		/// <param name="player">Player.</param>
		/// <param name="finalPosition">Final position.</param>
		public void LeaveAndEnter(Player player,int finalPosition)
		{

			foreach (Square square in _squares) 
			{
				square.Leave (player);
			}

			if (finalPosition > _boardSize) {
				player.CurrentPosition += 2 * _boardSize - finalPosition - player.CurrentPosition;
				Console.WriteLine (player.Name + " rolled a " + player.Die.DieNumber);
				Console.WriteLine ("[{0} move to {1}]\n", player.Name, player.CurrentPosition);
				_squares [player.CurrentPosition - 1].Enter (player);
			} 
			else
			{
				Console.WriteLine (player.Name + " rolled a " + player.Die.DieNumber);
				Console.WriteLine ("[{0} move to {1}]\n", player.Name, player.CurrentPosition);
				_squares [finalPosition - 1].Enter (player);

			}
		}

		/// <summary>
		/// Gets the LastSquare
		/// </summary>
		/// <returns>The square.</returns>
		public Square LastSquare()
		{
			return _squares [_boardSize-1];
		}

		/// <summary>
		/// Gets the List of squares.
		/// </summary>
		/// <value>The squares.</value>
		public List<Square> Squares {
			get {
				return _squares;
			}
		}
	}
}

