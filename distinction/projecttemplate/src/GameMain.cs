using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
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
			SwinGame.OpenAudio ();
			SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
			SwinGame.ShowSwinGameSplashScreen ();

			Drawing myDrawing = new Drawing();

			ShapeKind KindtoAdd = ShapeKind.Circle;


			while(false == SwinGame.WindowCloseRequested())
			{
				SwinGame.ProcessEvents();

				SwinGame.ClearScreen(Color.White);
				SwinGame.DrawFramerate(0,0);

				myDrawing.Draw ();

				if (Input.KeyTyped (KeyCode.vk_r))
					KindtoAdd = ShapeKind.Rectangle;
				if (Input.KeyTyped (KeyCode.vk_c))
					KindtoAdd = ShapeKind.Circle;
				if (Input.KeyTyped (KeyCode.vk_l))
					KindtoAdd = ShapeKind.Line;

				Point2D mouseLocation = SwinGame.MousePosition();


				if (SwinGameSDK.Input.MouseClicked(MouseButton.LeftButton))
				{
					/*Shape myShape = new Shape();
					myShape.Color = SwinGame.RandomRGBColor (255);
					myShape.X = SwinGame.MouseX();
					myShape.Y = SwinGame.MouseY();
					myDrawing.AddShape (myShape);*/

					Shape newShape = default(Shape);
					if (KindtoAdd == ShapeKind.Circle)
					{
						Circle newCircle = new Circle ();
						newCircle.X = SwinGame.MouseX ();
						newCircle.Y = SwinGame.MouseY ();
						newShape = newCircle;
					}
					else if (KindtoAdd == ShapeKind.Rectangle)
					{
						Rectangle newRect = new Rectangle ();
						newRect.X = SwinGame.MouseX ();
						newRect.Y = SwinGame.MouseY ();
						newShape = newRect;
					}
					else if (KindtoAdd == ShapeKind.Line)
					{
						Line newLine = new Line ();
						newLine.X = SwinGame.MouseX();
						newLine.Y = SwinGame.MouseY();
						newShape = newLine;
					}
					myDrawing.AddShape (newShape);
				}

				if (SwinGame.MouseClicked (MouseButton.RightButton))
				{
					myDrawing.SelectShapeAt (SwinGame.MousePosition());
				}
				if (SwinGame.KeyTyped(KeyCode.vk_DELETE))
				{
					List<Shape> selected = myDrawing.SelectedShape;
					foreach (Shape s in selected)
					{
						myDrawing.RemoveShape(s);
					}
				}

				//if (myShape.IsAt (mouseLocation))
				//{
					if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
					{
						myDrawing.Mybackground = SwinGame.RandomRGBColor(255);

					}
				//}
				SwinGame.DrawFramerate(0,0);
				SwinGame.RefreshScreen ();

			}

            
            //End the audio
            SwinGame.CloseAudio();
            
            //Close any resources we were using
            SwinGame.ReleaseAllResources();
        }
    }
}