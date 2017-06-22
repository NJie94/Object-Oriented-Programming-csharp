
using System;

namespace DistinctionProgram
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			int numberOfPlayers;
			bool TryParseException;
			int x;


			Console.WriteLine ("Hi, Welcome To Dominic's Game");
			Game game = new Game ();

			Console.WriteLine ("How state how many players are playing (minimum 1)\n");


			TryParseException= int.TryParse(Console.ReadLine(),out numberOfPlayers);

			while (!TryParseException||(numberOfPlayers<1)) {
				Console.WriteLine ("Please Enter a number Larger than 0");
				TryParseException = int.TryParse (Console.ReadLine (), out numberOfPlayers);
			}

			for (x = 0; x < numberOfPlayers; x++) {
				game.EnterGame (new Player(Console.ReadLine ()));
			}

			Console.WriteLine ("Game Starting\n");
			while(!game.HasWon())
				foreach (Player player in game.Participants) 
			{
					if (game.HasWon ())
						break;
					game.PlayerRollDie (player);

			}
			Console.WriteLine ("We Have A Winner!!!" +
				"The Winner is {0}",game.Winner());
			Console.ReadLine ();



		}
	}
}
