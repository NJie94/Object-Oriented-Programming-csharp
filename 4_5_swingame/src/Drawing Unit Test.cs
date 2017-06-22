using NUnit.Framework;
using System;
using System.Reflection;
using System.Collections.Generic;
using SwinGameSDK;
using Color = System.Drawing.Color; 

namespace MyGame
{
	[TestFixture ()]
	public class Drawing_Unit_Test
	{
		[Test ()]
		public void TestDefaultInitialisation ()
		{
			Drawing newDraw =new Drawing ();
			Assert.NotNull(newDraw);
			Assert.AreEqual (Color.White, newDraw.BackgroundColor);
		}

		[Test ()]
		public void TestInitialisewithColor ()
		{
			Drawing newDraw =new Drawing (Color.Blue);
			Assert.NotNull(newDraw);
			Assert.AreEqual (Color.Blue, newDraw.BackgroundColor);
		}
		
		[ Test()]
		public void TestAddShape()
		{
			Drawing myDrawing= new Drawing();
			Assert.AreEqual (0, myDrawing.Count);

			myDrawing.AddShape (new Rectangle());
			myDrawing.AddShape (new Circle());
			myDrawing.AddShape (new Line());

			Assert.AreEqual (3, myDrawing.Count);
		}

		[ Test()]
		public void TestSelectShape()
		{
			Drawing myDrawing = new Drawing ();
			Shape[] testShapes =
			{	new Rectangle (Color.Red, 25, 25, 50, 50),
				new Rectangle (Color.Green, 25, 10, 50, 50),
				new Rectangle (Color.Blue, 10, 25, 50, 50)
			};
			foreach(Shape s in testShapes)
			{
				myDrawing.AddShape(s);
			}

			List<Shape> selected;
			Point2D point;
			point=SwinGame.PointAt(70,70);
			myDrawing.SelectShapesAt(point);
			selected=myDrawing.SelectedShapes;
			CollectionAssert.Contains(selected,testShapes[0]);
			Assert.AreEqual(selected.Count,1);

			point=SwinGame.PointAt(70,50);
			myDrawing.SelectShapesAt(point);
			selected=myDrawing.SelectedShapes;
			CollectionAssert.Contains(selected,testShapes[0]);
			CollectionAssert.Contains(selected,testShapes[1]);
			Assert.AreEqual(selected.Count,2);
		}

		[Test()]

		public void RemoveShapeTest()
		{
			Drawing myDrawing = new Drawing ();
			Shape[] s =
			{	new Rectangle (Color.Red, 25, 25, 50, 50),
				new Rectangle (Color.Green, 25, 10, 50, 50),
				new Rectangle (Color.Blue, 10, 25, 50, 50)
			};

			Point2D point= SwinGame.PointAt (26, 26);
			//no shape in list
			Assert.AreEqual(myDrawing.Count,0); 
			//can't be selected because no shape in list
			Assert.IsFalse(s[0].Selected);
			//add shape into list
			myDrawing.AddShape (s[0]);
			//1 shape in list
			Assert.AreEqual(myDrawing.Count,1); 

			myDrawing.SelectShapesAt (point);
			//select 
			Assert.IsTrue(s[0].Selected);
			//remove shape from list
			myDrawing.RemoveShape (s[0]);
			//no shape in list because removed
			Assert.AreEqual (myDrawing.Count, 0);


			myDrawing.SelectShapesAt (point);
			//can't be selected at point
			Assert.IsFalse(s[0].Selected,"should be false");
		}
	}
}

 