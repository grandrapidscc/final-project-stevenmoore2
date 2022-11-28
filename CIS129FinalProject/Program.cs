// This is where the program starts.

bool gamer = true;

while (gamer == true)
{
    //The player character's health and magicka is created and set. (See Fight.cs)
    Wizert player = new Wizert(100,200);

    //Then the game will set the map and locations of enemies, items, the Wizert and the exit.
    //game.Generate();

    //FIXME: This version of the program is to test the battle system. As of now, Game.cs is inaccessible. This will be fixed once the 
    //final version comes out. The two lines below randomly generate an enemy and uses the Wizert's stats above to generate an encounter.

    var rand = new Random();
    bool a = Wizert.Encounter(rand.Next(1, 4), player);
    

    if (a)
    {
        //FIXME: This message will be displayed once the player finds the exit. As that hasn't been fully implimented, the message
        //won't be displayed. 
        
        //Console.WriteLine("You found the exit and escaped the dungeon! You Win!\n");
    }
    

    //The player is prompted if they would like to play again and must choose one of two options.
    Console.WriteLine("Would you like to play again?\nPress... \n1. Yes\n2. No\n");

    //This loop takes the player's first input and immediatly takes an answer.
    while (gamer == true) 
    {
        //Player's input.
        var c = Console.ReadKey(false).Key;
        
        Console.WriteLine("");
        // If the player types the number 2 (Top Row or Num Pad), then the program will stop.
        if (c == ConsoleKey.NumPad2 || c == ConsoleKey.D2)
        {
            gamer = false;
        }
        // If the player types the number 1 (Top Row or Num Pad). The current loop will end and the program will start the game once again.
        else if (c == ConsoleKey.NumPad1 || c == ConsoleKey.D1)
        {
            break;
        }
        // If the player doesn't type either 1 or 2, then the player will be told their input was invalid and will have to try again.
        else
        {
            Console.WriteLine("\nInvalid Option.\nPress... \n1. Yes\n2. No");
        }
    }
}
//The program thanks the player for their time before terminating.
Console.WriteLine("Thanks for Playing!");
