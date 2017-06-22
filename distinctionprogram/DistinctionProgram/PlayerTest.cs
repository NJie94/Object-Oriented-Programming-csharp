using NUnit.Framework;
using System;

namespace DistinctionProgram
{
	[TestFixture ()]
	public class PlayerTest
	{
		[Test ()]
		public void TestPlayerName ()
		{
			Player player = new Player ("Lachlan");
			Assert.AreEqual (player.Name,"Lachlan");
			Player player2 = new Player ("Dominic");
			Assert.AreEqual (player2.Name,"Dominic");
		}

		[Test()]
		public void TestPlayerInitialPosition()
		{
			Player player = new Player ("Dominic");
			Assert.AreEqual (player.CurrentPosition,1);
		}

		[Test()]
		public void TestPlayerMove()
		{
			Player player = new Player ("Dominic");
			player.RollDie ();
			player.Move(6);
			Assert.AreEqual (player.CurrentPosition,7);
			player.Move(5);
			Assert.AreEqual (player.CurrentPosition,12);
		}

		[Test()]
		public void TestPlayerMoveBack()
		{
			Player player = new Player ("Dominic");
			player.Move (10);
			Assert.AreEqual (player.CurrentPosition,11);
			player.Move (-5);
			Assert.AreEqual (player.CurrentPosition,6);
			player.Move (-11);
			Assert.AreEqual (player.CurrentPosition,1);
		}

		[Test()]
		public void TestPlayerReturnToFirstBox()
		{
			Player player = new Player ("Dominic");
			player.Move (10);
			player.ReturnToFirstBox ();
			Assert.AreEqual (player.CurrentPosition,1);
		}
	}
}

