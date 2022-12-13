using System;

public class Descriptions
{
    // This is where the descriptions of the rooms in the game are. The description is chosen based on the x and y coordinate.
	public static string Description(int x, int y)
	{
		int room = x + y;

		if (room == 0)
		{
            return "You find a room filled with barrels of fish. If it weren't for the smell, you'd consider taking one to go. ";
		}
        if (room == 1)
        {
            return "You find a room filled with an assortment of crates. ";
        }
        if (room == 2)
        {
            return "You feel a cold breeze go down your back. It's a strange feeling, as the air seems stagnant otherwise. ";
        }
        if (room == 3)
        {
            return "You find a room containing training equipment. Most of it is torn up. ";
        }
        if (room == 4)
        {
            return "You find a room filled with books. Unfortunately, you don't have the time to read them. ";
        }
        if (room == 5)
        {
            return "You find a room with many different weapons, all of which are broken beyond use. ";
        }
        if (room == 6)
        {
            return "You find a damp room. Puddles pool at multiple points on the ground. ";
        }
        if (room == 7)
        {
            return "You find a room containing buckets of water. If the water wasn't so dirty, you would've considered taking a sip. ";
        }
        if (room == 8)
        {
            return "You find a room with large weapons leaning against the wall. They all look very dull though. ";
        }
        else
        {
            return "You enter a dark room. If it weren't for the other rooms, you wouldn't be able to see.";
        }
    }
}
