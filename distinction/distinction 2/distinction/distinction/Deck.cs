using System;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Distinction
{
	public class Deck 
	{
		private readonly List<Card> Cards = new List<Card>(52);
		public Deck ()
		{
			this.NewCards ();
		}
		public void NewCards()
		{
			this.Cards.Clear ();
			// Generates a sequence of integral numbers within a specified range.In this case we want 13 card with 4 suite
			this.Cards.AddRange (
				Enumerable.Range (1, 4).SelectMany (s => Enumerable.Range (1, 13).Select (n=> new Card((CardNumber) n, (Suite) s)))
			);
			Card card1 = new Card (1, "club");

		}

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

		public void printCard()
		{
		
			for (int i= 0; i< Cards.Count;i++) 
			{
				Card cards = Cards[i];
				Console.WriteLine ("Card {0}:{1} {2}.Value : {3}", i+1, cards.CardNumber, cards.Suite, cards.Value);  
				i++;
			}
		}
	}
}

