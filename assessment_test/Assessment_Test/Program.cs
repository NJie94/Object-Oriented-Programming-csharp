using System;

namespace Assessment_Test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Shapeshifter mystique = new Shapeshifter ();
			Wolf wolf = new Wolf ();
			Dragon dragon = new Dragon ();
			mystique.Meld (dragon);
			mystique.Meld (wolf);
			mystique.Shift (true);
			mystique.Call ();//Should Print Shooting
			Console.ReadLine ();
		}
	}
}
