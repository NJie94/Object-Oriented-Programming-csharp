using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.IO;

namespace MyGame
{
	public class Rectangle:Shape
	{
		private int _width,_height;

		/// <summary>
		/// Initializes a new instance of the Rectangle class.
		/// </summary>
		public Rectangle ():this (Color.Silver,0,0,70,70)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Rectangle"/> class.
		/// </summary>
		/// <param name="clr">Color of the Rectangle</param>
		/// <param name="x">The x coordinate </param>
		/// <param name="y">The y coordinate</param>
		/// <param name="width">Width of Rectangle</param>
		/// <param name="height">Height of Rectangle</param>
		public Rectangle(Color clr,float x, float y , int width, int height):base(clr)
		{
			Colour = clr;
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		/// <summary>
		/// Draw this instance.
		/// </summary>
		public override void Draw()
		{
			if (Selected)
				DrawOutline();
			Random r = new Random ();
			SwinGame.FillRectangle (Color.FromArgb(r.Next()), X, Y, Height,Width);
		}

		/// <summary>
		/// Draws the outline.
		/// </summary>
		public override void DrawOutline()
		{
			SwinGame.FillRectangle (Color.Black, _x-2, _y-2, _width+4, _height+4);
		}

		/// <summary>
		/// Determines whether this instance is at the specified pt.
		/// </summary>
		/// <returns><c>true</c> if this instance is at the specified pt; otherwise, <c>false</c>.</returns>
		/// <param name="pt">Point.</param>
		public override Boolean IsAt ( Point2D pt)
		{
			return Geometry.PointInRect ( pt, _x, _y, _width, _height );
		}

		/// <summary>
		/// Gets or sets the height.
		/// </summary>
		/// <value>The height.</value>
		public int Height
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
		public int Width
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

		/// <summary>
		/// Saves to writer
		/// </summary>
		/// <param name="writer">Writer.</param>
		public override void SaveTo(StreamWriter writer)
		{
			base.SaveTo (writer);
			writer.WriteLine (_width);
			writer.WriteLine (_height);

		}

		/// <summary>
		/// Loads from writer
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override void LoadFrom (StreamReader reader)
		{
			base.LoadFrom (reader);
			Width = reader.ReadInteger ();
			Height = reader.ReadInteger ();
		}

	}
}

