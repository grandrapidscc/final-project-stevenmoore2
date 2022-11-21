using System;
using System.Data.Common;

public class game
{

    //BUGFIX: Generate isn't displaying the navigation commands. Will reconsider class structure to remedy this issue.

    //This class creates the map, places the Wizert, exit, monsters, and potions into their locations, and allows the Wizert to navigate the maze.
    
    public static bool Generate()
    {
        // This variable allows the program to use Random generation to choose locations for the items.
        var rand = new Random();

        // Creates a Blank 2D Array that will soon be a map.
        int[,] map = new int[5, 5];


        // Chooses the Wizert's starting Location
        var Wizert = map[rand.Next(1, 5), rand.Next(1, 5)];

        // Creates an Exit. To avoid the Wizert starting at the Exit, the program generates another location if they share the same space.
        var Exit = Wizert;
        while (Exit == Wizert)
        {
            Exit = map[rand.Next(1, 5), rand.Next(1, 5)];
        }
        
        //FIXME: Add Potions and Monsters

        bool defeat = false;
        
        // Navigation Starts Here. This bool above desides if the player wins or not.
        while (Wizert != Exit || defeat != true)
        {
            //The player is prompted for a direction.
            Console.WriteLine("Which way would you like to go? Press...");

            // All directions are initially set as false. These will change depending on Wizert's location.
            bool north = false;
            bool east = false;
            bool south = false;
            bool west = false;

            Console.WriteLine("");
            // The game checks if the Wizert is at an edge of the map. Depending on which edge they're next to, directions will be set to true or false accordingly.
            if (Wizert != map[1, 1] || Wizert != map[2,1]|| Wizert != map[3, 1] || Wizert != map[4, 1] || Wizert != map[5, 1])
            {
                north = true;
                Console.WriteLine("1. Go North");
            }
            
            if (Wizert != map[5, 1] || Wizert != map[5, 2] || Wizert != map[5, 3] || Wizert != map[5, 4] || Wizert != map[5, 5])
            {
                east = true;
                Console.WriteLine("2. Go East");
            }
            if (Wizert != map[1, 5] || Wizert != map[2, 5] || Wizert != map[3, 5] || Wizert != map[4, 5] || Wizert != map[5, 5])
            {
                south = true;
                Console.WriteLine("3. Go South");
            }
            if (Wizert != map[1, 1] || Wizert != map[1, 2] || Wizert != map[1, 3] || Wizert != map[1, 4] || Wizert != map[1, 5])
            {
                west = true;
                Console.WriteLine("4. Go West");
            }


            //Player's input.
            var a = Console.ReadKey(false).Key;


            // Depending on which key is press above, the Wizert will move in a direction or be reprompted to choose again.
            if ((a == ConsoleKey.NumPad1 || a == ConsoleKey.D1) && (north == true))
            {
                //FIXME
                break;
            }

            else if (a == ConsoleKey.NumPad2 || a == ConsoleKey.D2 && (east == true))
            {
                //FIXME
                break;
            }
            else if (a == ConsoleKey.NumPad3 || a == ConsoleKey.D3 && (south == true))
            {
                //FIXME
                break;
            }
            else if (a == ConsoleKey.NumPad4 || a == ConsoleKey.D4 && (west == true))
            {
                //FIXME
                break;
            }
            else
            {
                //FIXME
                defeat = true;
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
    



    // Layer 1: Continue or Quit
    //    -  Remember FIXME
    //
    // Layer 2: The Map
    // a. Decide the locations of Every Square (Cannot Overlap, Player doesn't have access to Info)



    //    - 1 Wizert (Start)
    //    - 1 Exit
    //    - Enemies
    //          - 5 Goblins
    //          - 5 Orcs
    //          - 3 Banshees
    //    - Potions
    //          - 3 Health Potions
    //          - 3 Magicka Potions
    //    
    //    
    // b. Navigation
    //    - North, South, East, West
    //    - 5x5 Grid (Player has no map, walls only outside of the array.)
    //    - Encounter Order:
    //          1. Enemy Encounter (If Available)
    //          2. Powerup Found (If Available)
    //          3. Description of Room
    //          4. Choose a Direction
    //          
    // Layer 3: Fights
    // a. Create Characters and Attacks
    //   - Wizert (The Player)
    //      - 100 HP
    //      - 200 MP
    //          - Fireball (3 MP)
    //          - Heal (5 MP)
    //          - Flee (0 MP, 1st: 50%, 2nd: 75%, 3rd: Guaranteed)
    //  
    // 
    //   - Goblin
    //      - 3 HP
    //          - Body Slam (2 HP towards Wizert)
    //   - Orc
    //      - 5 HP
    //          - Cleave (3 HP towards Wizert)
    //   - Banshee
    //      - 8 HP
    //          - Screech (5 HP towards Wizert)
    //
    // b. Battle System Outline
    // 
    //  Entering the room, you encounter a Banshee!
    //  
    //  HP: 100   MP: 200
    //  What will Wizert do?
    //
    //  Press...
    //
    //  1. Cast Fireball (3 MP)
    //  2. Heal yourself (5 MP)
    //  3. Flee from the fight
    //
    //  Wizert Casts Fireball!
    //
    //  The Banshee takes 5 damage.
    //
    //  The Banshee Screeches at Wizert!
    //
    //  Wizert takes 5 damage.
    //
    //  HP: 95   MP: 197
    //  What will Wizert do?
    //
    //  Press...
    //
    //  1. Cast Fireball (3 MP)
    //  2. Heal yourself (5 MP)
    //  3. Flee from the fight
    //
    //  Wizert Casts Fireball!
    //
    //  The Banshee takes 5 damage.
    //  The Banshee falls!
    //  
    //  
    //
    //
    //
    //
    //
    //
    //
    //







