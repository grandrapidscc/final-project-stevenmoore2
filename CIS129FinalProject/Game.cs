using System;

public class game
{
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






}
