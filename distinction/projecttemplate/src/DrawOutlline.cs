using System;
using Color = System.Drawing.Color;
using SwinGameSDK;
namespace MyGame
{
	public class DrawOutlline
	{
		protected Color _color;
		protected float _x, _y;
		protected int _width, _height;
		private bool _selected;


		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Shape"/> class.
		/// </summary>
		/// <param name="clr">Clr.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public DrawOutlline (Color clr,float x, float y, int width, int height)
		{
			_color = clr;
			_x = x;
			_y = y;
			_width = width;
			_height = height;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Shape"/> class.
		/// </summary>
		public DrawOutlline() : this(Color.AliceBlue, 0,0,100,100)
		{

		}
		//draw shape to the screen
		public virtual void Drawshape()
		{
		}

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
			set {_width = value;}
		}
		public int Height
		{
			get { return _height;}
			set {_height = value;}
		}

		public bool Selected
		{
			get { return _selected;}
			set{ _selected = value;}
		}
		public virtual void DrawOutline()
		{
			
		}
	}
}

