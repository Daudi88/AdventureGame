using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Structure
{
    class Adventure
    {

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
                Console.SetWindowPosition(0, Console.CursorTop - 30);
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
                Console.WriteLine();
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
            }
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();

        }

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
    }
}
