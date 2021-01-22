using AdventureGame.Characters;
using AdventureGame.HelperMethods;
using AdventureGame.Interfaces;
using AdventureGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventureGame
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

        private void StartGame()
        {
            Console.Clear();
            Draw.MovingTitle();
            CharacterCreation();
            Run();
        }

        private void CharacterCreation()
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

        private void GodMode()
        {
            player.Name = "Kakashi Hatake";
            player.Level = 10;
            player.Hp = 1000;
            player.MaxHp = 1000;
            player.Damage = "8d100";
            player.Gold = 100000;
            player.Armor = new Armor("Infinite Armour", 5000, 100);
            player.Weapon = new Weapon("Samehada", 100000, "8d100");
            Potion potion = new Potion("Red Bull", 30, 10, "\t You drink a powerfull potion that gives you wings.");
            potion.Quantity = 100;
            player.Backpack.Add(potion);
        }

        private void Run()
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
                        Tavern();
                        break;
                    case "C":
                        ShowDetails();
                        break;
                    case "B":
                        Backpack();
                        break;
                    case "M":
                        Utility.PrintMap();
                        break;
                    case "E":
                        ExitGame();
                        break;
                    default:
                        break;
                }
            }
        }

        private string MainMenu()
        {
            string[] content = new string[]
            {
                "1. Go on an Adventure",
                "2. Go to Tavern",
                "C. Show Details",
                "B. Open Backpack",
                "M. Open Map",
                "E. Exit Game"
            };
            Console.WriteLine();
            Utility.PrintWithFrame("[darkcyan]MENU[/darkcyan]", content);
            Console.Write("\t > ");
            return ColorConsole.ReadInBlue();
        }

        private void GoAdventure()
        {
            Console.WriteLine("\n\t You start your adventure by going north...");
            Console.WriteLine("\t Be careful not to loose yourself in the wild!");
            player.Pos = 0.1;
            while (true)
            {
                player.Pos = Math.Round(player.Pos, 1);
                bool exit = false;
                if (player.Pos == 0.0)
                {
                    break;
                }
                else if (player.Pos == 0.1)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go East",
                            "3. Go West",
                            "4. Go back home",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went north...");
                                player.Pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "2":
                                Console.WriteLine("\t You went east...");
                                player.Pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "3":
                                Console.WriteLine("\t You went west...");
                                player.Pos -= 1.2;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "4":
                                Console.WriteLine("\t You went back home...");
                                player.Pos -= 0.1;
                                exit = true;
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == -1.1 || player.Pos == 1.1)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go East",
                            "3. Go West",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went north...");
                                if (player.Pos == -1.1)
                                {
                                    player.Pos -= 0.1;
                                }
                                else
                                {
                                    player.Pos += 0.1;
                                }
                                exit = true;
                                EncounterCheck();
                                break;
                            case "2":
                                Console.WriteLine("\t You went east...");
                                if (player.Pos == -1.1)
                                {
                                    player.Pos += 1.2;
                                }
                                else
                                {
                                    player.Pos += 1.0;
                                }
                                exit = true;
                                EncounterCheck();
                                break;
                            case "3":
                                Console.WriteLine("\t You went west...");
                                player.Pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == -1.2)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go East",
                            "3. Go South",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went north...");
                                player.Pos -= 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "2":
                                Console.WriteLine("\t You went east...");
                                player.Pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "3":
                                Console.WriteLine("\t You went south...");
                                player.Pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == 0.2 || player.Pos == 2.1 || player.Pos == 1.3)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go East",
                            "2. Go South",
                            "3. Go West",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went east...");
                                player.Pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "2":
                                Console.WriteLine("\t You went South...");
                                player.Pos -= 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "3":
                                Console.WriteLine("\t You went west...");
                                if (player.Pos == 0.2)
                                {
                                    player.Pos -= 1.4;
                                }
                                else
                                {
                                    player.Pos -= 1.0;
                                }
                                exit = true;
                                EncounterCheck();
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == 1.2 || player.Pos == 3.2)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go South",
                            "3. Go West",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went north...");
                                player.Pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "2":
                                Console.WriteLine("\t You went south...");
                                player.Pos -= 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "3":
                                Console.WriteLine("\t You went west...");
                                player.Pos -= 1.0;
                                exit = true;
                                if (player.Pos == 2.2)
                                {
                                    MeetHiruzen();
                                }
                                else
                                {
                                    EncounterCheck();
                                }
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == -1.3 || player.Pos == 3.3)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go South",
                            "2. Go West",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went south...");
                                if (player.Pos == -1.3)
                                {
                                    player.Pos += 0.1;
                                }
                                else
                                {
                                    player.Pos -= 0.1;
                                }
                                exit = true;
                                EncounterCheck();
                                break;
                            case "2":
                                Console.WriteLine("\t You went west...");
                                player.Pos -= 1.0;
                                exit = true;
                                if (player.Pos == -2.3)
                                {
                                    AbuHassansShop();
                                }
                                else
                                {
                                    EncounterCheck();
                                }
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == -2.1 || player.Pos == 2.0 || player.Pos == 0.3)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go East",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went north...");
                                if (player.Pos == -2.1)
                                {
                                    player.Pos -= 0.1;
                                }
                                else
                                {
                                    player.Pos += 0.1;
                                }
                                exit = true;
                                if (player.Pos == 0.4)
                                {
                                    BossEncounter();
                                }
                                else if (player.Pos == -2.2)
                                {
                                    Treasure();
                                }
                                else
                                {
                                    EncounterCheck();
                                }
                                break;
                            case "2":
                                Console.WriteLine("\t You went east...");
                                player.Pos += 1.0;
                                exit = true;
                                if (player.Pos == 3.0)
                                {
                                    Graveyard();
                                }
                                else
                                {
                                    EncounterCheck();
                                }
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == 3.1)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go West",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went north...");
                                player.Pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "2":
                                Console.WriteLine("\t You went west...");
                                player.Pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == 2.3)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go East",
                            "2. Go West",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                        };
                        Utility.PrintWithFrame("", content);
                        Console.Write("\t > ");
                        string choice = ColorConsole.ReadInBlue();
                        switch (choice.ToUpper())
                        {
                            case "1":
                                Console.WriteLine("\t You went east...");
                                player.Pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "2":
                                Console.WriteLine("\t You went west...");
                                player.Pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case "C":
                                ShowDetails();
                                break;
                            case "B":
                                Backpack();
                                break;
                            case "M":
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (player.Pos == 2.2 || player.Pos == -2.3 || player.Pos == -3.2)
                {
                    Console.WriteLine("\n\t What do you want to do?");
                    string[] content = new string[]
                    {
                            "1. Go East",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                    };
                    Utility.PrintWithFrame("", content);
                    Console.Write("\t > ");
                    string choice = ColorConsole.ReadInBlue();
                    switch (choice.ToUpper())
                    {
                        case "1":
                            Console.WriteLine("\t You went east...");
                            player.Pos += 1.0;
                            exit = true;
                            EncounterCheck();
                            break;
                        case "C":
                            ShowDetails();
                            break;
                        case "B":
                            Backpack();
                            break;
                        case "M":
                            Utility.PrintMap();
                            break;
                        default:
                            Console.WriteLine("\t Invalid choice...");
                            break;
                    }
                }
                else if (player.Pos == 3.0)
                {
                    Console.WriteLine("\n\t What do you want to do?");
                    string[] content = new string[]
                    {
                            "1. Go West",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                    };
                    Utility.PrintWithFrame("", content);
                    Console.Write("\t > ");
                    string choice = ColorConsole.ReadInBlue();
                    switch (choice.ToUpper())
                    {
                        case "1":
                            Console.WriteLine("\t You went west...");
                            player.Pos -= 1.0;
                            exit = true;
                            EncounterCheck();
                            break;
                        case "C":
                            ShowDetails();
                            break;
                        case "B":
                            Backpack();
                            break;
                        case "M":
                            Utility.PrintMap();
                            break;
                        default:
                            Console.WriteLine("\t Invalid choice...");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\t What do you want to do?");
                    string[] content = new string[]
                    {
                            "1. Go South",
                            "C. Show Details",
                            "B. Open Backpack",
                            "M. Open Map"
                    };
                    Utility.PrintWithFrame("", content);
                    Console.Write("\t > ");
                    string choice = ColorConsole.ReadInBlue();
                    switch (choice.ToUpper())
                    {
                        case "1":
                            Console.WriteLine("\t You went south...");
                            if (player.Pos == -2.2)
                            {
                                player.Pos += 0.1;
                            }
                            else
                            {
                                player.Pos -= 0.1;
                            }
                            exit = true;
                            EncounterCheck();
                            break;
                        case "C":
                            ShowDetails();
                            break;
                        case "B":
                            Backpack();
                            break;
                        case "M":
                            Utility.PrintMap();
                            break;
                        default:
                            Console.WriteLine("\t Invalid choice...");
                            break;
                    }
                }
            }
        }

        private void AbuHassansShop()
        {
            Console.WriteLine("\n\t Welcome to Abu hassan's one stop shop for everyting a good adventurer could ever need");
            Console.WriteLine("\t Welcome back again soon!");
            Console.WriteLine("\t [Press enter to go back the way you came]");
            Console.ReadLine();
        }

        private void Treasure()
        {
            if (!treasureTaken)
            {
                Console.WriteLine("\n\t Yeay! you got a treasure!");
                treasureTaken = true;
            }
            else
            {
                Console.WriteLine("\n\t The treasue is no more...");
            }
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void Graveyard()
        {
            if (!graveyardVisited)
            {
                Console.WriteLine("\n\t Yeay! you got a treasure!");
                graveyardVisited = true;
            }
            else
            {
                Console.WriteLine("\n\t The graveyard is dead silent");
            }
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void MeetHiruzen()
        {
            if (!haveYouMetHim)
            {
                Weapon weapon = new Weapon("Chakra Blade", 1500, "2d8");
                Armor armor = new Armor("Chakra Armour", 2000, 75);
                Potion potion = new Potion("Healing potion", 20, 15, "");
                potion.Quantity = 10;

                string[] content = new string[]
                {
                "An old man with white beard appears in front of you.",
                "The man, dressed in red and white, looks upon you as if",
                "he was expecting your arrival with a big smile on his face.",
                $"[magenta]{player.Name}, he says while smoking on his pipe...[/magenta]",
                "You instantly recognice the old man as Hiruzen Sarutobi",
                "[magenta]There is little time and you need to go on with[/magenta]",
                "[magenta]your quest to save Hanare![/magenta]",
                "[magenta]Take these items and be on your way![/magenta]",
                $"You got a {weapon.Name}, a {armor.Name} and 10 potions."
                };
                Utility.PrintWithFrame("[magenta]HIRUZEN[/magenta]", content);

                player.Backpack.Add(weapon);
                player.Backpack.Add(armor);
                player.Backpack.Add(potion);
                haveYouMetHim = true;
            }
            else
            {
                Console.WriteLine("\n\t Hiruzen smokes his pipe...");
                Console.WriteLine("\t [Press enter to continue]");
                Console.ReadLine();
            }

        }

        private void LoseScreen()
        {
            Console.WriteLine("\n\t Sorry, you lose...");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
            PlayAgain();
        }

        private void WinScreen()
        {
            Console.WriteLine("\n\t Yeay! You win!");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
            PlayAgain();
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
                        Utility.PrintWithFrame("[darkcyan]BACKPACK[/darkcyan]", content.ToArray());
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

        // Implementera mer!
        private void BossEncounter()
        {
            if (player.Level >= 10)
            {
                Enemy boss = new Enemy("Kaguya Otsutsuki", 10, 500, "3d18", 500);
                FightTheBoss();
                if (player.Hp > 0)
                {
                    WinScreen();
                }
                else
                {
                    LoseScreen();
                }
            }
            else
            {
                Console.WriteLine("\t You are not strong enough to fight the opponent...");
                Console.WriteLine("\t [Press enter to continue]");
                Console.ReadLine();
            }

        }

        private void FightTheBoss()
        {
            player.Hp -= 1000;
            Console.WriteLine("\n\t You were not ready!");
            string[] haha = new string[] { "Ha! ", "Ha! ", "Ha! ", };
            Console.Write("\t ");
            Thread.Sleep(1000);
            foreach (var ha in haha)
            {
                ColorConsole.WriteInRed(ha);
                Thread.Sleep(1000);
            }
        }

        private void Battle()
        {
            Enemy[] enemies = Utility.GetEnemies().Where(e => e.Level <= player.Level).ToArray();
            Enemy enemy = enemies[Utility.RollDice(enemies.Length)];
            int battleCtr = 0;
            List<string> content = new List<string>();
            while (enemy.Hp > 0)
            {
                content.Clear();
                if (battleCtr == 0)
                {
                    content.Add($"You have encountered {enemy.Name}!");
                    battleCtr++;
                }
                int damage = player.Attack();
                enemy.Hp -= damage;
                content.Add($"You hit {enemy.Name} with your {player.Weapon.Name} dealing {damage} damage!");
                if (enemy.Hp <= 0)
                {
                    content.Add($"You defeated {enemy.Name}!");
                    content.Add($"You gained {enemy.Exp} Exp and {enemy.Gold} gold!");
                    player.Exp += enemy.Exp;
                    player.Gold += enemy.Gold;

                    if (player.Exp >= player.MaxExp)
                    {
                        content.Add("Well Done! You leveled up!");
                        player.LevelUp();
                    }
                }
                else
                {
                    damage = enemy.Attack();
                    player.Hp -= damage;
                    content.Add($"{enemy.Name} hits you dealing {damage} damage!");
                    if (player.Hp <= 0)
                    {
                        content.Add($"You were defeated by { enemy.Name}!");
                        content.Add("You lose...");
                    }
                    else
                    {
                        if (player.Hp < player.MaxHp)
                        {
                            content.Add($"{player.Name} Hp: [red]{player.Hp}[/red]");
                        }
                        else
                        {
                            content.Add($"{player.Name} Hp: {player.Hp}");
                        }
                        content.Add($"{enemy.Name} Hp: {enemy.Hp}");
                    }
                }
                Utility.PrintWithFrame("[red]BATTLE[/red]", content.ToArray());

                if (player.Hp <= 0)
                {
                    LoseScreen();
                }
                else
                {
                    Console.WriteLine("\t [Press enter to continue]");
                    Console.ReadLine();
                }
            }
        }

        private void EncounterCheck()
        {
            int chance = Utility.RollDice(10);
            if (chance == 0)
            {
                Console.WriteLine("\t This is a very peacefull place and you don't sense any trouble near you.");
                Console.WriteLine("\t [Press enter to continue]");
            }
            else
            {
                Console.WriteLine();
                Battle();
            }
        }

        private void PlayAgain()
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
            Utility.PrintWithDividedFrame("[darkcyan]DETAILS[/darkcyan]", content1, "EQUIPPED", content2, longest.Length - 17);
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void Tavern()
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
                            Rest();
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
                            Eat();
                        }
                        else
                        {
                            Console.WriteLine("\t Sorry! You don't have enough gold...\n");
                        }
                        break;
                    case "3":
                        Shop();
                        break;
                    case "E":
                        Console.WriteLine("\t Thank you for visiting! We hope to see you back again soon!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\t Invalid choice. Try again...\n");
                        break;
                }
            }
        }

        private void Rest()
        {
            player.Hp = player.MaxHp;
            Console.WriteLine("\t You slept like a baby and are fully rested and healed.");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void Eat()
        {
            player.Hp += player.MaxHp / 2;
            Console.WriteLine("\t You feel much better after a good meal.");
            Console.WriteLine("\t Your Hp is now restored by 50%.");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void Shop()
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
            }
        }

        private void BuyArmor()
        {
            Armor[] armors = Utility.GetArmors();
            while (true)
            {
                Console.WriteLine("\n\t What armor do you want to buy?");
                Console.WriteLine("\t┏━ARMOR━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ Nr:  Name:                    Cost:   Hp:   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 1.   [yellow]Flak Jacket              500     +10[/yellow]   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 2.   [yellow]Steam Armour             750     +20[/yellow]   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 3.   [yellow]Shinobi Battle Armour    1500    +50[/yellow]   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 4.   [yellow]Chakra Armour            3000    +75[/yellow]   ┃");
                ColorConsole.WriteEmbeddedColorLine("\t┃ 5.   [yellow]Infinite Armour          5000    +100[/yellow]  ┃");
                Console.WriteLine("\t┃ 6.   Go back to shop menu.                  ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                ColorConsole.Write("\t > ");
                if (int.TryParse(ColorConsole.ReadInBlue(), out int choice))
                {
                    if (choice != 6)
                    {
                        Armor armor = armors[choice - 1];
                        if (player.Gold >= armor.Cost)
                        {
                            player.Gold -= armor.Cost;
                            player.Backpack.Add(armor);
                            Console.WriteLine($"\t Thank you for buying the {armor.Name}!");
                        }
                        else
                        {
                            Console.WriteLine($"\t You dont have enogh gold to buy the {armor.Name}!");
                        }
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    Console.WriteLine("\t Invalid choice, try again!");
                }
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
                Console.WriteLine("\t┃ 9.   Go back to shop menu.             ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                ColorConsole.Write("\t > ");
                if (int.TryParse(ColorConsole.ReadInBlue(), out int choice))
                {
                    if (choice != 9)
                    {
                        Weapon weapon = weapons[choice - 1];
                        if (player.Gold >= weapon.Cost)
                        {
                            player.Gold -= weapon.Cost;
                            player.Backpack.Add(weapon);
                            Console.WriteLine($"\t Thank you for buying the {weapon.Name}!");
                        }
                        else
                        {
                            Console.WriteLine($"\t You don't have enough gold to buy the {weapon.Name}...");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("\t Invalid choice, try again!");
                }


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
                if (int.TryParse(ColorConsole.ReadInBlue(), out int choice))
                {
                    if (choice != 3)
                    {
                        Potion potion = potions[choice - 1];
                        if (player.Gold >= potion.Cost)
                        {
                            player.Gold -= potion.Cost;
                            player.Backpack.Add(potion);
                            Console.WriteLine($"\t Thank you for buying the {potion.Name}!");
                        }
                        else
                        {
                            Console.WriteLine($"\t You dont have enough gold to buy the {potion.Name}");
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        private void SellItems()
        {
            Backpack("sell");
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