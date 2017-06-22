using System;
using System.Text;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	public class Card
	{
		public Card (CardNumber number, CardSuite suite)
		{
			this.Suite = suite;
			this.Number = number;
			this.FacingUp = true;
		}

		public CardSuite Suite
		{
			get;
			set;
		}

		public CardNumber Number
		{
			get;
			set;
		}

		public bool FacingUp
		{
			get;
			set;
		}

		//Flip card if its not upward 
		public void flip()
		{
			this.FacingUp = !this.FacingUp;
		}

		public override string ToString()
		{
			char suite = '#';


			switch (this.Suite)
			{
			case CardSuite.Club:
				suite = '♣';
				break;
			case CardSuite.Diamond:
				suite = '♦';
				break;
			case CardSuite.Heart:
				suite = '♥';
				break;
			case CardSuite.Spades:
				suite = '♠';
				break;
			}
			var num = (int)this.Number > 1 && (int)this.Number < 11 ?
				((int)this.Number).ToString() :
				Enum.GetName(typeof(CardNumber), this.Number).Substring(0, 1);

			return num + " " + Suite;
		}
				
	}
}

