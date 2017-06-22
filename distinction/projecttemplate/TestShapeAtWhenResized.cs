using NUnit.Framework;
using System;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	[TestFixture ()]
	public class TestShapeAtWhenResized
	{
		[Test ()]
		public void TestCaseAt ()
		{
			Shape s = new Shape ();

			s.X = 25;
			s.Y = 25;
			s.Width = 100;
			s.Height = 100;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (100, 100)));
			Assert.IsTrue (s.IsAt (SwinGame.PointAt (25, 25)));

			Assert.IsFalse (s.IsAt (SwinGame.PointAt (10, 50)));
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 10)));

		}
	}
}

