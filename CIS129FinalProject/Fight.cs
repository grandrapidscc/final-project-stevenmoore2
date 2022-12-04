using System;
using System.Data.Common;

//This is the battle side of the program.
public class Wizert
{
	private int _hp;
	private int _mp;

	// This method creates the player character, Wizert.
	public Wizert(int hp, int mp)
	{
		_hp = hp;
		_mp = mp;
	}

	// Skill 1 is Fireball. Deals 3 damage to a foe at the cost of 3 Magicka. Damage is done in the Encounter Method. 
	public bool Fireball()
	{
        // If the player lacks the necessary Magicka, the program will let them know they're out of MP and need to choose something else.
        if (_mp < 3)
		{
            Console.WriteLine("Not enough MP!");
			return false;
		}
		else
		{
			Console.WriteLine("Wizert flings a fireball!");
			_mp = _mp - 3;
			return true;
		}
	}
	// Skill 2 is Heal. Wizert heals 5 hp at the cost of 5 Magicka. 
	public bool Heal()
	{
		if (_mp < 5)
		{
        // If the player lacks the necessary Magicka, the program will let them know they're out of MP and need to choose something else.
            Console.WriteLine("Not enough MP!");
			return false;
		}
		else
		{
			Console.WriteLine("Wizert heals 5 HP!");

			_mp = _mp - 5;
			_hp = _hp + 5;
			return true;
		}
	}
    // Skill 3 is Run Away. The Wizert tries to run away from a battle.
	// The Wizert has a 3 in 4 chance to run. If the Wizert rolls a 1, they fail to flee. 
    public bool RunAway()
	{
		var rand = new Random();
		
		var runaway = rand.Next(1, 5);
		if (runaway == 1)
		{
			Console.WriteLine("Wizert tries to run... but fails.");
			return false;
		}
		else
		{
			return true;
		}
	}
	//When Wizert finds a health potion, they will gain 10 HP.
	public void drinkHealth()
	{
		_hp = _hp + 10;
        Console.WriteLine($"HP: {_hp} MP: {_mp}");
    }
	//When Wizert finds a Magicka potion, they will gain 20MP.
    public void drinkMagicka()
    {
        _mp = _mp + 20;
        Console.WriteLine($"HP: {_hp} MP: {_mp}");
    }
    //This method consists of how much damage the Wizert takes from monster attacks. After being hit, their health and MP are shown.
    public void TakeDamage(int monster)
	{
		// Goblin Bodyslam damage (2 HP lost)
		if (monster == 1)
		{
			Console.WriteLine("The goblin slams its body into Wizert!\nWizert takes 2 damage.");
			_hp = (_hp - 2);
		}
        // Orc Cleave damage (3 HP lost)
        if (monster == 2)
		{
			Console.WriteLine("The Orc strikes Wizert with his axe!\nWizert takes 3 damage.");
			_hp = (_hp - 3);
		}
        // Banshee Screech damage (5 HP lost)
        if (monster == 3)
		{
			Console.WriteLine("The Banshee screeches at Wizert!\nWizert takes 5 HP damage.");
			_hp = (_hp - 5);
		}

	}

	//Whenever the player runs into a monster on the map, a battle will start.
	public static int Encounter(int monster, Wizert wizert, int monHP)
	{
		string monsterName = "";
		//Using the value from the map, the monster's name is assigned. 
		if (monster == 1)
		{
			monsterName = "Goblin";
		}
        if (monster == 2)
		{
            monsterName = "Orc";
        }
		if (monster == 3)
		{
            monsterName = "Banshee";
        }
		//Once assigned, the name and health of the monster will be displayed to the player.
        Console.WriteLine($"A {monsterName} appears! It has {monHP} HP.");
		
		//With that, the encounter begins! As long as the player lives, the monster lives and the player hasn't escaped the battle, 
		//the fight will go on until one of those conditions are no longer met. 
        bool escape = false;
		while (monHP > 0 && wizert._hp > 0 && escape == false)
		{
			//The player is prompted their health and magicka. They are then asked if they want to use any of their skills. 
            Console.WriteLine($"\nHP:{wizert._hp} MP:{wizert._mp}\n");
            Console.WriteLine("What will Wizert do? Press...\n1.Cast Fireball (3MP, 3 Damage) \n2.Cast Heal (5MP, heal 5HP) \n3.Attempt to Flee\n");
			
			//To avoid the player losing turns from a bad input, the program will not continue until a proper input is used. 
			bool turn = false;
			while (turn != true)
			{
				//Player input is read here.
				var a = Console.ReadKey(false).Key;
				Console.WriteLine(" \n");

				//If the player presses 1, they use the fireball spell. The damage to the monster is done here. 
				if ((a == ConsoleKey.NumPad1 || a == ConsoleKey.D1))
				{
					bool f = wizert.Fireball();
					if (f)
					{
						monHP = monHP - 3;
                        turn = true;
						Console.WriteLine($"The {monsterName} took 3 damage!");
						if (monHP > 0)
						{
							Console.WriteLine($"The {monsterName} now has {monHP} HP.");
						}
                    }
				}
				//If the player presses 2, they use the heal spell.
				else if (a == ConsoleKey.NumPad2 || a == ConsoleKey.D2)
				{
					bool h = wizert.Heal();
					if (h)
					{
						turn = true;
					}
				//If the player presses 3, they attempt to run away from the monster.
				}
				else if (a == ConsoleKey.NumPad3 || a == ConsoleKey.D3)
				{
					escape = wizert.RunAway();
					turn = true;
				}
				//If the player input something that isn't any of the commands above, they will be told to try again.
				else
				{
					Console.WriteLine("Invalid command. Press...\n1.Cast Fireball \n2.Cast Heal \n3.Attempt to Flee\n");
				}
			}
			//If the monster is still alive and the player has either failed to or did not escape, the monster deals damage to the
			//Wizert.
			if (monHP > 0 && escape == false)
			{
				wizert.TakeDamage(monster);
			}
		}
		//If the wizert's health reaches zero, its game over.
		if (wizert._hp <= 0)
		{
			Console.WriteLine("Wizert has been defeated...\n");

			return 10;
		}
		//If the player sucessfully escapes, they will be told that they did. 
		if (escape == true)
		{
            Console.WriteLine("Wizert tries to run... and succeeds!");
			return monHP;
        }
		else
		//If the player managed to slay the monster, they will be removed from the map.
		{
			Console.WriteLine($"The {monsterName} has been defeated!");
			return 20;
		}
	}
}