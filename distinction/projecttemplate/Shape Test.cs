using NUnit.Framework;
using System;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	[TestFixture ()]
	public class ShapeTests
	{
		[Test ()]
		public void TestShapeAt ()
		{
			Rectangle s = new Rectangle ();
			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)) );
			Assert.IsTrue (s.IsAt (SwinGame.PointAt (25, 25)) );
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (10, 50)) );
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 10)) );
		}

		[Test ()]
		public void TestShapeAtWhenMoved ()
		{
			Rectangle s = new Rectangle ();

			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)) );
			Assert.IsTrue (s.IsAt (SwinGame.PointAt (25, 25)) );
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (10, 50)) );
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 10)) );

			s.X = 10;
			s.Y = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (10, 50)) );
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (25, 25)));
		}

		[Test ()]
		public void TestShapeAtWhenResized ()
		{
			Rectangle s = new Rectangle ();

			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (75, 75)) );
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (50, 10)) );

			s.Width = 25;
			s.Height = 25;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (50, 50)) );
			Assert.IsFalse (s.IsAt (SwinGame.PointAt (75, 75)) );
		}

		[Test ()]
		public void TestShapeSelected ()
		{
			Rectangle s = new Rectangle (Color.Red, 100, 100, 200, 200);
			Assert.IsFalse (s.Selected);
			s.Selected = true;
			Assert.IsTrue (s.Selected);
		}
	}
}
