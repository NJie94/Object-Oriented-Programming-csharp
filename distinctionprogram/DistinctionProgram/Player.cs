using System;

namespace DistinctionProgram
{
	public class Player
	{
		private string _name;
		private int _position;
		private Die _die;


		public Player(string name){
			_name = name;
			_position = 1;
			_die = new Die ();
		}

		public int RollDie(){
			_die.Roll ();
			return _die.DieNumber;
		}


		public int Move(int steps){
			_position += steps;	
			if (_position <= 1)
				_position = 1;
			return _position;
		}

		public void ReturnToFirstBox()
		{
			_position = 1;
		}
			

		public string Name {
			get {
				return _name;
			}
		}

		public int CurrentPosition {
			get {
				return _position;
			}
			set{
				_position = value;
			}
		}

	
		public Die Die {
			get {
				return _die;
			}
		}
	}
}

