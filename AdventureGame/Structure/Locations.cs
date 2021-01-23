using AdventureGame.Characters;
using AdventureGame.Items.Armors;
using AdventureGame.Items.Potions;
using AdventureGame.Items.Weapons;
using System;

namespace AdventureGame.Structure
{
    class Locations
    {
        public static void LightningBurger(Player player)
        {
            if (player.Gold >= 100)
            {
                player.Gold -= 100;
                player.Hp += player.MaxHp / 4;
                Console.WriteLine("\t You feel much better after a good burger.");
                Console.WriteLine("\t Your health is now restored by 25%.");
                Console.WriteLine("\t [Press enter to continue]");
                Console.ReadLine();
            }
            else
            {
                Utility.TypeOverWrongDoings("Sorry! You don't have enough gold...");
            }

        }

        public static void KonohaHospital(Player player)
        {
            if (player.Gold >= 300)
            {
                player.Gold -= 300;
                player.Hp = player.MaxHp;
                Console.WriteLine("\t The Dr. patched you up and you feel rested and fully healed.");
                Console.WriteLine("\t [Press enter to continue]");
                Console.ReadLine();
            }
            else
            {
                Utility.TypeOverWrongDoings("Sorry! You don't have enough gold...");
            }
        }


        public static void NinjaToolShop(Player player)
        {
            int ctr = 0;
            bool outerExit = false;
            while (!outerExit)
            {
                if (ctr == 0)
                {
                    Console.WriteLine("\n\t Welcome to the Ninja Tool Shop");
                    ctr++;
                }
                Console.WriteLine("\t What do you want to do?");
                string[] content = new string[]
                {
                    "1. Buy Armor",
                    "2. Buy Weapons",
                    "3. Buy Potions",
                    "4. Sell items",
                    "E. Leave"
                };
                Display.WithFrame("", content);
                Console.Write("\t > ");
                bool innerExit = true;
                do
                {
                    string choice = ColorConsole.ReadInBlue();
                    switch (choice.ToUpper())
                    {
                        case "1":
                            BuyArmor();
                            break;
                        case "2":
                            BuyWeapons();
                            break;
                        case "3":
                            BuyPotions();
                            break;
                        case "4":
                            Utility.SellItems();
                            break;
                        case "E":
                            Console.WriteLine("\t Thank you for visiting! We hope to see you back again soon!");
                            outerExit = true;
                            break;
                        default:
                            Utility.TypeOverWrongDoings("Invalid choice.Try again...");
                            innerExit = false;
                            break;
                    }
                } while (!innerExit);
                Console.SetWindowPosition(0, Console.CursorTop - 30);
            }
        }

        private static void BuyArmor()
        {
            Armor[] armors = Utility.GetArmors();
            bool outerExit = false;
            while (!outerExit)
            {
                Console.WriteLine("\n\t What armor do you want to buy?");
                Console.WriteLine("\t┏━ARMOR━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ Nr:  Name:                    Cost:   Defence:   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 1.   [yellow]Flak Jacket              100     3[/yellow]          ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 2.   [yellow]Steam Armour             200     5[/yellow]          ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 3.   [yellow]Shinobi Battle Armour    500     8[/yellow]          ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 4.   [yellow]Chakra Armour            2000    20[/yellow]         ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 5.   [yellow]Infinite Armour          5000    45[/yellow]         ┃");
                Console.WriteLine("\t┃ E.   Go back to shop menu.                       ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                ColorConsole.Write("\t > ");
                bool innerExit = true;
                do
                {
                    string input = ColorConsole.ReadInBlue();
                    int.TryParse(input, out int choice);
                    if (choice > 0 && choice < 6)
                    {
                        Utility.BuyItem(choice, armors);
                        Console.SetWindowPosition(0, Console.CursorTop - 20);
                    }
                    else if (input.ToUpper() == "E")
                    {
                        outerExit = true;
                    }
                    else
                    {
                        Utility.TypeOverWrongDoings("Invalid choice.Try again...");
                        innerExit = false;
                    }
                } while (!innerExit);
                Console.SetWindowPosition(0, Console.CursorTop - 30);
            }
        }

        private static void BuyWeapons()
        {
            Weapon[] weapons = Utility.GetWeapons();
            bool outerExit = false;
            while (!outerExit)
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
                Console.WriteLine("\t┃ E.   Go back to shop menu.             ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                ColorConsole.Write("\t > ");
                bool innerExit = true;
                do
                {
                    string input = ColorConsole.ReadInBlue();
                    int.TryParse(input, out int choice);
                    if (choice > 0 && choice < 8)
                    {
                        Utility.BuyItem(choice, weapons);
                        Console.SetWindowPosition(0, Console.CursorTop - 20);
                    }
                    else if (input.ToUpper() == "E")
                    {
                        outerExit = true;
                    }
                    else
                    {
                        Utility.TypeOverWrongDoings("Invalid choice, try again!");
                        innerExit = false;
                    }
                } while (!innerExit);
                Console.SetWindowPosition(0, Console.CursorTop - 30);
            }
        }

        private static void BuyPotions()
        {
            Potion[] potions = Utility.GetPotions();
            bool outerExit = false;
            while (!outerExit)
            {
                Console.WriteLine("\n\t What potion do you want to buy?");
                Console.WriteLine("\t┏━Potions━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ Nr:  Name:           Cost:   Hp:       ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 1.   [yellow]Healing potion  15      +5 Hp[/yellow]     ┃");
                Console.WriteLine("\t┃ E.   Go back to shop menu.             ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                ColorConsole.Write("\t > ");
                bool innerExit = true;
                do
                {
                    string input = ColorConsole.ReadInBlue();
                    int.TryParse(input, out int choice);
                    if (choice > 0 && choice < 6)
                    {
                        Utility.BuyItem(choice, potions);
                        Console.SetWindowPosition(0, Console.CursorTop - 20);
                    }
                    else if (input.ToUpper() == "E")
                    {
                        outerExit = true;
                    }
                    else
                    {
                        Utility.TypeOverWrongDoings("Invalid choice.Try again...");
                        innerExit = false;
                    }
                } while (!innerExit);
                Console.SetWindowPosition(0, Console.CursorTop - 20);
            }
        }
    }
}
