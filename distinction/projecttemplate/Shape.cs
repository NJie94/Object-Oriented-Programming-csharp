using System;
using Color = System.Drawing.Color;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Shape
	{
		private Color _color;
		private float _x, _y;
		private int _width, _height;
		private bool _selected;


		public Shape (Color clr,float x, float y )
		{
			_color = clr;
			_x = x;
			_y = y;

			_selected = false;
		}
		public Shape() : this(Color.Red,100,100)
		{

		}

		//draw shape to the screen
		public abstract void Drawshape();


		public virtual bool IsAt(Point2D pt)
		{
			return false;
		}
	
		public Color Color
		{
			get { return _color; }
			set { _color = value; }
		}

		public float X
		{
			get { return _x;}
			set {_x = value;}
		}
		public float Y
		{
			get { return _y;}
			set {_y = value;}
		}

		public int Width
		{
			get { return _width;}
			set { _width = value;}
		}
		public int Height
		{
			get{ return _height;}
			set { _height = value;}
		}

		public virtual void DrawOutline ()
		{
		}
		public bool Selected
		{
			get{ return _selected; }
			set{ _selected = value; }
		}
	}
}

