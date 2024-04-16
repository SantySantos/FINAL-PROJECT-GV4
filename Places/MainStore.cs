﻿using OOP_PROJECT.Story;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using OOP_PROJECT;
using OOP_PROJECT.Main_Character_Description;
using System.Net.Security;
using FINAL_PROJECT_GV5.Places;

namespace OOP_PROJECT.Places
{

    internal class MainStore : Place
    {
        
        internal override string Description()
        {
            
            Characters MainCharacter = Main_Character_Description.Switch.MainCharacter;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Gold:" + MainCharacter.gold);
            Console.ResetColor();
            return @"STORE
1. Fruits, regenarates 5 hp - 10 gold
2. Super fruits, regerates 20 hp - 38 gold
3. go back to refugee


What option do you pick(write the number)?";

        }
        public bool GoldReturn(int price)
        {
            Characters MainCharacter = Main_Character_Description.Switch.MainCharacter;

            if (MainCharacter.gold - price >= 0)
            {
                MainCharacter.gold -= price;
                return true;
            }
            else
            {
                return false;
            }
        }
        internal override void MovingAround(string choice2)
        {
            var inventory = new Inventory();
            switch (choice2)
            {
                case "1":
                    
                    if(GoldReturn(10) == true)
                    {
                        GoldReturn(10);
                        inventory.BuyingFruits();
                    }
                    else if (GoldReturn(10) == false)
                    {
                        Console.WriteLine("You dont have enough Money");
                    }
                    Console.Clear();
                    Game.Transition<MainStore>();
                    break;
                case "2":
                    if (GoldReturn(38) == true)
                    {
                        GoldReturn(38);
                        inventory.BuyingSuperFruits();
                    }
                    else if(GoldReturn(38) == false)
                    {
                        Console.WriteLine("You dont have enough Money");
                    }

                    Console.Clear();
                    Game.Transition<MainStore>();
                    break;
                case "3":
                    GoldReturn(20);
                    Console.Clear();
                    Game.Transition<Refugee>();
                    break;
                default:
                    Console.WriteLine("Choose a valid option");
                    break;
            }
           
        }
    }
}

