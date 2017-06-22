using System;
using SwinGameSDK;
using Color=System.Drawing.Color;
using System.IO;

namespace MyGame
{
	public class Line:Shape
	{
		float _xEnd;
		float _yEnd;

		public Line ():this (Color.Gold,10,10,100,100)
		{

		}

		/// <summary>
		/// Initializes a new instance of the Line class.
		/// </summary>
		/// <param name="clr">Color of the Line</param>
		/// <param name="X">X coordinate of  Starting Point</param>
		/// <param name="Y">Y coordinate of Starting Point</param>
		/// <param name="XEnd">X coordinate of end Point</param>
		/// <param name="YEnd">Y coordinate of end Point</param>
		public Line (Color clr, float X, float Y,float XEnd ,float YEnd )
		{
			_color = clr;
			_x =X;
			_y =Y;
			_xEnd = XEnd;
			_yEnd = YEnd;

		}

		/// <summary>
		/// Draw this instance.
		/// </summary>
		public override void Draw()
		{
			if (Selected)
				DrawOutline ();
			SwinGame.DrawLine(Color.Gold,_x,_y,XEnd,YEnd);
		}

		/// <summary>
		/// Draws the outline of the Line
		/// </summary>
		public override void DrawOutline()
		{
			SwinGame.DrawLine (Color.Black,_x,_y,_x+100,_y+100);
			SwinGame.FillCircle (Color.Bisque, X, Y, 5);
			SwinGame.FillCircle (Color.Bisque, X+100, Y+100, 5);

		}

		/// <summary>
		/// Gets or sets the X coordinate of End Point
		/// </summary>
		/// <value>The X end.</value>
		public float XEnd 
		{
			get
			{
				return _xEnd;
			}
			set
			{
				_xEnd = value;
			}
		}

		/// <summary>
		/// Gets or sets the Y coordinate of End Point
		/// </summary>
		/// <value>The Y end.</value>
		public float YEnd
		{
			get
			{
				return _yEnd;
			}
			set
			{
				_yEnd = value;
			}
		}

		/// <summary>
		/// Determines whether this instance is at the specified point
		/// </summary>
		/// <returns><c>true</c> if this instance is at the specified pt; otherwise, <c>false</c>.</returns>
		/// <param name="pt">Point.</param>
		public override Boolean IsAt ( Point2D pt)
		{
			//return Geometry.PointOnLine ( pt, _x, _y, _xEnd,_yEnd);

			//because so difficult to click on any point on the line , so
			return Geometry.PointInRect (pt, _x, _y, 500, 500);
		}

		/// <summary>
		/// Saves to writer
		/// </summary>
		/// <param name="writer">Writer.</param>
		public override void SaveTo(StreamWriter writer)
		{

			base.SaveTo (writer);
			writer.WriteLine (_xEnd);
			writer.WriteLine (_yEnd);

		}

		/// <summary>
		/// Loads from writer
		/// </summary>
		/// <param name="reader">Reader.</param>
		public override void LoadFrom (StreamReader reader)
		{
			base.LoadFrom (reader);
			_xEnd = reader.ReadInteger ();
			_yEnd = reader.ReadInteger ();
		}
	}
}

