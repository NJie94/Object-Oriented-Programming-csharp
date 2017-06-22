using NUnit.Framework;
using System;

namespace DistinctionProgram
{
	[TestFixture ()]
	public class DieTest
	{
		[Test ()]
		public void TestDieRandomNumberGenerator ()
		{
			Die die=new Die();
			Assert.AreEqual (die.DieNumber, 1);
			die.Roll ();
			Assert.GreaterOrEqual (die.DieNumber, 1);
			die.Roll ();
			Assert.LessOrEqual (die.DieNumber,6);
			for (int i = 0; i < 12; i++) {
				Console.WriteLine (die.DieNumber);
				die.Roll ();
			}

		}

	}
}

