using NUnit.Framework;
using System;

namespace DistinctionProgram
{
	[TestFixture ()]
	public class GameTest
	{
		[Test ()]
		public void TestGameAutomaticallyCreateBoard ()
		{
			Game game = new Game ();
			Assert.AreEqual (game.GameBoardSize(),20);
		}

		[Test ()]
		public void TestPlayerEnterGame()
		{
			Game game = new Game ();
			Player Dominic = new Player ("Dominic");
			Assert.AreEqual (game.Participants.Count,0);
			game.EnterGame (Dominic);
			Assert.AreEqual (game.Participants.Count,1);
			game.EnterGame (new Player("Lachlan"));
			Assert.AreEqual (game.Participants.Count,2);
		}

		[Test ()]
		public void TestPlayerLeaveGame()
		{
			Game game = new Game ();
			Player Dominic = new Player ("Dominic");
			Player Lachlan = new Player ("Lachlan");
			game.EnterGame (Dominic);
			game.EnterGame (Lachlan);
			Assert.AreEqual (game.Participants.Count,2);
			game.LeaveGame (Dominic);
			Assert.AreEqual (game.Participants.Count,1);
			Assert.IsFalse(game.Participants.Contains(Dominic));
		}

		[Test ()]
		public void TestPlayerInitialPositionInGame()
		{
			Game game = new Game ();
			Player Dominic = new Player ("Dominic");
			game.EnterGame (Dominic);
			Assert.AreEqual (Dominic.CurrentPosition,1);
		}

		[Test ()]
		public void TestGamePlayerRollDie()
		{
			Game game = new Game ();
			Player Dominic = new Player ("Dominic");
			game.EnterGame (Dominic);
			game.PlayerRollDie (Dominic);
			Assert.IsFalse(Dominic.CurrentPosition==1);
		}

		[Test ()]
		public void TestGamePlayerFinalPositionIsAlwaysLastSquare()
		{

			Game game = new Game ();
			Player Dominic = new Player ("Dominic");
			game.EnterGame (Dominic);
			while(!game.HasWon())
				game.PlayerRollDie (Dominic);

			Assert.AreEqual (Dominic.CurrentPosition,20);
		}

		[Test ()]
		public void TestReturnsTheNameOfTheWinner()
		{

			Game game = new Game ();
			Player Dominic = new Player ("Dominic");
			game.EnterGame (Dominic);
			while(!game.HasWon())
				game.PlayerRollDie (Dominic);

			Assert.AreEqual (game.Winner(),"Dominic");
		}
	}
}

