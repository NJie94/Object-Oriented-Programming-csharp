using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SwinGameSDK;

namespace MyGame
{
	public class Round
	{
		private List<Card> cards = new List<Card>(5);
		public event EventHandler Variable;
		public Round (bool Dealer = false)
		{
			this.TheDealer = Dealer;
		}

		public bool TheDealer
		{
			get;
			set;
		}

		public ReadOnlyCollection<Card> Cards
		{
			get { return this.cards.AsReadOnly();}
		}

		// reference http://stackoverflow.com/questions/14315437/get-best-matching-overload-from-set-of-overloads
		public int Calculation
		{
			get{ return this.cards.Select (cd => (int)cd.Number < 11 && (int)cd.Number > 1 ? (int)cd.Number : 10).Sum (); }

		}

		public int FinalValue
		{
			get
			{
				var finalvalue = this.Calculation;
				//Setting Ace value
				var Ace = this.cards.Count (cd => cd.Number == CardNumber.Ace);
			
				//Set variaty value for Ace
				while (finalvalue > 21 && Ace-- > 0)
				{
					finalvalue -= 9;

				}

				return finalvalue;
			}
		}

		public void AddCard (Card card)
		{
			this.cards.Add (card);
			if (this.Variable != null)
			{
				this.Variable (this, EventArgs.Empty);
			}
		}

		public void CardDeal()
		{
			this.cards.ForEach
			(
				card=>
					{
						if (!card.FacingUp)
						{
							card.flip();						
						}

					}
			);
		}

		public void ClearTable()
		{
			this.cards.Clear ();
		}

	}
}

