using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
	public class Player : BasePlayerClass
	{
		private float bet;
		private float balance;

		public Player ()
		{
			this.Round = new Round (Dealer:false);
		}

		public event EventHandler UpdatedBalance; //Event handler handle event with no data in it

		public float Balance
		{
			get
			{
				return this.balance;
			}
			set
			{
				if (this.balance != value)
				{
					this.balance = value;

					//if updated balance is nothing then assign an event value with no data in it
					if (UpdatedBalance != null)
					{
						this.UpdatedBalance (this, EventArgs.Empty);
					}
				}
			}
		}

		// Betting system
		public float Bet
		{
			get
			{
				return this.bet;
			}

			set
			{
				if (this.bet == value)
				{
				}

				if (value > this.bet + this.balance && this.balance > 0)
				{
					this.bet += this.balance;
					this.balance = 0;
				}
				else if (value<= this.bet + this.balance && value >= 0)
				{
					var temp = this.bet+this.balance;
					this.bet = value;
					this.balance = temp - value;
				}

			}
		}

		public void OnBalanceChanged(object Changer, EventArgs ent)
		{
			var player = (Player)Changer;
			string l = string.Format ("Bet:{0} |♠| Balance: {1}", player.Bet, player.Balance).PadRight(60);
			Console.WriteLine (l);
		}

		public void OnLastStateChanged (object Changer, EventArgs ent)
		{
			var play = (GamePlay)Changer;
			Console.ForegroundColor = ConsoleColor.Blue;

			if(play.LastState == Status.DealerWon)
			{
				Console.WriteLine (("Dealer Won!"));
			}

			else if(play.LastState == Status.PlayerWon)
			{
				Console.WriteLine (("Player Won!"));
			}

			Console.ResetColor ();
		}

		public void OnAllowedActionsChanged(object Changer, EventArgs ent)
		{
			var play = (GamePlay)Changer;
			StringBuilder sb = new StringBuilder (); //string builder are more managerable than string

			if ((Control.Deal & play.AllowedActions) == Control.Deal)
			{
				sb.Append ("DEAL (Press Enter)");
			}
			if ((Control.Hit & play.AllowedActions) == Control.Hit)
			{
				sb.Append ("HIT (Press SpaceBar )");
			}
			if ((Control.Hold & play.AllowedActions) == Control.Hold)
			{
				sb.Append ("HOLD (Press Enter)");
			}
			Console.WriteLine (sb.ToString ());
		}

		public void OnHandChanged (object Changer, EventArgs ent)
		{
			var round = (Round)Changer;
			var name = round.TheDealer ? "DEALER" : "PLAYER";
			var value = round.TheDealer ? round.Calculation : round.FinalValue;

			Console.WriteLine ("{0}'s HOLD {1}", name, value);

		}
	}
}

