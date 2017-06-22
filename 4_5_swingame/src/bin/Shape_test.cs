using NUnit.Framework;
using System;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	[TestFixture()]
	public class Shape_test
	{
		[Test()]
		public void TestCase ()
		{
			Shape s = new Shape ();
			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;




			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsTrue (s.IsAt (SwinGame.PointAt (25, 25)));
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (10, 50)));
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsTrue (true);
			Assert.IsFalse (false);
		}
	}
}

