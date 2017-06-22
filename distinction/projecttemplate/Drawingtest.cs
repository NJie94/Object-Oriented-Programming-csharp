using NUnit.Framework;
using System;
using Color = System.Drawing.Color;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	[TestFixture ()]
	public class TestDefaultDrawing
	{
		[Test ()]
		public void TestDefaultinitialisation ()
		{
			Drawing Draw =new Drawing ();
			Assert.IsTrue (Draw.Mybackground == Color.White);
		}
		[Test ()]
		public void testwithcolor ()
		{
			Drawing Draw =new Drawing (Color.Blue);
			Assert.IsTrue (Draw.Mybackground == Color.Blue);
		}

		[ Test()]
		public void TestAddShape()
		{
			Drawing myDrawing= new Drawing();
			int count = myDrawing.ShapeCount;

			Assert.AreEqual (0, count, "Drawing should start with no shapes");

			myDrawing.AddShape (new Rectangle());
			myDrawing.AddShape (new Rectangle());
			count = myDrawing.ShapeCount;

			Assert.AreEqual (2, count, "Adding two shapes should increase the count to 2");
		}

		/*[ Test()]
		public void Shapetest()
		{
			Shape st = new Shape (Color.Blue, 0, 0, 0, 0);
			st.X = 25;
			st.Y = 25;
			st.Width = 100;
			st.Height = 100;


			Assert.IsTrue (st.IsAt(SwinGame.PointAt(50,50)) );
			Assert.IsTrue (st.IsAt(SwinGame.PointAt(25,25)) );
			Assert.IsFalse (st.IsAt(SwinGame.PointAt(10,50)) );
			Assert.IsFalse (st.IsAt(SwinGame.PointAt(50,10)) );
		}
		public void ResizedShapetest()
		{
			Shape rst = new Shape (Color.Blue, 0, 0, 50, 50);
			rst.X = 25;
			rst.Y = 25;
			rst.Width = 100;
			rst.Height = 100;


		
			Assert.IsTrue (rst.IsAt(SwinGame.PointAt(25,25)) );
			Assert.IsTrue (rst.IsAt(SwinGame.PointAt(25,25)) );
		}*/
			
		[Test ()]
		public void TestSelectShape ( )
		{
			Drawing myDrawing = new Drawing ();

			Shape [] testShapes = {

				new Rectangle (Color.Red, 25, 25, 50, 50),
				new Rectangle (Color.Green, 25, 10, 50, 50),
				new Rectangle (Color.Blue, 10, 25, 50, 50)

			};

			foreach (Shape s in testShapes)
			{
				myDrawing.AddShape (s);
			}

			List<Shape> Selected;
			Point2D point;

			point = SwinGame.PointAt (70, 70);
			myDrawing.SelectShapeAt (point);
			Selected = myDrawing.SelectedShape;

			CollectionAssert.Contains (Selected, testShapes [0]);
			Assert.AreEqual (1, Selected.Count);

			point = SwinGame.PointAt (70, 50);
			myDrawing.SelectShapeAt (point);
			Selected = myDrawing.SelectedShape;

			CollectionAssert.Contains (Selected, testShapes [0]);
			CollectionAssert.Contains (Selected, testShapes [1]);
			Assert.AreEqual (2, Selected.Count); 
		}

		[Test ()]
		public void TestRemoveShape ( )
		{
			Drawing myDrawing = new Drawing ();

			Shape[] testShapes = {

				new Rectangle (Color.Red, 25, 25, 50, 50),
				new Rectangle (Color.Green, 25, 10, 50, 50),
				new Rectangle (Color.Blue, 10, 25, 50, 50)

			};

			Point2D point;
			List<Shape> selected;
			Shape shapeRemoved = testShapes [1];

			foreach (Shape s in testShapes)
			{
				myDrawing.AddShape (s);
			}

			point = SwinGame.PointAt (25, 10);
			myDrawing.SelectShapeAt (point);
			selected = myDrawing.SelectedShape;

			Assert.AreEqual (3, myDrawing.ShapeCount);
			CollectionAssert.Contains (selected, shapeRemoved);

			myDrawing.RemoveShape (shapeRemoved);
			selected = myDrawing.SelectedShape;

			myDrawing.SelectShapeAt (point);

			Assert.AreEqual (2, myDrawing.ShapeCount);
			CollectionAssert.DoesNotContain (selected, shapeRemoved);
		}
	}
}

