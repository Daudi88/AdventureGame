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
        public void Setup()
        {
            Console.Title = "The Shinobi";
            Console.SetWindowSize(135, 40);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            StartGame();
        }

        private void StartGame()
        {
            //if (ctr == 0)
            //{
            //    Draw.MovingTitle();
            //    ctr++;
            //}
            //else
            //{
                Draw.Title();
            //}
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
                string name = ColorConsole.ReadInGreen();
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
            Potion potion = new Potion("Red Bull", 30, 10);
            potion.Quantity = 100;
            player.Backpack.Add(potion);
        }

        private void Run()
        {
            while (true)
            {
                int choice = MainMenu();
                switch (choice)
                {
                    case 1:
                        GoAdventure();
                        break;
                    case 2:
                        ShowDetails();
                        break;
                    case 3:
                        Tavern();
                        break;
                    case 4:
                        Backpack();
                        break;
                    case 5:
                        Utility.PrintMap();
                        break;
                    case 6:
                        ExitGame();
                        break;
                    default:
                        break;
                }
            }
        }

        private int MainMenu()
        {
            string[] content = new string[]
            {
                "1. Go on an Adventure",
                "2. Show Details",
                "3. Go to Tavern",
                "4. Open Backpack",
                "5. Open Map",
                "6. Exit Game"
            };
            string longest = content.OrderByDescending(s => s.Length).First();
            Console.WriteLine();
            Utility.PrintWithFrame("MENU", content, longest.Length);
            Console.Write("\t > ");
            int.TryParse(ColorConsole.ReadInGreen(), out int choice);
            return choice;
        }

        private void GoAdventure()
        {
            double pos = 0.0;
            while (true)
            {
                pos = Math.Round(pos, 1);
                bool exit = false;
                if (pos == 0.0)
                {
                    Console.WriteLine("\n\t You start your adventure by going north...");
                    Console.WriteLine("\t Be careful not to loose yourself in the wild!\n");
                    pos += 0.1;
                    EncounterCheck();
                }
                else if (pos == 0.1)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go East",
                            "3. Go back to town",
                            "4. Go West",
                            "5. Show Details",
                            "6. Open Backpack",
                            "7. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went north...");
                                pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went east...");
                                pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You went back home...");
                                exit = true;
                                MainMenu();
                                break;
                            case 4:
                                Console.WriteLine("\n\t You went west...");
                                pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 5:
                                ShowDetails();
                                break;
                            case 6:
                                Backpack();
                                break;
                            case 7:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == -1.1 || pos == 1.1)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go East",
                            "3. Go West",
                            "4. Show Details",
                            "5. Open Backpack",
                            "6. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went north...");
                                pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went east...");
                                pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You went west...");
                                pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 4:
                                ShowDetails();
                                break;
                            case 5:
                                Backpack();
                                break;
                            case 6:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == -1.2)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go East",
                            "3. Go South",
                            "4. Show Details",
                            "5. Open Backpack",
                            "6. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went north...");
                                pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went east...");
                                pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You went south...");
                                pos -= 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 4:
                                ShowDetails();
                                break;
                            case 5:
                                Backpack();
                                break;
                            case 6:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == 0.2 || pos == 2.1 || pos == 1.3)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go East",
                            "2. Go South",
                            "3. Go West",
                            "4. Show Details",
                            "5. Open Backpack",
                            "6. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went east...");
                                pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went South...");
                                pos -= 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You went west...");
                                pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 4:
                                ShowDetails();
                                break;
                            case 5:
                                Backpack();
                                break;
                            case 6:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == 1.2 || pos == 3.2)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go South",
                            "3. Go West",
                            "4. Show Details",
                            "5. Open Backpack",
                            "6. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went north...");
                                pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went south...");
                                pos -= 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You went west...");
                                pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 4:
                                ShowDetails();
                                break;
                            case 5:
                                Backpack();
                                break;
                            case 6:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == -1.3 || pos == -2.2 || pos == 3.3)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go South",
                            "2. Go West",
                            "3. Show Details",
                            "4. Open Backpack",
                            "5. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went south...");
                                pos -= 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went west...");
                                pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                ShowDetails();
                                break;
                            case 4:
                                Backpack();
                                break;
                            case 5:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == -2.1 || pos == 2.0 || pos == 0.3)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go East",
                            "3. Show Details",
                            "4. Open Backpack",
                            "5. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went north...");
                                pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went east...");
                                pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                ShowDetails();
                                break;
                            case 4:
                                Backpack();
                                break;
                            case 5:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == 3.1)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go North",
                            "2. Go West",
                            "3. Show Details",
                            "4. Open Backpack",
                            "5. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went north...");
                                pos += 0.1;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went west...");
                                pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                ShowDetails();
                                break;
                            case 4:
                                Backpack();
                                break;
                            case 5:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == 2.3)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        string[] content = new string[]
                        {
                            "1. Go East",
                            "2. Go West",
                            "3. Show Details",
                            "4. Open Backpack",
                            "5. Open Map"
                        };
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("", content, longest.Length);
                        Console.Write("\t > ");
                        int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You went west...");
                                pos -= 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You went east...");
                                pos += 1.0;
                                exit = true;
                                EncounterCheck();
                                break;
                            case 3:
                                ShowDetails();
                                break;
                            case 4:
                                Backpack();
                                break;
                            case 5:
                                Utility.PrintMap();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == -3.2 || pos == -2.3 || pos == 2.2)
                {
                    Console.WriteLine("\n\t You went back east again...");
                    pos += 1.0;
                }
                else if (pos == 3.0)
                {
                    Console.WriteLine("\n\t You went back west agian...");
                    pos -= 1.0;
                }
                else if (pos == 0.4)
                {
                    if (player.Level >= 10)
                    {
                        BossEncounter();
                        if (player.Hp > 0)
                        {
                            WinScreen();
                        }
                        else
                        {
                            LoseScreen();
                            TryAgain();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\t You are not strong enough to fight the opponent...");
                        Console.WriteLine("\t [Press enter to go back the way you came]");
                        Console.ReadLine();
                        pos -= 0.1;
                    }
                }
            }
        }

        private void LoseScreen() // Implementera mer!
        {
            Console.WriteLine("\n\t Yeay! You win!");
            Console.ReadLine();
        }

        private void WinScreen() // Implementera mer!
        {
            Console.WriteLine("\n\t Sorry, you lose...");
            Console.ReadLine();
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
                        int ctr = 1;
                        foreach (var item in player.Backpack)
                        {
                            content.Add($"{ctr++}. [yellow]{item}[/yellow]");
                        }
                        content.Add($"{ctr}. Go back");
                        Console.WriteLine("\n\t What item do you want to use");
                        string longest = content.OrderByDescending(s => s.Length).First();
                        Utility.PrintWithFrame("BACKPACK", content.ToArray(), longest.Length);
                        Console.Write("\t > ");
                        if (int.TryParse(ColorConsole.ReadInGreen(), out int choice))
                        {
                            if (choice < ctr)
                            {
                                Item item = player.Backpack[choice - 1];                        
                                if (item is IEquipable equipable)
                                {
                                    equipable.Equip(player, equipable);
                                    Console.WriteLine($"\t you equipped {item.Name} and gained {equipable.Bonus}!");
                                }
                                else if (item is IConsumable consumable)
                                {
                                    consumable.Consume(player);
                                    Console.WriteLine($"\t You drank a {item.Name} and gained {consumable.Healing} health!");
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
                }

            }
            else
            {
                Console.WriteLine("\t Your backpack is empty...");
                Console.WriteLine("\t [Press enter to continue]");
                Console.ReadLine();
            }

        }

        private void BossEncounter() // Implementera mer!
        {
            Console.WriteLine("\n\t The boss is gone! Where has he gone?");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
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
                enemy.Hp -= player.Attack(out string text);
                content.Add(text);
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
                    player.Hp -= enemy.Attack(out text);
                    content.Add(text);
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

                string longest = content.OrderByDescending(s => s.Length).First();
                Utility.PrintWithFrame("BATTLE", content.ToArray(), longest.Length);

                if (player.Hp <= 0)
                {
                    TryAgain();
                }
                else
                {
                    Console.WriteLine("\t[Press enter to continue]");
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
            }
            else
            {
                Battle();
            }
        }

        private void TryAgain()
        {
            Console.WriteLine("\t Do you want to try again? (y/n)");
            Console.Write("\t > ");
            string choice = ColorConsole.ReadInGreen();
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
            Utility.PrintWithDividedFrame("DETAILS", content1, "EQUIPPED", content2, longest.Length - 17);
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
                    "4. Leave"
                };
                string longest = content.OrderByDescending(s => s.Length).First();
                Utility.PrintWithFrame("", content, longest.Length);
                Console.Write("\t > ");
                int.TryParse(ColorConsole.ReadInGreen(), out int choice);
                switch (choice)
                {
                    case 1:
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
                    case 2:
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
                    case 3:
                        Shop();
                        break;
                    case 4:
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
                string longest = content.OrderByDescending(s => s.Length).First();
                Utility.PrintWithFrame("", content, longest.Length);
                Console.Write("\t > ");
                int.TryParse(ColorConsole.ReadInGreen(), out int choice);
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
                if (int.TryParse(ColorConsole.ReadInGreen(), out int choice))
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
                Console.WriteLine("\t┏━WEAPONS━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
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
                if (int.TryParse(ColorConsole.ReadInGreen(), out int choice))
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
                if (int.TryParse(ColorConsole.ReadInGreen(), out int choice))
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