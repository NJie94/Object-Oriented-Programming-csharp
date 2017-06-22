using NUnit.Framework;
using System;

namespace DistinctionProgram
{
	[TestFixture ()]
	public class GameBoardTest
	{
		[Test ()]
		public void TestGameBoard ()
		{
			GameBoard square = new GameBoard (10);
			Assert.AreEqual(square[1].GetType(),typeof(FirstSquare));
			Console.WriteLine (square.BoardSize);
			Assert.AreEqual (square[10].GetType(),typeof(LastSquare));
			for(int x=2;x<square.BoardSize;x++)
				Assert.AreEqual (square[x].GetType(),typeof(NormalSquare));
		}

		[Test()]
		public void TestLeaveAndEnter()
		{
			GameBoard gameboard = new GameBoard (10);

			Player player = new Player ("Dominic");
			gameboard [1].Enter (player);
			gameboard.LeaveAndEnter (player, player.Move (5));
			Assert.AreEqual (player.CurrentPosition,6);
			gameboard.LeaveAndEnter (player, player.Move (2));
			gameboard.LeaveAndEnter (player, player.Move (4));
			Console.WriteLine (player.CurrentPosition);
			Assert.IsTrue(gameboard [8].IsOccupied ());

			foreach(Square s in gameboard.Squares)
			{
				Console.WriteLine(s);
			}
			gameboard.LeaveAndEnter (player, player.Move (2));
			Console.WriteLine (player.CurrentPosition);
			Assert.IsTrue (gameboard.LastSquare().IsOccupied());
		}


	}
}

