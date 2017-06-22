using System;

namespace HelloWorld
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Message myMessage;
			Message [] messages = new Message[4];
			string name;
			int n=0;

			myMessage = new Message ("Hello World\n");
			myMessage.Print ();


			messages [0] = new Message ("Hi Vincci");
			messages [1] = new Message ("Hi Lachlan");
			messages [2] = new Message ("Hi Dominic ");
			messages [3] = new Message ("Hi Nicholas");

			while (n < 6) {
				Console.WriteLine ("Enter Name:");

				name = Console.ReadLine ();

				//print the message if name is one of these 4,else prints "That is not a good name! Try Again. ^^"
				if (name.ToLower () == "vincci") {
					messages [0].Print ();
				} else if (name.ToLower () == "lachlan") {
					messages [1].Print ();
				} else if (name.ToLower () == "dominic") {
					messages [2].Print ();
				} else if (name.ToLower () == "nicholas") {
					messages [3].Print ();
				} else {
					Console.WriteLine ("That is not a good name! Try Again. ^^");
				}

				n++;
				Console.ReadLine ();
			}
		}
	}
}

