using System;
using SwinGameSDK;
using Color = System.Drawing.Color; 
using System.Reflection;
using System.IO;
using System.Collections.Generic;

namespace MyGame
{

	public abstract class Shape
	{

		protected Color _color;
		protected float _x, _y;
		private bool _selected;
		public static Dictionary<string,Type> _ShapeClassRegistry = new Dictionary<string, Type> ();

		/// <summary>
		/// Registers the shape.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="t">T.</param>
		public static void RegisterShape(string name, Type t)
		{
			_ShapeClassRegistry [name] = t;
		}

		/// <summary>
		/// Creates the shape.
		/// </summary>
		/// <returns>The shape.</returns>
		/// <param name="name">Name.</param>
		public static Shape CreateShape(string name)
		{
			return (Shape)Activator.CreateInstance (_ShapeClassRegistry [name]);
		}

		/// <summary>
		/// Keies the type.
		/// </summary>
		/// <returns>The type.</returns>
		/// <param name="key">Key.</param>
		public static string KeyType(Type key)
		{
			string shapes = "";
			Dictionary<string, Type> DicShape = new Dictionary<string, Type> ();
			DicShape.Add ("Rectangle", typeof(Rectangle));
			DicShape.Add ("Circle", typeof(Circle));
			DicShape.Add ("Line", typeof(Line));

			foreach(KeyValuePair<string, Type > keytypes in _ShapeClassRegistry )
			{
				if (key == keytypes.Value)
				{
					shapes = keytypes.Key;
				}
			}
			return shapes;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Shape"/> class.
		/// </summary>
		public Shape ()
		{
			_color = Color.White;
			_x = 0;
			_y = 0;
			_selected = false;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Shape"/> class.
		/// </summary>
		/// <param name="colour">Colour.</param>
		public Shape(Color colour)
		{
			_color = colour;
		}

		public abstract void Draw ();
		public abstract Boolean IsAt(Point2D pt);
		public abstract void DrawOutline ();
		/// <summary>
		/// Gets or sets the colour.
		/// </summary>
		/// <value>The colour.</value>
		public Color Colour
		{
			get
			{
				return _color; 
			}
			set
			{
				_color = value;
			}
		}
		/// <summary>
		/// Gets or sets the x.
		/// </summary>
		/// <value>The x.</value>
		public float X
		{
			get
			{
				return _x;
			}

			set
			{
				_x = value;
			}
		}
		/// <summary>
		/// Gets or sets the y.
		/// </summary>
		/// <value>The y.</value>
		public float Y
		{
			get
			{
				return _y;
			}

			set
			{
				_y = value;

			}
		}


		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="MyGame.Shape"/> is selected.
		/// </summary>
		/// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}

		public virtual void SaveTo(StreamWriter writer)
		{

			string key = KeyType (GetType ());
			writer.WriteLine (key);
			writer.WriteLine (Colour.ToArgb());
			writer.WriteLine (_x);
			writer.WriteLine (_y);

		}

		public virtual void LoadFrom (StreamReader reader)
		{
			Colour = Color.FromArgb (reader.ReadInteger ());
			X = reader.ReadInteger ();
			Y = reader.ReadInteger ();
		}


	}
}



