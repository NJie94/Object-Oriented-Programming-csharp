using System;

namespace MyGame
{
	public class GamePlay
	{
		public Status lastState;
		public Control allowedActions;
		public CardDeck NewCard;


		public event EventHandler LastStateChanged;
		public event EventHandler AllowedActionsChanged;

		public GamePlay ()
		{
			this.Player = new Player ();
			this.Dealer = new DealerBase ();
			this.LastState = Status.NULL;
			this.AllowedActions	= Control.NULL;
		}
		public Player Player { get; set; }

		public DealerBase Dealer { get; set; }

		public Control AllowedActions
		{
			get
			{
				return this.allowedActions;
			}

			set
			{
				if (this.AllowedActions != value)
				{
					this.AllowedActions = value;
				}
			}
		}

		public Status LastState
		{
			get{ return this.lastState;}
			set
			{ 
				if (this.lastState != value)
				{
					this.lastState = value;
				}
			}
		}

		public void PlayGame (float bet, float balance)
		{
			this.Player.Bet = bet;
			this.Player.Balance = balance;
			this.AllowedActions = Control.Deal;
		}

		public void Deal()
		{
			if (this.NewCard == null)
			{
				this.NewCard = new CardDeck ();
			}
			else
			{
				this.NewCard.Deck ();
			}

			this.NewCard.CardShuffle ();
			this.Player.Round.ClearTable ();
			this.Dealer.Round.ClearTable ();

			this.NewCard.Deal (this.Dealer.Round);
			this.NewCard.Deal (this.Player.Round);

			if (this.Player.Round.Calculation == 21)
			{
				this.Dealer.Round.CardDeal ();
				if (this.Dealer.Round.Calculation == 21)
				{
					this.LastState = Status.Draw;
				}
				else
				{
					this.Player.Balance += this.Player.Bet;
					this.LastState = Status.PlayerWon;
				}
					
				this.AllowedActions = Control.Deal;
			}
			else if (this.Dealer.Round.FinalValue == 21)
			{
				this.Dealer.Round.CardDeal ();
				this.Player.Balance -= this.Player.Bet;
				this.LastState = Status.DealerWon;
				this.AllowedActions = Control.Deal;

			}
			else
			{
				this.AllowedActions = Control.Hold | Control.Hit;
			}
		}

		public void Hold()
		{
			this.Dealer.Round.CardDeal();
			while (this.Dealer.Round.Calculation < 17)
			{
				this.NewCard.GiveMoreCard(this.Dealer.Round);
			}

			if (this.Dealer.Round.FinalValue > 21 || this.Player.Round.FinalValue > this.Dealer.Round.FinalValue)
			{
				this.Player.Balance += this.Player.Bet;
				this.LastState = Status.PlayerWon;
			}
			else if (this.Dealer.Round.FinalValue == this.Player.Round.FinalValue)
			{
				this.LastState = Status.Draw;
			}
			else
			{
				this.Player.Balance -= this.Player.Bet;
				this.LastState = Status.DealerWon;
			}

			this.AllowedActions = Control.Deal;
		}

		public void Hit()
		{
			this.NewCard.GiveMoreCard (this.Player.Round);

			if (this.Player.Round.FinalValue > 21)
			{
				this.Dealer.Round.CardDeal ();
				this.Player.Balance -= this.Player.Bet;
				this.LastState = Status.DealerWon;
				this.AllowedActions = Control.Deal;

			}
		}



	}
}

