using System;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	public class Line : Shape
	{
		//field
		private float _XFinal;
		private float _YFinal;

		//constructor
		public Line (Color colour, float _x, float _y) 
		{
			
			_XFinal = _x + 50;
			_YFinal = _y + 50;
		}

		//default constructor
		public Line():this (SwinGame.RandomRGBColor(255), 0, 0)
		{
		}

		//property
		public float xEnd
		{
			get{ return _XFinal; }
			set{ _XFinal = value; }
		}

		public float yEnd
		{
			get{ return _YFinal; }
			set{ _YFinal = value; }
		}

	
		public override void DrawOutline ()
		{
			SwinGame.DrawCircle (Color.Black, X, Y, 5);
			SwinGame.DrawCircle (Color.Black, _XFinal, _YFinal, 5);
		} 

		public override void Drawshape ()
		{
			if (Selected)
			{
				DrawOutline ();	
			}
			SwinGame.DrawLine (Color, X, Y, _XFinal+100, _YFinal+100);
		}

		public override bool IsAt (Point2D pt)
		{
			return (SwinGame.PointOnLine(pt, X, Y, _XFinal, _YFinal));
		}
	}
}