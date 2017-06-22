using System;
using System.Linq;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Distinction
{
	class MainClass
	{
		static int chips;
		static Deck deck;
		static List<Card> userHand;
		static List<Card> dealerHand;


		public static void Main (string[] args)
		{
			Random _rand = new Random ();
			Console.Title = "♣♠♥♦ BLACKJACK By Nicholas ♣♠♥♦";
			int rr = _rand.Next (0, dealerHand.Count);
			userHand.Add(dealerHand[rr]);
			dealerHand.Remove (dealerHand [rr]);

			chips = 1000;
			deck = new Deck ();
			deck.NewCards();
			deck.CardShuffle ();

			while (chips > 0) 
			{
				DealHand ();
				Console.WriteLine ("Press any key for next Game");
				ConsoleKeyInfo Input = Console.ReadKey (true);
			}
			Console.ReadLine ();
		}

		static void DealHand()
		{


			Console.WriteLine ("Balance: {0}", chips);
			Console.WriteLine ("Please Bet (1-{0}", chips);
			int BetReceive = Convert.ToInt32(Console.ReadLine ()) ;

			while (BetReceive < 1 || BetReceive > chips) 
			{
				Console.WriteLine("Invalid bet, TRY AGAIN!");
				BetReceive = Convert.ToInt32(Console.ReadLine ());
			}

			userHand = new List<Card> ();

			foreach (Card card in userHand)
			{
				if (card.CardNumber == CardNumber.Ace)
				{
					card.Value += 10;
					break;
				}
			}

			Console.WriteLine ("Player");
			Console.WriteLine ("Card 1: {0}, {1}", userHand [0].CardNumber, userHand [0].Suite);
			Console.WriteLine ("Card 1: {0}, {1}", userHand [1].CardNumber, userHand [1].Suite);
			Console.WriteLine ("Total: {0})", userHand [0].Value + userHand [1].Value);

			dealerHand = new List<Card> ();

			foreach (Card card in dealerHand)
			{
				if (card.CardNumber == CardNumber.Ace)
				{
					card.Value += 10;
					break;
				}
			}

			Console.WriteLine ("Dealer");
			Console.WriteLine ("Card 1: {0}, {1}", dealerHand [0].CardNumber, dealerHand [0].Suite);
			Console.WriteLine ("Card 1: {0}, {1}", dealerHand [1].CardNumber, dealerHand [1].Suite);
			Console.WriteLine ("Total: {0})", dealerHand [0].Value + dealerHand [1].Value);

			if (userHand [0].Value + userHand [1].Value == 21) 
			{
				chips += BetReceive;
			} 
			else if (userHand [0].Value + userHand [1].Value != 21) 
			{
				if ((userHand [0].Value + userHand [1].Value > dealerHand [0].Value + dealerHand [1].Value) & userHand [0].Value + userHand [1].Value <= 21) 
				{
					chips += BetReceive;
				} 
				else if (dealerHand [0].Value + dealerHand [1].Value <= 21) 
				{
					chips += BetReceive;
				}

				else
					chips -= BetReceive;
			}

		}
	}
}
