using System;
using System.Collections.Generic;
using System.IO;

namespace Swinwarts_School_of_Magic
{
	public class Teleport:Spell
	{
		private static Random _random= new Random();
		private double chanceToCast;

		/// <summary>
		/// Initializes a new instance of the <see cref="Swinwarts_School_of_Magic.Teleport"/> class.
		/// </summary>
		public Teleport ()
		{
			chanceToCast = _random.NextDouble ();
		}

		public Teleport (String Name)
		{
			_name = Name;
		}

		/// <summary>
		/// Gets or sets the probability.
		/// </summary>
		/// <value>The probability of the spells in succeeding or failing </value>
		public double Probability 
		{
			get 
			{
				return chanceToCast;
			}
			set {
				chanceToCast = value;
			}
		}

		/// <summary>
		/// Cast this spell, causing it to have an effect
		/// on its surroundings.
		/// </summary>
		/// <returns>description of the effect</returns>
		public override string Cast()
		{
			if (chanceToCast <= 0.5) {
				chanceToCast = _random.NextDouble ();
				return "Poof...you appear somewhere else";
			} else {
				chanceToCast = _random.NextDouble ();
				return "arrr....I'm too tired to move";
			}
		}
		/// <summary>
		/// Cast this spell, causing it to have an effect
		/// on its surroundings.
		/// </summary>
		/// <returns>description of the effect</returns>
		/// <param name="target">the object which is either cat, house etc</param>
		public override string Cast(object target)
		{
			{
				if(target is Transportable)
				{
					if (chanceToCast <= 0.5) {
						Transportable tgt;
						tgt = (Transportable)target;
						chanceToCast = _random.NextDouble ();
						return tgt.MakeTransport ();
					} else {
						chanceToCast = _random.NextDouble ();
						return "Sorry,Today is Not Your Day";
					}
				}
				else
				{
					chanceToCast = _random.NextDouble ();
					return "Nothing ... the object is still there!";
				}
			}
		}
			
	}
}

