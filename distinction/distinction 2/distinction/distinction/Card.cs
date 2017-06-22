using System;

namespace Distinction
{
	public class Card
	{
		public Suite Suite { get; private set;}
		public CardNumber CardNumber { get; private set;}
		public int Value { get; set;}

		public Card (CardNumber number, Suite suite)
		{
		}

	}
}

