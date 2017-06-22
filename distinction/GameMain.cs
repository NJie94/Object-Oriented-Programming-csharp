using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class GameMain
	{

		public static void Main()
		{
			/*SwinGame.OpenAudio ();
			SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
			SwinGame.ShowSwinGameSplashScreen ();*/


			/*while(false == SwinGame.WindowCloseRequested())
			{
				SwinGame.ProcessEvents();

				SwinGame.ClearScreen(Color.White);
				SwinGame.DrawFramerate(0,0);*/


				var game = new GamePlay();
			game.Player.UpdatedBalance += game.Player.OnBalanceChanged;
				game.LastStateChanged += game.Player.OnLastStateChanged;
				game.AllowedActionsChanged += game.Player.OnAllowedActionsChanged;
				game.Dealer.Round.Variable += game.Player.OnHandChanged;
				game.Player.Round.Variable += game.Player.OnHandChanged;
				game.PlayGame(balance: 1000, bet: 50);

				while(true)
				{
					var key = Console.ReadKey (true);

					switch (key.Key)
					{
					case ConsoleKey.Spacebar:
						if ((game.AllowedActions & Control.Deal) == Control.Deal)
						{
							game.Deal();
						}
						else
						{
							game.Hit();
						}
						break;

					case ConsoleKey.Enter:
						if ((game.AllowedActions & Control.Deal) == Control.Deal)
						{
							game.Deal();
						}
						else
						{
							game.Hold();
						}
						break;

					case ConsoleKey.Add:
					case ConsoleKey.UpArrow:
						game.Player.Bet += 20;
						break;

					case ConsoleKey.Subtract:
					case ConsoleKey.DownArrow:
						game.Player.Bet -= 20;
						break;
					}
			}



				/*SwinGame.DrawFramerate(0,0);
				SwinGame.RefreshScreen ();

			}


			//End the audio
			SwinGame.CloseAudio();

			//Close any resources we were using
			SwinGame.ReleaseAllResources();*/
		}
	}
}
	