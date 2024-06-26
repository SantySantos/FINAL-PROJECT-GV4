﻿using FINAL_PROJECT_GV5.Places;
using OOP_PROJECT.Main_Character_Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOP_PROJECT.Places
{
    internal class Refugee : Place
    {
        internal override string Description()
        {
            Title();
            return @"To the left, a humble [store] offers supplies. 
To the right a [blacksmith] to get the most powerful weapons.
Straight ahead, the [forest] whispers secrets. 
To the right, the [dungeon] holds riches and horrors. 
The refuge is a place of respite. Write [1] for stats and [2] for Inventory.

Only the bravest reach the Crystals of Ages.

write the place where you want to go";

        }
        internal override void MovingAround(string choice2)
        {
        Characters MainCharacter = Main_Character_Description.Switch.MainCharacter;
            switch (choice2)
            {
                case "store":
                    Game.Transition<MainStore>();
                    break;
                case "forest":
                    Game.Transition<Forest>();
                    break;
                case "dungeon":
                    Console.WriteLine("If you join the dungeon, you will NOT be able to leave, are you well equipped ?");
                    Console.WriteLine("press [1] to join the dungeon or any other key to come back to the refugee");
                    string rr = Console.ReadLine();
                    if(rr == "1")
                    {
                        Console.Clear();
                        Game.Transition<Dungeon>();
                    }
                    else
                    {
                        Console.Clear();
                        Game.Transition<Refugee>();
                    }
                 
                    break;
                case "blacksmith":
                    Game.Transition<BlackSmith>();
                    break;
                case "1":
                    Console.Clear();
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(MainCharacter.Name.ToUpper());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("HP: " + MainCharacter.hp);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("GOLD: " + MainCharacter.gold);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("WEAPON: " + MainCharacter.Weapon);
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
                case "2":
                    Game.Transition<Inventory>();
                    break;
                
                default:
                    Console.WriteLine("that's not a place, try again");
                    break;
            }
            
        }
        internal void Title()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(">>--------------------------<<");
            Console.WriteLine("||        The Refugee       ||");
            Console.WriteLine(">>--------------------------<<");
            Console.ResetColor();
            Console.WriteLine();
        }
        internal void StatsChar()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("████████████████████");
            Console.WriteLine("█      STATS       █");
            Console.WriteLine("████████████████████");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
