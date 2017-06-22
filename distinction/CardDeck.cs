using System;
using System.Linq;
using System.Security.Cryptography;
using SwinGameSDK;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace MyGame
{
	public class CardDeck
	{
		private readonly List<Card> Cards = new List<Card>(52);

		public CardDeck ()
		{
			this.Deck ();
		}

		//Generate a deck of 52 cards
		public void Deck()
		{

			this.Cards.Clear ();
			// Generates a sequence of integral numbers within a specified range.In this case we want 13 card with 4 suite
			this.Cards.AddRange (
				Enumerable.Range (1, 4).SelectMany (s => Enumerable.Range (1, 13).Select (n=> new Card((CardNumber) n, (CardSuite) s)))
			);
		}

		//Shuffle cards

		public void CardShuffle()
		{
			//Generate random number range or i to cards.count 
			var i = this.Cards.Count;

			// Fills an array of bytes with a cryptographically strong sequence of random values.
			var RNG = new RNGCryptoServiceProvider ();

			while (i > 1)
			{
				var buffer = new byte[8];
				RNG.GetBytes (buffer);
				//Returns a 64-bit unsigned integer converted from eight bytes at a specified position in a byte array.
				var k = (int)(BitConverter.ToUInt64 (buffer, 0) % (ulong)this.Cards.Count);

				//Swap card
				i--;
				var temp = this.Cards [k];
				this.Cards [k] = this.Cards [i];
				this.Cards [i] = temp;
			}
		}

		//Or using another suffling method
		/*	public void CardShuffle()
		 * 		static Random i = new Random();
		 *	 	for(int n = this.deck.length - 1; n> 0; --n)
		 *			{
		 *				int k = i.Next(n+1);
		 *				int temp = deck[n];
		 *				deck[n] = deck[k];
		 *				deck[k] = temp;
		 *			}
		 *
		*/

		internal ReadOnlyCollection<Card> cards
		{
			get 
			{ return this.Cards.AsReadOnly ();}
		}

		public void Deal(Round round)
		{
			if (this.cards.Count < 2)
			{
				throw new System.InvalidOperationException ();
			}

			var card = this.cards.First ();
			round.AddCard (card);
			this.Cards.Remove(card);

			card = this.cards.First ();

			if (round.TheDealer)
			{
				card.flip ();
			}

			round.AddCard (card);
			this.Cards.Remove (card);
		}

		public void GiveMoreCard(Round round)
		{
			if (this.cards.Count < 1)
			{
				throw new System.InvalidOperationException ();
			}

			round.AddCard (this.cards.First ());
			this.Cards.RemoveAt (0);
		}
	}
}

