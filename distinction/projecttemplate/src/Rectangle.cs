using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.IO;

namespace MyGame
{
	public class Rectangle : Shape
	{
		private int _width, _height;


		public Rectangle(Color clr,float _x, float _y , int width, int height) : base(clr, _x, _y)
		{
			_width = width;
			_height = height;
		}

		public Rectangle ():this (SwinGame.RandomRGBColor(255),0,0,100,100)
		{

		}

		public override void Drawshape()
		{
			if (Selected)
			{
				DrawOutline ();
			}
			Random r = new Random ();
			SwinGame.FillRectangle (Color, X, Y, _width, _height);
		}

		public override void DrawOutline ()
		{
			SwinGame.DrawRectangle (Color.Black, (X - 2), (Y - 2), (_width + 4), (_height + 4));

		}
		


		public int Recheight
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
			}
		}

		/// <summary>
		/// Gets or sets the width.
		/// </summary>
		/// <value>The width.</value>
		public int Recwidth
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}

		}
		public override Boolean IsAt ( Point2D pt)
		{
			return SwinGame.PointInRect (pt, X, Y, _width, _height);
		}
	}
}

