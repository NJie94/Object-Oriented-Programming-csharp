using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;
using System.IO;

namespace MyGame
{
	public class Circle : Shape
	{
		private int _radius;

		public Circle (Color clr, float x, float y, int radius) : base (clr, x, y)
		{
			_radius = radius;
		}

		public Circle ():this (SwinGame.RandomRGBColor(255), 0, 0, 50)
		{

		}

		public override void Drawshape()
		{
			if (Selected)
				DrawOutline ();
			SwinGame.FillCircle (Color, X, Y, _radius);
		}
		public override Boolean IsAt ( Point2D pt)
		{
			return Geometry.PointInCircle ( pt, X, Y, _radius);
		}
		public override void DrawOutline()
		{
			SwinGame.DrawCircle (Color.Black, X, Y, _radius+2);
		}
	}
}

