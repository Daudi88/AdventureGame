using AdventureGame.Characters;
using AdventureGame.Interfaces;
using AdventureGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventureGame.Structure
{
    class Game
    {
        public static Player player;
        private static bool treasureTaken = false;
        private static bool haveYouMetHim = false;
        private static bool graveyardVisited = false;
        public void Setup()
        {
            Console.Title = "The Shinobi";
            Console.SetWindowSize(130, 75);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            StartGame();
        }

        private static void StartGame()
        {
            Console.Clear();
            Display.Title();
            CharacterCreation();
            Run();
        }

        private static void CharacterCreation()
        {
            player = new Player(35, "1d6");
            while (true)
            {
                Console.WriteLine("\n\t What is your name?");
                Console.Write("\t > ");
                string name = ColorConsole.ReadInBlue();
                name = name.Trim();

                if (name.Length < 3)
                {
                    Console.WriteLine("\t The name is too short...");
                }
                else if (name.Length > 12)
                {
                    Console.WriteLine("\t The name is too long...");
                }
                else if (name.Trim().ToLower() == "robin")
                {
                    GodMode();
                    break;
                }
                else
                {
                    player.Name = name[0].ToString().ToUpper() + name[1..].ToLower();
                    break;
                }
            }
        }

        private static void GodMode()
        {
            player.Name = "Kakashi Hatake";
            player.Level = 10;
            player.Hp = 1000;
            player.MaxHp = 1000;
            player.Damage = "8d100";
            player.Gold = 100000;
            player.Armor = new Armor("Infinite Armour", 5000, 100);
            player.Weapon = new Weapon("Samehada", 100000, "8d100");
            Potion potion = new Potion("Red Bull", 30, 10, "You drink a powerfull potion that gives you wings.");
            potion.Quantity = 100;
            player.Backpack.Add(potion);
        }

        private static void Run()
        {
            while (true)
            {
                string choice = MainMenu();
                switch (choice.ToUpper())
                {
                    case "1":
                        GoAdventure();
                        break;
                    case "2":
                        Inn();
                        break;
                    case "C":
                        ShowDetails();
                        break;
                    case "B":
                        Backpack();
                        break;
                    case "M":
                        Display.Map();
                        break;
                    case "E":
                        ExitGame();
                        break;
                    default:
                        break;
                }
            }
        }

        

        private void Backpack(string str = null)
        {
            if (player.Backpack != null)
            {
                bool exit = false;
                List<string> content = new List<string>();
                if (str == null)
                {
                    while (!exit)
                    {
                        content.Clear();
                        int ctr = 1;
                        foreach (var item in player.Backpack)
                        {
                            content.Add($"{ctr++}. [yellow]{item}[/yellow]");
                        }
                        content.Add($"{ctr}. Go back");
                        Console.WriteLine("\n\t What item do you want to use");
                        Display.PrintWithFrame("[darkcyan]BACKPACK[/darkcyan]", content.ToArray());
                        Console.Write("\t > ");
                        if (int.TryParse(ColorConsole.ReadInBlue(), out int choice))
                        {
                            if (choice < ctr)
                            {
                                Item item = player.Backpack[choice - 1];
                                if (item is IEquipable equipable)
                                {
                                    equipable.Equip(player, equipable);

                                }
                                else if (item is IConsumable consumable)
                                {
                                    consumable.Consume(player);
                                }

                                item.Quantity--;
                                if (item.Quantity == 0)
                                {
                                    player.Backpack.Remove(item);
                                }
                            }
                            else
                            {
                                exit = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\t Invalid choice, try again!");
                            Console.WriteLine("\t [Press enter to continue]");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < player.Backpack.Count; i++)
                    {
                        content.Add($"{i + 1}. [yellow]{player.Backpack[i]} {player.Backpack[i].Cost}[/yellow]");
                    }
                    Console.WriteLine("\n\t What item do you want to sell?");
                    // Skriv ut alla items i backpack
                }

            }
            else
            {
                Console.WriteLine("\t Your backpack is empty...");
                Console.WriteLine("\t [Press enter to continue]");
                Console.ReadLine();
            }

        }
                        

        private void ShowDetails()
        {
            Console.WriteLine();
            string[] content1 = new string[]
            {
                $"Name: [yellow]{player.Name}[/yellow]",
                $"Level: [yellow]{player.Level}[/yellow]",
                $"Hp: [yellow]{player.Hp}/{player.MaxHp}[/yellow]",
                $"Exp: [yellow]{player.Exp}/{player.MaxExp}[/yellow]",
                $"Damage: [yellow]{player.Damage}[/yellow]",
                $"Gold: [yellow]{player.Gold}[/yellow]",
            };

            string armor;
            if (player.Armor != null)
            {
                armor = player.Armor.ToString();
            }
            else
            {
                armor = new string(string.Empty);
            }

            string weapon;
            if (player.Weapon != null)
            {
                weapon = player.Weapon.ToString();
            }
            else
            {
                weapon = new string(string.Empty);
            }

            string[] content2 = new string[]
            {
                $"Armor: [yellow]{armor}[/yellow]",
                $"Weapon: [yellow]{weapon}[/yellow]"
            };

            string[] contents = new string[content1.Length + content2.Length];
            Array.Copy(content1, contents, content1.Length);
            Array.Copy(content2, 0, contents, content1.Length, content2.Length);

            string longest = contents.OrderByDescending(s => s.Length).First();
            Display.PrintWithDividedFrame("[darkcyan]DETAILS[/darkcyan]", content1, "EQUIPPED", content2, longest.Length - 17);
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        public static void PlayAgain()
        {
            Console.WriteLine("\t Do you want to play again? (y/n)");
            Console.Write("\t > ");
            string choice = ColorConsole.ReadInBlue();
            if (choice.ToLower() == "y")
            {
                StartGame();
            }
            else
            {
                ExitGame();
            }
        }

        private static void ExitGame()
        {
            Console.Write("\n\t Exiting game");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(800);
                Console.Write(".");
            }
            Thread.Sleep(800);
            Environment.Exit(0);
        }
    }
}