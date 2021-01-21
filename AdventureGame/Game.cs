using AdventureGame.Characters;
using AdventureGame.HelperMethods;
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
        static int ctr = 1;
        public void Setup()
        {
            Console.Title = "Adventure Game";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            StartGame();
        }

        private void StartGame()
        {
            if (ctr == 0)
            {
                Draw.MovingTitle();
                ctr++;
            }
            else
            {
                Draw.Title();
            }
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
            player.Armor = new Armor("Shinobi Battle Armour", 10000, 500);
            player.Weapon = new Weapon("Executioner's Blade", 10000, "8d100");
            player.Backpack = new List<Item>()
            {
                new Potion("Red Bull", 30, player.MaxHp / 10, 100)
            };
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
                "4. Exit Game"
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

        private void Backpack() // Implementera mer!
        {
            Console.WriteLine("\n\t Your backpack is empty...");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void BossEncounter() // Implementera mer!
        {
            Console.WriteLine("\n\t The boss is gone! Where has he gone?");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void Battle()
        {
            Enemy[] monsters = Utility.GetMonsters().Where(m => m.Level <= player.Level).ToArray();
            Enemy monster = monsters[Utility.RollDice(monsters.Length)];
            int battleCtr = 0;
            List<string> content = new List<string>();
            while (monster.Hp > 0)
            {
                content.Clear();
                if (battleCtr == 0)
                {
                    content.Add($"You have encountered {monster.Name}!");
                    battleCtr++;
                }
                monster.Hp -= player.Attack(out string text);
                content.Add(text);
                if (monster.Hp <= 0)
                {
                    content.Add($"You defeated {monster.Name}!");
                    content.Add($"You gained {monster.Exp} Exp and {monster.Gold} gold!");
                    player.Exp += monster.Exp;
                    player.Gold += monster.Gold;

                    if (player.Exp >= player.MaxExp)
                    {
                        content.Add("Well Done! You leveled up!");
                        player.LevelUp();
                    }
                }
                else
                {
                    player.Hp -= monster.Attack(out text);
                    content.Add(text);
                    if (player.Hp <= 0)
                    {
                        content.Add($"You were defeated by { monster.Name}!");
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
                        content.Add($"{monster.Name} Hp: {monster.Hp}");
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
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n\t Welcome to Abu Hassans Abracapothecary!");
                Console.WriteLine("\t The one stop shop for everything you could ever want!");
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
            Armor[] armor = Utility.GetArmor();
            string nr = "Nr.";
            string name = "Name:";
            string cost = "Cost:";
            string hp = "Hp:";

            List<string> content = new List<string>() { string.Format("{0}:\t{1}\t\t{2}   {3}  ", nr, name, cost, hp) };
            for (int i = 0; i < armor.Length; i++)
            {
                content.Add($"{i + 1}.\t{armor[i].Name}{armor[i].Cost.ToString().PadRight(8)}+{armor[i].MaxHp.ToString().PadRight(3)}");
            }
 
            string longest = content.OrderByDescending(s => s.Length).First();
            Utility.PrintWithFrame("ARMOR", content.ToArray(), longest.Length);
            //Console.WriteLine($"\t┏━ARMOR━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            //Console.WriteLine($"\t┃ Nr:   Name:                   Cost:   Hp:   ┃");
            //for (int i = 0; i < armor.Length; i++)
            //{
            //    Console.WriteLine($"\t┃ {i + 1}.\t{armor[i].Name.PadRight(24)}{armor[i].Cost.ToString().PadRight(8)}+{armor[i].MaxHp.ToString().PadRight(3)}  ┃");
            //}
            //Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            //bool exit = false;
            //while (!exit)
            //{
            //    Console.WriteLine("\n\t What weapon do you want to buy?");
            //    Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            //    Console.WriteLine("\t┃ 1. Dagger Damage 10. Cost: 50 gold         ┃");
            //    Console.WriteLine("\t┃ 2. Rusty sword Damage 20. Cost: 100 gold   ┃");
            //    Console.WriteLine("\t┃ 3. Broad sword Damage 50. Cost: 200 gold   ┃");
            //    Console.WriteLine("\t┃ 4. Sell all items                          ┃");
            //    Console.WriteLine("\t┃ 5. Leave                                   ┃");
            //    Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            //    Console.Write("\t > ");
            //    int.TryParse(ColorConsole.ReadInGreen(), out int choice);
            //    switch (choice)
            //    {
            //        case 1:
            //            if (player.Gold >= 50)
            //            {
            //                player.Gold -= 50;
            //                // Equip(); leta upp metoden för att lägga till skada från dagger.
            //            }
            //            else
            //            {
            //                Console.WriteLine("\t Sorry! You don't have enough gold...\n");
            //            }
            //            break;
            //        case 2:
            //            if (player.Gold >= 100)
            //            {
            //                player.Gold -= 100;
            //                // Equip(); leta upp metoden för att lägga till weapon.
            //            }
            //            else
            //            {
            //                Console.WriteLine("\t Sorry! You don't have enough gold...\n");
            //            }
            //            break;
            //        case 3:
            //            if (player.Gold >= 200)
            //            {
            //                player.Gold -= 200;
            //                // Equip(); leta upp metoden för att lägga till skada från dagger.
            //            }
            //            else
            //            {
            //                Console.WriteLine("\t Sorry! You don't have enough gold...\n");
            //            }
            //            break;
            //        case 4:
            //            SellItems();
            //            break;
            //        case 5:
            //            Console.WriteLine("\t Thank you for visiting! We hope to see you back again soon!");
            //            exit = true;
            //            break;
            //        default:
            //            Console.WriteLine("\t Invalid choice. Try again...\n");
            //            break;
            //    }
            //}

        }

        private void BuyWeapons()
        {

        }

        private void BuyPotions()
        {

        }

        private void SellItems()
        {

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