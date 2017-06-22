using System;
using SwinGameSDK;
using System.IO;
using Color = System.Drawing.Color; 

namespace MyGame
{
	public class Circle:Shape
	{
		private int _radius;

		public Circle ():this (Color.Green,50)
		{
		
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Circle"/> class.
		/// </summary>
		/// <param name="clr">color of Circle</param>
		/// <param name="radius">Radius.</param>
		public Circle(Color clr, int radius)
		{
			_color= clr;
			_radius = radius;
		}


		public int Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
			}
		}

		public override void Draw()
		{
			if (Selected)
				DrawOutline();
			Random r = new Random ();
			SwinGame.FillCircle (Color.FromArgb(r.Next()), X, Y, _radius);
		}

		/// <summary>
		/// Draws the outline.
		/// </summary>
		public override void DrawOutline()
		{
			SwinGame.FillCircle (Color.Black, _x, _y, _radius+2);
		}

		/// <summary>
		/// Determines whether this instance is at the specified pt.
		/// </summary>
		/// <returns><c>true</c> if this instance is at the specified pt; otherwise, <c>false</c>.</returns>
		/// <param name="pt">Point.</param>
		public override Boolean IsAt ( Point2D pt)
		{
			return Geometry.PointInCircle ( pt, _x, _y, _radius);
		}
			

		public override void SaveTo(StreamWriter writer)
		{
//			writer.WriteLine ("Circle");
			base.SaveTo (writer);
			writer.WriteLine (_radius);

		}

		public override void LoadFrom (StreamReader reader)
		{
			base.LoadFrom (reader);

			Radius = reader.ReadInteger ();
		}

	}
}

