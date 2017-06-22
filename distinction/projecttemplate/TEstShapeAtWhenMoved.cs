using NUnit.Framework;
using System;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	[TestFixture ()]
	public class TEstShapeAtWhenMoved
	{
		[Test ()]
		public void TestCaseAt ()
		{
			Shape s = new Shape ();

			s.X = 50;
			s.Y = 50;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)));

			Assert.IsFalse (s.IsAt (SwinGame.PointAt (10, 50)));
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 10)));
		}
	}
}

