using System;

namespace DistinctionProgram
{
	public class Die
	{
		private static int[] _dieState={1,2,3,4,5,6};
		private Random _random=new Random();
		private int _dieNumber;

		/// <summary>
		/// Initializes a new instance of the die class
		/// </summary>
		public Die ()
		{
			_dieNumber = _dieState [0];
		}

		/// <summary>
		/// Roll the die and return value 1-6
		/// </summary>
		public void Roll()
		{
			_dieNumber = _dieState [_random.Next (0,6)];
		}

		/// <summary>
		/// Gets the die number.
		/// </summary>
		/// <value>The die number.</value>
		public int DieNumber {
			get {
				return _dieNumber;
			}
		}
	}
}

