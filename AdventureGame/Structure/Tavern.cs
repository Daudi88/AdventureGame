using AdventureGame.Characters;
using AdventureGame.Interfaces;
using AdventureGame.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Structure
{
    class Tavern
    {
        public void Inn(Player player)
        {
            Console.WriteLine("\n\t Welcome to the Barbarian Inn!");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\t What can we do for you?");
                string[] content = new string[]
                {
                    "1. Rest for the night for 100 gold (+ 100% Hp)",
                    "2. Eat and drink 60 gold (+ 50% Hp)",
                    "3. Purchase or sell items",
                    "E. Leave"
                };
                Utility.PrintWithFrame("", content);
                Console.Write("\t > ");
                string choice = ColorConsole.ReadInBlue();
                switch (choice.ToUpper())
                {
                    case "1":
                        if (player.Gold >= 100)
                        {
                            player.Gold -= 100;
                            Rest(player);
                        }
                        else
                        {
                            Console.WriteLine("\t Sorry! You don't have enough gold...\n");
                        }
                        break;
                    case "2":
                        if (player.Gold >= 60)
                        {
                            player.Gold -= 60;
                            Eat(player);
                        }
                        else
                        {
                            Console.WriteLine("\t Sorry! You don't have enough gold...\n");
                        }
                        break;
                    case "3":
                        Shop(player);
                        break;
                    case "E":
                        Console.WriteLine("\t Thank you for visiting! We hope to see you back again soon!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\t Invalid choice. Try again...\n");
                        break;
                }
                Console.SetWindowPosition(0, Console.CursorTop - 20);
            }
        }

        private void Rest(Player player)
        {
            player.Hp = player.MaxHp;
            Console.WriteLine("\t You slept like a baby and are fully rested and healed.");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void Eat(Player player)
        {
            player.Hp += player.MaxHp / 2;
            Console.WriteLine("\t You feel much better after a good meal.");
            Console.WriteLine("\t Your Hp is now restored by 50%.");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void Shop(Player player)
        {
            int ctr = 0;
            bool exit = false;
            while (!exit)
            {
                if (ctr == 0)
                {
                    Console.WriteLine("\n\t Welcome to Abu Hassan's Shop");
                    ctr++;
                }
                Console.WriteLine("\t What do you want to do?");
                string[] content = new string[]
                {
                    "1. Buy Armor",
                    "2. Buy Weapons",
                    "3. Buy Potions",
                    "4. Sell items",
                    "5. Leave"
                };
                Utility.PrintWithFrame("", content);
                Console.Write("\t > ");
                int.TryParse(ColorConsole.ReadInBlue(), out int choice);
                switch (choice)
                {
                    case 1:
                        BuyArmor();
                        break;
                    case 2:
                        BuyWeapons();
                        break;
                    case 3:
                        BuyPotions();
                        break;
                    case 4:
                        SellItems();
                        break;
                    case 5:
                        Console.WriteLine("\t Thank you for visiting! We hope to see you back again soon!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\t Invalid choice. Try again...\n");
                        break;
                }
                Console.SetWindowPosition(0, Console.CursorTop - 20);
            }
        }

        private void BuyArmor()
        {
            while (true)
            {
                Armor[] armors = Utility.GetArmors();
                Console.WriteLine("\n\t What armor do you want to buy?");
                Console.WriteLine("\t┏━ARMOR━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ Nr:  Name:                    Cost:   Hp:   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 1.   [yellow]Flak Jacket              500     +10[/yellow]   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 2.   [yellow]Steam Armour             750     +20[/yellow]   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 3.   [yellow]Shinobi Battle Armour    1500    +50[/yellow]   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 4.   [yellow]Chakra Armour            3000    +75[/yellow]   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 5.   [yellow]Infinite Armour          5000    +100[/yellow]  ┃");
                Console.WriteLine("\t┃ E.   Exit.                                  ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                ColorConsole.Write("\t > ");
                string input = ColorConsole.ReadInBlue();
                int.TryParse(input, out int choice);
                if (choice > 0 && choice < 6)
                {
                    Utility.BuyItem(choice, armors);
                    Console.SetWindowPosition(0, Console.CursorTop - 20);
                }
                else if (input.ToUpper() == "E")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid choice, try again!");
                }
                Console.SetWindowPosition(0, Console.CursorTop - 20);
            }
        }

        private void BuyWeapons()
        {
            Weapon[] weapons = Utility.GetWeapons();
            while (true)
            {
                Console.WriteLine("\n\t What weapon do you want to buy?");
                ColorConsole.WriteEmbeddedColorLine("\t┏━[darkcyan]WEAPONS[/darkcyan]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ Nr:  Name:           Cost:   Damage:   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 1.   [yellow]Kunai           150     1d6[/yellow]       ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 2.   [yellow]Shuriken        250     1d8[/yellow]       ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 3.   [yellow]Bow & Arrow     500     1d10[/yellow]      ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 4.   [yellow]Crossbow        750     1d12[/yellow]      ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 5.   [yellow]Tekagi-Shuko    1000    2d6[/yellow]       ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 6.   [yellow]Chakra Blade    1500    2d8[/yellow]       ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 7.   [yellow]Spear           2000    2d10[/yellow]      ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 8.   [yellow]Sword           2500    2d12[/yellow]      ┃");
                Console.WriteLine("\t┃ E.   Exit.                             ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                ColorConsole.Write("\t > ");
                string input = ColorConsole.ReadInBlue();
                int.TryParse(input, out int choice);
                if (choice > 0 && choice < 8)
                {
                    Utility.BuyItem(choice, weapons);
                    Console.SetWindowPosition(0, Console.CursorTop - 20);
                }
                else if (input.ToUpper() == "E")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid choice, try again!");
                }
                Console.SetWindowPosition(0, Console.CursorTop - 20);
            }
        }

        private void BuyPotions()
        {
            Potion[] potions = Utility.GetPotions();
            while (true)
            {
                Console.WriteLine("\n\t How many potions do you want to buy?");
                Console.WriteLine("\t┏━Potions━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ Nr:  Name:           Cost:   HP:       ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 1.   [yellow]Power King   15     + 5HP[/yellow]       ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 2.   [yellow]Red Bull     30    + 10HP[/yellow]       ┃");
                Console.WriteLine("\t┃ 3.   Go back to shop menu.             ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                ColorConsole.Write("\t > ");
                string input = ColorConsole.ReadInBlue();
                int.TryParse(input, out int choice);
                if (choice > 0 && choice < 6)
                {
                    Utility.BuyItem(choice, potions);
                    Console.SetWindowPosition(0, Console.CursorTop - 20);
                }
                else if (input.ToUpper() == "E")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\t Invalid choice, try again!");
                }
                Console.SetWindowPosition(0, Console.CursorTop - 20);
            }
        }
    }
}
