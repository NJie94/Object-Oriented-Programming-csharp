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
			Rectangle newRect = new Rectangle();
			newRect.X = 25;
			newRect.Y = 25;
			newRect.Width = 50;
			newRect.Height = 50;

			Assert.IsTrue (newRect.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsFalse (newRect.IsAt (SwinGame.PointAt (76, 76)));
		}

		[Test()]
		public void TestShapeAtWhenMoved()
		{
			Rectangle newRect = new Rectangle();
			newRect.X = 30;
			newRect.Y = 30;
			newRect.Width = 50;
			newRect.Height = 50;

			Assert.IsTrue (newRect.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsFalse (newRect.IsAt (SwinGame.PointAt (25, 25)));

			newRect.X = 25;
			newRect.Y = 25;
			Assert.IsTrue (newRect.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsFalse (newRect.IsAt (SwinGame.PointAt (76, 76)));
		}

		[Test()]
		public void TestShapeAtWhenResized()
		{

			Rectangle newRect = new Rectangle();
			newRect.X = 30;
			newRect.Y = 30;
			newRect.Width = 50;
			newRect.Height = 50;

			Assert.IsTrue (newRect.IsAt (SwinGame.PointAt (50, 50)));
			Assert.IsFalse (newRect.IsAt (SwinGame.PointAt (25, 25)));

			newRect.Width = 10;
			newRect.Height = 10;

			Assert.IsFalse (newRect.IsAt (SwinGame.PointAt (76, 76)));
			Assert.IsTrue (newRect.IsAt (SwinGame.PointAt (35, 39)));
		}

		[Test()]
		public void TestShapeIfRemembers()
		{
			Rectangle newRect = new Rectangle();
			Assert.IsFalse (newRect.Selected, "should be false");
			newRect.Selected = true;
			Assert.IsTrue(newRect.Selected,"should be true");
		}

		[Test()]
		public void TestingNewConstructor()
		{
			Rectangle newRect = new Rectangle(Color.Red, 25, 25, 50, 50);
			Assert.AreEqual (newRect.Colour, Color.Red);
			Assert.AreEqual (newRect.X, 25);
			Assert.AreEqual (newRect.Y,25);
			Assert.AreEqual (newRect.Width,50);
			Assert.AreEqual (newRect.Height,50);
		}
	}
}

