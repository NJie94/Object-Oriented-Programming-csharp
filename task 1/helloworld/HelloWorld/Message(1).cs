using System;

namespace HelloWorld
{
	public class Message
	{
		private string text;

		/// <summary>
		/// Initializes a new instance Message class.
		/// </summary>
		/// <param name="txt">Text.</param>
		public Message (string txt)
		{
			text = txt;
		}

		/// <summary>
		/// Print the Message Passed into The Message Class
		/// </summary>
		public void Print()
		{
			Console.WriteLine (text);
		}
	}
}

