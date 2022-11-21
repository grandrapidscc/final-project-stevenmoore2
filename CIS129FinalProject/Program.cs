// This is where the program starts.

bool gamer = true;

while (gamer == true)
{

    //Depending on what game.generate() returns, the player will be told if they have won or not.
    //FIXME: See BUGFIX on Game.cs (Line 7)
    bool a = true;
    if (a)
    {
        Console.WriteLine("You found the exit and escaped the dungeon! You Win!");
    }
    else
    {
        Console.WriteLine("Wizert was defeated");
    }

    //The player is prompted if they would like to play again and must choose one of two options.
    Console.WriteLine("Would you like to play again?\nPress... \n1. Yes\n2. No");

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
