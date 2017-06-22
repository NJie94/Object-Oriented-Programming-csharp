using System;
using SwinGameSDK;
using System.Reflection;
using Color = System.Drawing.Color;

namespace MyGame
{
	public class MainGame
	{
		public MainGame ()
		{
			SwinGame.OpenAudio ();
			SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
			SwinGame.ShowSwinGameSplashScreen ();

			Shape myShape = new Shape ();

			
			while(false == SwinGame.WindowCloseRequested())
			{
				SwinGame.ProcessEvents();

				SwinGame.ClearScreen(Color.White);
				SwinGame.DrawFramerate(0,0);

				myShape.Drawshape ();

				Point2D mouseLocation = SwinGame.MousePosition();

				if (SwinGameSDK.Input.MouseClicked(MouseButton.LeftButton))
						{
							myShape.X = SwinGame.MouseX();
							myShape.Y = SwinGame.MouseY();
						}
				if (myShape.IsAt (mouseLocation))
					{
						if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
						{
							myShape.Color = SwinGame.RandomRGBColor(255);
						}
					}
				SwinGame.RefreshScreen ();

			}

					SwinGame.CloseAudio();
					SwinGame.ReleaseAllResources();
				
		}
	}
}

