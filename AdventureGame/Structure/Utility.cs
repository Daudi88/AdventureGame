using AdventureGame.Characters;
using AdventureGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.Structure
{
    static class Utility
    {
        static readonly Random random = new Random();

        public static int RollDice(int dice)
        {
            return random.Next(dice);
        }

        public static int RollDice(string dice)
        {
            int times = int.Parse(dice[0].ToString());
            int sides = int.Parse(dice[2..]);
            int result = 0;
            for (int i = 0; i < times; i++)
            {
                result += random.Next(1, sides + 1);
            }
            return result;
        }

        // [HÅKAN] Ge alla fiender balanserad armor 
        public static List<Enemy> GetEnemies()
        {
            List<Enemy> monsters = new List<Enemy>()
              {
                new Enemy("Kisame", 1, 10, 2, "1d4", 50),
                new Enemy("Kabuto", 1, 10, "1d4", 50),
                new Enemy("Obito", 1, 10, "1d4", 50),
                new Enemy("Madara", 1, 10, "1d4", 50),
                new Enemy("Ginkaku", 2, 20, "2d4", 100),
                new Enemy("Kimimaro", 3, 30, "2d6", 150),
                new Enemy("Deidara", 4, 40, "2d8", 200),
                new Enemy("Kakuzu", 5, 60, "2d10", 250),
                new Enemy("Hanzo", 6, 80, "3d8", 300),
                new Enemy("Orochimaru", 7, 25, "3d10", 350),
                new Enemy("Nagato", 8, 200, "2d16", 400),
                new Enemy("Haku", 9, 250, "3d16", 450)
              };
            return monsters;
        }

        internal static Armor[] GetArmors()
        {
            Armor[] armor = new Armor[]
            {
                new Armor("Flak Jacket", 100, 15),
                new Armor("Steam Armour", 200, 20),
                new Armor("Shinobi Battle Armour", 500, 50),
                new Armor("Chakra Armour", 2000, 75),
                new Armor("Infinite Armour", 5000, 100)
            };
            return armor;
        }

        public static Weapon[] GetWeapons()
        {
            Weapon[] weapons = new Weapon[]
            {
                new Weapon("Kunai", 150, "1d6"),
                new Weapon("Shuriken", 250, "1d8"),
                new Weapon("Bow & Arrow", 500, "1d10"),
                new Weapon("Crossbow", 750, "1d12"),
                new Weapon("Tekagi-Shuko", 1000, "2d6"),
                new Weapon("Chakra Blade", 1500, "2d8"),
                new Weapon("Spear", 2000, "2d10"),
                new Weapon("Sword", 2500, "2d12")
            };
            return weapons;

            // Seven Swordsmen of the Mist vapen:
            // Kiba, Kubikiribōchō, Nuibari, Samehada, Shibuki, Hiramekarei, Kabutowari
        }

        public static Potion[] GetPotions()
        {
            Potion[] potions = new Potion[]
            {
                new Potion("Powerking", 15, 5, ""),
                new Potion("Red Bull", 30, 20, "\t You drink a powerfull potion that gives you wings.")
            };
            return potions;
        }

        

        public static void BuyItem(int choice, Item[] items)
        {
            Player player = Game.player;
            Item item = items[choice - 1];
            if (player.Gold >= item.Cost)
            {
                player.Gold -= item.Cost;
                AddToBackpack(item);
                Console.WriteLine($"\t Thank you for buying the {item.Name}!");
            }
            else
            {
                Console.WriteLine($"\t You dont have enogh gold to buy the {item.Name}!");
            }
        }

        public static void AddToBackpack(Item thing)
        {
            Player player = Game.player;
            if (player.Backpack.Contains(thing))
            {
                foreach (var item in player.Backpack)
                {
                    if (item.Name == thing.Name)
                    {
                        item.Quantity++;
                    }
                }
            }
            else
            {
                player.Backpack.Add(thing);
            }
        }

        public static void SellItems()
        {
            Backpack("sell");
        }

        public static void TypeOverWrongDoings() // [HÅKAN] Skriv metoden!
        {
            Console.Write("\t > ");
            Console.ReadLine();
            Console.WriteLine("\t Invalid choice...");

            // Ta in höjden från int top = Console.CursorTop;
            // (left = 9, top)
            // Console.SetCursorPosition(left, --top);
            // Console.WriteLine("                                            ");
            // Console.WriteLine(new String(' ', 20));
            // Console.SetCursorPosition(left, --top);
            // Console.Write("\t > ");

        }
    }
}
