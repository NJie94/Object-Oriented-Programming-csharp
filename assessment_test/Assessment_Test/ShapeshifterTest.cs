using NUnit.Framework;
using System;

namespace Assessment_Test
{
	[TestFixture ()]
	public class ShapeShifterTest
	{

		[Test ()]
		public void TestNotAttachedByDefault ()
		{
			Shapeshifter mystique = new Shapeshifter ();
			Wolf wolf = new Wolf ();
			Assert.IsFalse (mystique.Melded);
			mystique.Call (); //Should print Hi There

		}

		[Test ()]
		public void TestCanBeAttached ()
		{
			Shapeshifter mystique = new Shapeshifter ();
			Wolf wolf = new Wolf ();
			mystique.Meld (wolf);
			Assert.IsTrue (mystique.Melded);
			mystique.Call (); //Should print Hi There
		}

		[Test()]
		public void TestCanBeDeployed()
		{
			Shapeshifter mystique = new Shapeshifter ();
			Wolf wolf = new Wolf ();
			Dragon dragon = new Dragon ();

			mystique.Meld (wolf);

			mystique.Shift (true);
			mystique.Call ();//Should Print Sonaring
			mystique.Meld (dragon);
			mystique.Shift (true);
			mystique.Call ();//Should Print Shooting
			mystique.Call ();
			mystique.Call ();
			mystique.Call ();
			mystique.Shift (false);
			mystique.Call ();//Should Print Hi There
		}

		[Test()]
		public void TestCanRememberGagetAttached()
		{
			Shapeshifter mystique = new Shapeshifter ();
			Wolf wolf = new Wolf ();
			Dragon dragon = new Dragon ();
			mystique.Meld (dragon);
			mystique.Meld (wolf);
			mystique.MeldedEntity ();
		}
	}
}

