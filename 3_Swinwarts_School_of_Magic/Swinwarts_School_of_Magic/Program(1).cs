using System;
using System.Collections.Generic;
using System.IO;

namespace Swinwarts_School_of_Magic
{

	public static class ExtensionMethods
	{
		public static int ReadInteger(this StreamReader reader)
		{
			return Convert.ToInt32 (reader.ReadLine ());
		}
	}

	class MainClass
	{

		/// <summary>
		/// Programs the initialise and print instructions
		/// </summary>
		/// <param name="spellbook">spell in the list of spell </param>
		private static void ProgramInitialise(Spell[] spellbook)
		{
			PrintAllSpellNames (spellbook);
			Console.WriteLine ("6. Cast All\n");
			Console.WriteLine ("s. To Save All Spells That were cast\n");
			Console.WriteLine ("l. To Load\n");
			Console.WriteLine ("q. To Quit\n");
			Console.WriteLine ("c. To Clear Screen\n");
			Console.WriteLine ("Please Enter your spell\n1,2,3,4,5,6,s,l,q\n");

		}

		/// <summary>
		/// Prints all spell names.
		/// </summary>
		/// <param name="Spells">Spells in the spellbook to print into screen </param>
		private static void PrintAllSpellNames(Spell[] Spells)
		{
			foreach (Spell spell in Spells)
			{
				Console.WriteLine ("{0}\n",spell.Name);
			}
		}

		/// <summary>
		/// Casts all spells.
		/// </summary>
		/// <param name="spellBook">all the spells in the spellbook to cast </param>
		private static void CastAllSpells(Spell[] spellBook,object Object)
		{
			foreach (Spell spell in spellBook)
			{
				Console.WriteLine (spell.Cast (Object)); 				
			}
		}

		private static object CastOnObject(string Object)
		{
			object objects = null;
			switch (Object)
			{
			case "cat":
				objects = new Cat ();
				break;
			case "house":
				objects = new House ();
				break;
			default:
				break;
			}
			return objects;
		}
			
		public static void Main ()
		{
		
			Spell.RegisterSpell ("Invisibility", typeof(Invisibility));
			Spell.RegisterSpell ("Heal", typeof(Heal));
			Spell.RegisterSpell ("Teleport", typeof(Teleport));

			SpellBook myspellbook = new SpellBook ();	//all available spells in a spellbook
			SpellBook saveAllCastedSpell = new SpellBook (); //spells that were cast and to save

			string choice;
			string Continue;
			Spell s;
			string ObjectString;
			object objects = new object ();
			//Adding available spells into spellbook
			myspellbook.AddSpells (new Teleport ("1. Mitch's mighty mover <Teleport>"));
			myspellbook.AddSpells (new Heal ("2. Paul's potent poultice <Heal>"));
			myspellbook.AddSpells (new Invisibility ("3. David's dashing disapperance <Invisibility>"));
			myspellbook.AddSpells (new Teleport ("4. Stan's stunning shifter <Teleport>"));
			myspellbook.AddSpells (new Heal ("5. Lachlan's lavish longevity <Heal>"));

			//to convert list to an array because PrintSpellNamesspellname and PrintSpellNames take in parameter of an array , not list
			Spell[] spellbook =myspellbook.Spells.ToArray();

			ProgramInitialise (spellbook);

			do {
					choice = Console.ReadLine ();
					switch (choice) 
					{
						case "1":
							s=myspellbook[0];
							Console.WriteLine("Choose between cat and house\n");
							ObjectString=Console.ReadLine();
							objects=CastOnObject(ObjectString.ToLower());
							Console.WriteLine(s.Cast(objects));
							saveAllCastedSpell.AddSpells(s);
							break;
						case "2":
							s=myspellbook[1];
							Console.WriteLine("Choose between cat and house\n");
							ObjectString=Console.ReadLine();
							objects=CastOnObject(ObjectString.ToLower());
							Console.WriteLine(s.Cast(objects));
							saveAllCastedSpell.AddSpells(s);
							break;
						case "3":
							s=myspellbook[2];
							Console.WriteLine("Choose between cat and house\n");
							ObjectString=Console.ReadLine();
							objects=CastOnObject(ObjectString.ToLower());
							Console.WriteLine(s.Cast(objects));
							saveAllCastedSpell.AddSpells(s);
							break;
						case "4":
							s=myspellbook[3];
							Console.WriteLine("Choose between cat and house\n");
							ObjectString=Console.ReadLine();
							objects=CastOnObject(ObjectString.ToLower());
							Console.WriteLine(s.Cast(objects));
							saveAllCastedSpell.AddSpells(s);
							break;
						case "5":
							s=myspellbook[4];
							Console.WriteLine("Choose between cat and house\n");
							ObjectString=Console.ReadLine();
							objects=CastOnObject(ObjectString.ToLower());
							Console.WriteLine(s.Cast(objects));
							saveAllCastedSpell.AddSpells(s);
							break;
						case "6":
							Console.WriteLine("Choose between cat and house\n");
							ObjectString=Console.ReadLine();
							objects=CastOnObject(ObjectString.ToLower());
							CastAllSpells(spellbook,objects);
							foreach (Spell spell in spellbook)
								saveAllCastedSpell.AddSpells(spell);
							break;
						case "s":
							saveAllCastedSpell.Save("Spell.txt");
							break;
						case "c":
							Console.Clear ();
							ProgramInitialise (spellbook);
							break;
						case "l":
							try
							{
								saveAllCastedSpell.Load ("Spell.txt");
							}
							catch(Exception e)
							{
								Console.Error.WriteLine ("Error loading file:{0}", e.Message);
							}
							break;
						case "q":
							System.Environment.Exit(1);
							break;
						default:
							Console.WriteLine ("Error , please try again");
							break;
					}
					
					do {
					Console.WriteLine ("Do you want to continue? Yes or No \n");
					Continue = Console.ReadLine ();
					} while(Continue.ToLower () != "yes" && Continue.ToLower () != "no" && Continue.ToLower () != "y" && Continue.ToLower () != "n");
					
				} while(Continue.ToLower () == "yes" || Continue.ToLower () == "y");
			Console.WriteLine ("See you again!!");
			Console.ReadKey();
		}
	}
}
