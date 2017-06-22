using System;
using System.Collections.Generic;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.IO;

namespace MyGame
{
	public class Drawing
	{
		private List<Shape> _shapes= new List<Shape>();
		private Color _background;
		private const string FilePath=@"C:\Users\Dominic\Desktop\";
		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Drawing"/> class.
		/// </summary>
		public Drawing ():this (Color.White)
		{
		
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="MyGame.Drawing"/> class.
		/// </summary>
		/// <param name="background">Background.</param>
		public Drawing(Color background)
		{
			_background = background;
		}
		/// <summary>
		/// Gets or sets the color of the background.
		/// </summary>
		/// <value>The color of the background.</value>
		public Color BackgroundColor
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
		/// <summary>
		/// Gets the selected shapes.
		/// </summary>
		/// <value>The selected shapes.</value>
		public List<Shape> SelectedShapes
		{
			get
			{	
				List<Shape> ListofSelectedShapes=new List<Shape>();
				foreach (Shape s in _shapes)
				{
					if (s.Selected)					
						ListofSelectedShapes.Add (s);
					else
						ListofSelectedShapes.Remove (s);
				}

				return ListofSelectedShapes;
			}
		}
			
		/// <summary>
		/// Selects the shapes at pt.
		/// </summary>
		/// <param name="pt">Point.</param>
		public void SelectShapesAt(Point2D pt)
		{
			foreach (Shape s in _shapes)
			{
				s.Selected = s.IsAt (pt);
			}
		}
		/// <summary>
		/// Adds the shape.
		/// </summary>
		/// <param name="s">S.</param>
		public void AddShape(Shape s)
		{
			_shapes.Add (s);
		}
		/// <summary>
		/// Removes the shape.
		/// </summary>
		/// <param name="s">S.</param>
		public void RemoveShape(Shape s)
		{
			s.Selected = false;
			_shapes.Remove (s);

		}

		public void FreeList()
		{
			 _shapes.Clear ();
		}


		/// <summary>
		/// Gets the count from the list of _shapes
		/// </summary>
		/// <value>the number of shapes in list  in int</value>
		public int Count
		{
			get
			{
				return _shapes.Count;
			}
		}

		/// <summary>
		/// Draw this instance.
		/// </summary>
		public void Draw()
		{
			SwinGame.ClearScreen(BackgroundColor);
			foreach (Shape s in _shapes)
			{
				s.Draw ();
			}
		}

		public void Save(string Filename)
		{

			StreamWriter writer= new StreamWriter(FilePath+Filename);
			try
			{
				writer.WriteLine (_background.ToArgb ());
				writer.WriteLine (Count);
				foreach (Shape s in _shapes)
				{
					s.SaveTo (writer);
				}
			}
			finally
			{
				writer.Close ();
			}
		}

		public void Load(string filename)
		{
			int _count, i;
			Shape s = default(Shape);
			string kind;

			StreamReader reader = new StreamReader (FilePath+filename);
			try{
					BackgroundColor = Color.FromArgb (reader.ReadInteger ());
					_count = reader.ReadInteger();
					for (i = 0; i < _count; i++)
						{
							kind = reader.ReadLine ();
							s=Shape.CreateShape (kind);
							s.LoadFrom(reader);
							AddShape (s);				
						}
					}
				finally
				{
					reader.Close ();
				}

			}

	}
}
