using NUnit.Framework;
using System;

namespace DistinctionProgram
{
	[TestFixture ()]
	public class SquareTest
	{
		[Test ()]
		public void TestFirstSquareEnter ()
		{
			Square firstSquare = new FirstSquare ();
			Player player = new Player ("Dominic");
			Player player2=new Player("Lachlan");
			firstSquare.Enter (player);
			firstSquare.Enter (player2);
			Assert.AreEqual (firstSquare.ContainPlayers.Count,2);
			Assert.IsTrue (firstSquare.ContainPlayers.Contains(player));
			Assert.IsTrue (firstSquare.ContainPlayers.Contains(player2));
		}

		[Test ()]
		public void TestFirstSquareLeave()
		{
			Square firstSquare = new FirstSquare ();
			Player player = new Player ("Dominic");
			Player player2=new Player("Lachlan");
			firstSquare.Enter (player);
			firstSquare.Enter (player2);
			firstSquare.Leave (player);
			Assert.IsFalse (firstSquare.ContainPlayers.Contains(player));
			Assert.IsTrue (firstSquare.ContainPlayers.Contains(player2));
			Assert.AreEqual (firstSquare.ContainPlayers.Count,1);
		}

		[Test ()]
		public void TestNormalSquareEnter()
		{
			Square normalSquare = new NormalSquare ();
			Player player = new Player ("Dominic");
			Player player2 = new Player ("Lachlan");
			normalSquare.Enter (player);
			normalSquare.Enter (player2);
			Assert.AreEqual (normalSquare.ContainPlayers.Count, 1);
			Assert.IsTrue (normalSquare.ContainPlayers.Contains(player2));
			normalSquare.Enter (player);
			Assert.AreEqual (normalSquare.ContainPlayers.Count, 1);
			Assert.IsTrue (normalSquare.ContainPlayers.Contains(player));
		}

		[Test ()]
		public void TestNormalSquareLeave()
		{
			Square normalSquare = new NormalSquare ();
			Player player = new Player ("Dominic");
			Player player2 = new Player ("Lachlan");
			normalSquare.Enter (player);
			normalSquare.Enter (player2);
			normalSquare.Leave (player);
			Assert.AreEqual (normalSquare.ContainPlayers.Count, 1); //doesn't change since player is send back to firstBox
			normalSquare.Leave (player2);
			Assert.AreEqual (normalSquare.ContainPlayers.Count, 0);
		}

		[Test ()]
		public void TestLastSquareEnter()
		{
			Square lastSquare = new LastSquare ();
			Player player = new Player ("Dominic");
			Player player2 = new Player ("Lachlan");
			lastSquare.Enter (player);
			Assert.AreEqual (lastSquare.ContainPlayers.Count, 1);
			lastSquare.Enter (player2);
			Assert.AreEqual (lastSquare.ContainPlayers.Count, 1); //doesn't change since player 1 has already won
			Assert.IsTrue(lastSquare.ContainPlayers.Contains(player));
			lastSquare.Enter (player2);
			Assert.IsTrue(lastSquare.ContainPlayers.Contains(player));//lastsquare still constains player even if player2 keep on entering

		}

		[Test ()]
		public void TestLastSquareLeave()
		{
			Square lastSquare = new LastSquare ();
			Player player = new Player ("Dominic");
			Player player2 = new Player ("Lachlan");
			lastSquare.Enter (player);
			lastSquare.Leave (player);
			Assert.AreEqual (lastSquare.ContainPlayers.Count, 1); //doesn't change as player has won, player can't leave
			Assert.IsTrue(lastSquare.ContainPlayers.Contains(player));
		}
	}
}

