using System;
using System.Data.Common;

public class game
{
    //This class creates the map, places the Wizert, exit, monsters, and potions into their locations, and allows the Wizert to navigate the maze.

    public static bool Generate()
    {
        //The player character's health and magicka is created and set. (See Fight.cs for info)
        Wizert player = new Wizert(100, 200);

        // This variable allows the program to use Random generation to choose locations for the items.
        var rand = new Random();

        // Creates a Blank 2D Array that will soon be a map.
        int[,] map = new int[5, 5];
        int[,] hpMap = new int[5, 5];
        int[,] playerMap = new int[5, 5];

        // Coordinates are sorted from the top-left of the dungeon, so:
        // map[0, 0] = top-left corner
        // map[0, 4] = top-right corner
        // map[4, 0] = bottom-right corner
        // map[4, 4] = bottom-left corner.

        // Potions and monsters are assigned here. They are defined as follows: 
        // 0 = Blank Room
        // 1 = Health Potion
        // 2 = Magicka Potion
        // 3 = Goblin
        // 4 = Orc
        // 5 = Banshee

        map[0, 0] = 0;
        map[1, 0] = 1;
        map[2, 0] = 5;
        map[3, 0] = 4;
        map[4, 0] = 2;

        map[0, 1] = 3;
        map[1, 1] = 5;
        map[2, 1] = 3;
        map[3, 1] = 4;
        map[4, 1] = 3;

        map[0, 2] = 0;
        map[1, 2] = 4;
        map[2, 2] = 2;
        map[3, 2] = 0;
        map[4, 2] = 1;

        map[0, 3] = 5;
        map[1, 3] = 1;
        map[2, 3] = 0;
        map[3, 3] = 4;
        map[4, 3] = 5;

        map[0, 4] = 4;
        map[1, 4] = 3;
        map[2, 4] = 4;
        map[3, 4] = 3;
        map[4, 4] = 0;

        // A for loop is used to assign health values to each enemy via hpMap. Goblins have 3 HP, Orcs have 5 HP, and Banshees have 8 HP.
        int uBoundX = map.GetUpperBound(0);
        int uBoundY = map.GetUpperBound(1);

        for (int x = 0; x<= uBoundX; x++)
        {
            for (int y = 0; y<= uBoundY; y++)
            {
                if (map[x, y] == 3)
                {
                    hpMap[x, y] = 3;
                }
                else if (map[x, y] == 4)
                {
                    hpMap[x, y] = 5;
                }
                else if (map[x, y] == 5)
                {
                    hpMap[x, y] = 8;
                }
                else
                {
                    hpMap[x, y] = 0;
                }
            }
        }


        // Chooses the Wizert's starting Location
        int wizertX = rand.Next(0, 5);
        int wizertY = rand.Next(0, 5);
        
        var pWizertX = wizertX;
        var pWizertY = wizertX;

        // Creates an Exit. To avoid the Wizert starting at the Exit, the program generates another location if they share the same space.

        int exitX = rand.Next(0, 5);
        int exitY = rand.Next(0, 5);

        while (exitX == wizertX && exitY == wizertY)
        {
            exitX = rand.Next(0, 5);
            exitY = rand.Next(0, 5);
        }
        // Clears the room at the exit and Wizert's starting location.
        map[wizertX, wizertY] = 0;
        map[exitX, exitY] = 0;


        //This is the intro text to explain the basic plot. 
        Console.WriteLine("You open your eyes to find yourself in a dungeon. Use your magic and your wits to find the exit!\nUse the number keys to input commands.\nPress any button to start.");
        var start = Console.ReadKey(true).Key;

        bool defeat = false;
        
        // Navigation Starts Here. While the wizert hasn't reached the exit nor has been defeated by a monster, the game will go on.
        while ((exitX != wizertX || exitY != wizertY) || defeat != true)
        {
            // This bool confirms when a direction has been chosen. Until that direction has been chosen, the loop will continue.
            bool valid = false;
            while (valid == false)
            {
                string location = Descriptions.Description(wizertX, wizertY);
                //The player is described the room they're in. They are then prompted for a direction.
                Console.WriteLine($"\n{location} Press...\n");

            // All directions are initially set as false. These will change depending on Wizert's location.
            bool north = false;
            bool east = false;
            bool south = false;
            bool west = false;

            
            // The game checks if the Wizert is at an edge of the map. Depending on which edge they're next to, directions will be set to true or false accordingly.
            if (wizertY != 0)
            {
                north = true;
                Console.WriteLine("1. Go North");
            }
            
            if (wizertX != 4)
            {
                east = true;
                Console.WriteLine("2. Go East");
            }
            if (wizertY != 4)
            {
                south = true;
                Console.WriteLine("3. Go South");
            }
            if (wizertX != 0)
            {
                west = true;
                Console.WriteLine("4. Go West");
            }

            
                //Player's input.
                Console.WriteLine(" ");
                var a = Console.ReadKey(false).Key;
                Console.WriteLine(" \n");

                // Depending on which key is press above, the Wizert will move in a direction or be reprompted to choose again.
                if ((a == ConsoleKey.NumPad1 || a == ConsoleKey.D1) && (north == true))
                {
                    wizertY--;
                    valid = true;

                }

                else if ((a == ConsoleKey.NumPad2 || a == ConsoleKey.D2) && (east == true))
                {
                    wizertX++;
                    valid = true;
                }
                else if ((a == ConsoleKey.NumPad3 || a == ConsoleKey.D3) && (south == true))
                {
                    wizertY++;
                    valid = true;
                }
                else if ((a == ConsoleKey.NumPad4 || a == ConsoleKey.D4) && (west == true))
                {
                    wizertX--;
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid Option.\n");

                }
            }
            // Now that the Wizert has moved, their location is compared to the map.

            // Blank Room: Wizert's run location is set.
            if (map[wizertX, wizertY] == 0)
            {
                
                pWizertX = wizertX;
                pWizertY = wizertY;
            }
            // Health Potion: Wizert drinks a health potion and gains 10 HP. Wizert's previous room location is set.
            if (map[wizertX, wizertY] == 1)
            {
                
                Console.WriteLine("You found a Health Potion!\nYou gained 10 HP.\n");
                player.drinkHealth();
                

                map[wizertX, wizertY] = 10;
                pWizertX = wizertX;
                pWizertY = wizertY;
            }
            // Empty Health Potion: The empty potion that the Wizert drank sits on the ground. Treated as a blank room.
            else if (map[wizertX, wizertY] == 10)
            {
                
                Console.WriteLine("An empty Health Potion sits on the ground.");
                pWizertX = wizertX;
                pWizertY = wizertY;
            }
            // Magicka Potion: Wizert drinks a magicka potion and gains 20 MP. Wizert's previous room location is set.
            if (map[wizertX, wizertY] == 2)
            {
                
                Console.WriteLine("You found a Magicka Potion!\nYou gained 20MP.");
                player.drinkMagicka();

                map[wizertX, wizertY] = 20;
                pWizertX = wizertX;
                pWizertY = wizertY;
            }
            // Empty Magicka Potion: The empty potion that the Wizert drank sits on the ground. Treated as a blank room.
            else if (map[wizertX, wizertY] == 20)
            {
                
                Console.WriteLine("An empty Magicka Potion sits on the ground.");
                pWizertX = wizertX;
                pWizertY = wizertY;
            }
            // Goblin: Wizert runs into a goblin. If they lose, defeat is true and the game ends. If they win, they room is cleared. If they run, their coordinates are set to the previous room.
            if (map[wizertX, wizertY] == 3)
            {
                
                int result = Wizert.Encounter(1, player, hpMap[wizertX, wizertY]);
                if (result == 10)
                {
                    defeat = true;
                    break;
                }
                if (result == 20)
                {
                    map[wizertX, wizertY] = 30;
                    pWizertX = wizertX;
                    pWizertY = wizertY;
                }
                else
                {
                    hpMap[wizertX, wizertY] = result;
                    wizertX = pWizertX;
                    wizertY = pWizertY;
                }
            }
            // Defeated Goblin: The goblin that Wizert defeated lays on the ground. Treated as a blank room.
            else if (map[wizertX, wizertY] == 30)
            {
                
                Console.WriteLine("The defeated goblin lays on the ground.");
                pWizertX = wizertX;
                pWizertY = wizertY;
            }
            // Orc: Wizert runs into an orc. If they lose, defeat is true and the game ends. If they win, they room is cleared. If they run, their coordinates are set to the previous room.
            if (map[wizertX, wizertY] == 4)
            {
                
                int result = Wizert.Encounter(2, player, hpMap[wizertX, wizertY]);
                if (result == 10)
                {
                    defeat = true;
                    break;
                }
                if (result == 20)
                {
                    map[wizertX, wizertY] = 40;
                    pWizertX = wizertX;
                    pWizertY = wizertY;
                }
                else
                {
                    hpMap[wizertX, wizertY] = result;
                    wizertX = pWizertX;
                    wizertY = pWizertY;
                }
            }
            // Defeated Orc: The orc that Wizert defeated lays on the ground. Treated as a blank room.
            else if (map[wizertX, wizertY] == 40)
            {
               
                Console.WriteLine("The defeated orc lays on the ground.");
                pWizertX = wizertX;
                pWizertY = wizertY;
            }
            // Banshee: Wizert runs into a banshee. If they lose, defeat is true and the game ends. If they win, they room is cleared. If they run, their coordinates are set to the previous room.
            if (map[wizertX, wizertY] == 5)
            {
                int result = Wizert.Encounter(3, player, hpMap[wizertX, wizertY]);
                if (result == 10)
                {
                    defeat = true;
                    break;
                }
                if (result == 20)
                {  
                    map[wizertX, wizertY] = 50;
                    pWizertX = wizertX;
                    pWizertY = wizertY;
                }
                else
                {
                    hpMap[wizertX, wizertY] = result;
                    wizertX = pWizertX;
                    wizertY = pWizertY;
                }
            }
            // Defeated Banshee: The banshee that Wizert defeated lays on the ground. Treated as a blank room.
            else if (map[wizertX, wizertY] == 50)
            {
                Console.WriteLine("The defeated banshee lays on the ground.");
                pWizertX = wizertX;
                pWizertY = wizertY;
            }

        }

        //If the player finds the exit and wasn't defeated by the monsters, then the program will return true. Otherwise, it will return false.
        if (defeat == false)
        {
            return true;
        }
        else { return false; }
        


    }
}






