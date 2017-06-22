using System;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	public class Drawing
	{
		private readonly List<Shape> _shapes;
		private Color _background;

		public Drawing (Color background)
		{
			_shapes = new List<Shape> ();
			_background = background;
		}

		public Drawing () : this (Color.White)
		{
			//Something come here
		}

		public Color Mybackground
		{
			get
			{
				return _background;
			}
			set
			{
				_background = value;
			}

		}

		public int ShapeCount
		{
			get {return _shapes.Count; }
		}

		public void AddShape(Shape s)
		{
			_shapes.Add(s);
		}

		public void Draw()
		{
			SwinGame.ClearScreen (Mybackground);
			foreach (Shape s in _shapes)
			{
				s.Drawshape ();
			}
		}
		public List <Shape> SelectedShape
		{
			get
			{ 
				List<Shape> ListofSelectedShape = new List<Shape> ();
				foreach (Shape s in _shapes)
				{
					if (s.Selected)
						ListofSelectedShape.Add (s);
					else
						ListofSelectedShape.Remove (s);
				}
				return ListofSelectedShape;
			}
		
		}

		public void SelectShapeAt (Point2D pt)
		{
			foreach (Shape s in _shapes)
			{
				if (s.IsAt(pt))
				{
					s.Selected = true;
				}
				else
				{
					s.Selected = false;
				}
			}
		}
		public void RemoveShape (Shape s)
		{
			_shapes.Remove (s);
		}
	}
}

