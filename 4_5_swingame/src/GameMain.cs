using System;
using System.Collections.Generic;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.IO;

namespace MyGame
{

	public static class ExtensionMethods
	{
		public static int ReadInteger(this StreamReader reader)
		{
			return Convert.ToInt32 (reader.ReadLine ());
		}
	}

    public class GameMain
    {
		private enum ShapeKind
		{
			Rectangle,
			Circle,
			Line
		}

        public static void Main()
        {
			Shape.RegisterShape ("Rectangle", typeof(Rectangle));
			Shape.RegisterShape ("Circle", typeof(Circle));
			Shape.RegisterShape ("Line", typeof(Line));


            //Start the audio system so sound can be played
//            SwinGame.OpenAudio();
            
            //Open the game window
			SwinGame.OpenGraphicsWindow("GameMain", 800, 600); 	
//            SwinGame.ShowSwinGameSplashScreen();

			ShapeKind kindToAdd = ShapeKind.Circle;
			Drawing mydrawing = new Drawing ();

			do
			{
				mydrawing.FreeList();
				SwinGame.ClearScreen (Color.White);
				SwinGame.DrawFramerate (0, 0);
				SwinGame.RefreshScreen();
				/*Shape s = new Shape ();*/
	            //Run the game loop
	            while(!SwinGame.WindowCloseRequested())
	            {

					//Fetch the next batch of UI interaction
					SwinGame.ProcessEvents ();
	            
					//Clear the screen and draw the framerate
					SwinGame.ClearScreen (Color.White);
					SwinGame.DrawFramerate (0, 0);

					Random rand = new Random ();
					Shape s = default(Shape);


					mydrawing.Draw ();
					if (Input.KeyTyped (KeyCode.vk_r))
						kindToAdd = ShapeKind.Rectangle;
					if (Input.KeyTyped (KeyCode.vk_c))
						kindToAdd = ShapeKind.Circle;
					if (Input.KeyTyped (KeyCode.vk_l))
						kindToAdd = ShapeKind.Line;
					if (Input.KeyTyped (KeyCode.vk_s))
						mydrawing.Save ("File.txt");

					if (Input.KeyDown (KeyCode.vk_KP_ENTER))
					{
						try
						{mydrawing.Load ("File.txt");}
						catch(Exception e)
						{
							Console.Error.WriteLine ("Error loading file:{0}", e.Message);
						}
					}


					if (SwinGame.MouseClicked(MouseButton.LeftButton))
					{

						//code written before inheritance
	//					s.X = SwinGame.MouseX ();
	//					s.Y = SwinGame.MouseY ();
				
					// 	done previously when abstract is not done->
						//	->Shape newShape = new Shape ();

						switch (kindToAdd)
						{
						case ShapeKind.Circle:
							Circle newCircle = new Circle ();
							newCircle.X = SwinGame.MouseX ();
							newCircle.Y = SwinGame.MouseY ();
							newCircle.Radius=(int)(rand.NextDouble()*100);
							Console.WriteLine ("(" + newCircle.X + "," + newCircle.Y + ")");

							s = newCircle;
							break;
						case ShapeKind.Rectangle:
							Rectangle newRect = new Rectangle ();
							newRect.Width=(int)(rand.NextDouble()*400);
							newRect.Height=(int)(rand.NextDouble()*400);
							newRect.X = SwinGame.MouseX () - newRect.Width / 2;
							newRect.Y = SwinGame.MouseY () - newRect.Height / 2;
							Console.WriteLine ("("+newRect.X+","+newRect.Y+")");

							s = newRect;
							break;
						case ShapeKind.Line:

							Line newLine = new Line ();
							newLine.X = SwinGame.MouseX ();
							newLine.Y = SwinGame.MouseY ();
	//						//center of the program is about (400,300)
							newLine.XEnd = (int)(rand.NextDouble () * 800);
							newLine.YEnd = (int)(rand.NextDouble () * 600);
							s= newLine;
							break;

						default:
							break;
						}
						mydrawing.AddShape (s);
					}

			
					if (Input.KeyDown (KeyCode.vk_SPACE))
					{
						mydrawing.BackgroundColor = SwinGame.RandomRGBColor (255);
					}

					if (SwinGame.MouseClicked (MouseButton.RightButton))
					{

						mydrawing.SelectShapesAt (SwinGame.MousePosition ());
						//done previously when abstract is not done
	//					if (s is Rectangle)
	//						(s as Rectangle).DrawOutline ();
	//					if (s is Circle)
	//						(s as Circle).DrawOutline ();
	//					else if (s is Line)
	//						(s as Line).DrawOutline ();

					}
					foreach (Shape Shapes in mydrawing.SelectedShapes)
					{
						if (Input.KeyTyped (KeyCode.vk_BACKSPACE) || Input.KeyTyped (KeyCode.vk_DELETE))
						{
							mydrawing.RemoveShape (Shapes);
	//						if (s is Rectangle)
	//							(s as Rectangle).DrawOutline ();
	//						if (s is Circle)
	//							(s as Circle).DrawOutline ();
	//						else if (s is Line)
	//							(s as Line).DrawOutline ();
						}
					}
						
		                //Draw onto the screen
		                SwinGame.RefreshScreen();
		        }
		            
		            //End the audio
		            SwinGame.CloseAudio();
		            
		            //Close any resources we were using
		            SwinGame.ReleaseAllResources();
			}while(Input.KeyTyped (KeyCode.vk_z));
		}
	}
}

