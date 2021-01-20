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
            CharacterCreation();
            if (ctr == 0)
            {
                Draw.MovingTitle();
                ctr++;
            }
            else
            {
                Draw.Title();
            }
            Run();
        }

        private void CharacterCreation()
        {
            player = new Player(35, "1d6");
            while (true)
            {
                Console.WriteLine("\n\t What is your name?");
                Console.Write("\t > ");
                string name = Utility.ReadInGreen();
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
                        Explore();
                        break;
                    case 2:
                        ShowDetails();
                        break;
                    case 3:
                        Tavern();
                        break;
                    case 4:
                        ExitGame();
                        break;
                    case 5:
                        OpenMap();
                        break;
                    default:
                        break;
                }
            }
        }

        private int MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("\t┏━MENU━━━━━━━━━━━━━┓");
            Console.WriteLine("\t┃ 1. Go Explore    ┃");
            Console.WriteLine("\t┃ 2. Show Details  ┃");
            Console.WriteLine("\t┃ 3. Go to Tavern  ┃");
            Console.WriteLine("\t┃ 4. Exit Game     ┃");
            Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
            Console.Write("\t > ");
            int.TryParse(Utility.ReadInGreen(), out int choice);
            return choice;
        }

        private void OpenMap()
        {
            Console.WriteLine();
            Console.WriteLine("\t┏━MAP━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("\t┃                                               ┃");
            Console.WriteLine("\t┃    AAAA AAA                                   ┃");
            Console.Write("\t┃    AAAA  AAAA         ≈≈≈≈≈        ");
            Utility.WriteInRed("X");
            Console.WriteLine("          ┃");
            Console.WriteLine("\t┃    A  AAA AA         ≈≈≈≈≈≈≈                  ┃");
            Console.WriteLine("\t┃        AAAAAA         ≈≈≈≈≈   ######          ┃");
            Console.WriteLine("\t┃                       ############            ┃");
            Console.WriteLine("\t┃                   ##########  ╔──────╗        ┃");
            Console.Write("\t┃     ");
            Utility.WriteInYellow("[δ]");
            Console.WriteLine("            ########   │ town │        ┃");
            Console.WriteLine("\t┃                    #########  ╚──────╝        ┃");
            Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("\t [δ] = secret friend, # = tree, A = mountain ...");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
        }

        private void Explore()
        {            
            double pos = 0.0;
            while (true)
            {
                pos = Math.Round(pos, 1);
                bool exit = false;
                if (pos == 0.0)
                {
                    Console.WriteLine("\n\t You go north...");
                    Console.WriteLine("\t Be careful not to loose yourself in the wild!");
                    pos += 0.1;
                    DoesAnythingHappen();
                }
                else if (pos == 0.1)
                {

                    while (!exit)
                    {
                        Console.WriteLine("\n\t What do you want to do?");
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go North       ┃");
                        Console.WriteLine("\t┃ 2. Go East        ┃");
                        Console.WriteLine("\t┃ 3. Go West        ┃");
                        Console.WriteLine("\t┃ 4. Go to town     ┃");
                        Console.WriteLine("\t┃ 5. Show Details   ┃");
                        Console.WriteLine("\t┃ 6. Open Backpack  ┃");
                        Console.WriteLine("\t┃ 7. Open Map       ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go north...");
                                pos += 0.1;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go east...");
                                pos += 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You go west...");
                                pos -= 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 4:
                                Console.WriteLine("\n\t You go back home...");
                                exit = true;
                                MainMenu();
                                break;
                            case 5:
                                ShowDetails();
                                break;
                            case 6:
                                OpenBackpack();
                                break;
                            case 7:
                                OpenMap();
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
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go North      ┃");
                        Console.WriteLine("\t┃ 2. Go West       ┃");
                        Console.WriteLine("\t┃ 3. Go East       ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go north...");
                                pos += 0.1;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go west...");
                                pos -= 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You go east...");
                                pos += 1.0;
                                exit = true;
                                DoesAnythingHappen();
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
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go North      ┃");
                        Console.WriteLine("\t┃ 2. Go East       ┃");
                        Console.WriteLine("\t┃ 3. Go South      ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go north...");
                                pos += 0.1;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go east...");
                                pos += 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You go south...");
                                pos -= 0.1;
                                exit = true;
                                DoesAnythingHappen();
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
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go West       ┃");
                        Console.WriteLine("\t┃ 2. Go East       ┃");
                        Console.WriteLine("\t┃ 3. Go South      ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go west...");
                                pos -= 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go east...");
                                pos += 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You go South...");
                                pos -= 0.1;
                                exit = true;
                                DoesAnythingHappen();
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
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go North      ┃");
                        Console.WriteLine("\t┃ 2. Go West       ┃");
                        Console.WriteLine("\t┃ 3. Go South      ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go north...");
                                pos += 0.1;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go west...");
                                pos -= 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 3:
                                Console.WriteLine("\n\t You go South...");
                                pos -= 0.1;
                                exit = true;
                                DoesAnythingHappen();
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
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go West       ┃");
                        Console.WriteLine("\t┃ 2. Go South      ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go west...");
                                pos -= 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go South...");
                                pos -= 0.1;
                                exit = true;
                                DoesAnythingHappen();
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
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go North      ┃");
                        Console.WriteLine("\t┃ 2. Go East       ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go north...");
                                pos += 0.1;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go east...");
                                pos += 1.0;
                                exit = true;
                                DoesAnythingHappen();
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
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go North      ┃");
                        Console.WriteLine("\t┃ 2. Go West       ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go north...");
                                pos += 0.1;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go west...");
                                pos -= 1.0;
                                exit = true;
                                DoesAnythingHappen();
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
                        Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━┓");
                        Console.WriteLine("\t┃ 1. Go West       ┃");
                        Console.WriteLine("\t┃ 2. Go East       ┃");
                        Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━┛");
                        Console.Write("\t > ");
                        int.TryParse(Utility.ReadInGreen(), out int choice);
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n\t You go west...");
                                pos -= 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            case 2:
                                Console.WriteLine("\n\t You go east...");
                                pos += 1.0;
                                exit = true;
                                DoesAnythingHappen();
                                break;
                            default:
                                Console.WriteLine("\t Invalid choice...");
                                break;
                        }
                    }
                }
                else if (pos == -3.2 || pos == -2.3 || pos == 2.2)
                {
                    Console.WriteLine("\n\t You go back east again...");
                    pos += 1.0;
                }
                else if (pos == 3.0)
                {
                    Console.WriteLine("\n\t You go back west agian...");
                    pos -= 1.0;
                }
                else if (pos == 0.4)
                {
                    if (player.Level >= 10)
                    {
                        BossEncounter();
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

        private void OpenBackpack()
        {
            throw new NotImplementedException();
        }

        private void BossEncounter()
        {
            throw new NotImplementedException();
        }

        private void DoesAnythingHappen()
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

        private void Battle()
        {
            Monster[] monsters = Utility.GetMonsters().Where(m => m.Level <= player.Level).ToArray();
            Monster monster = monsters[Utility.RollDice(monsters.Length)];
            int battleCtr = 0;
            string text;
            while (monster.Hp > 0)
            {
                Console.WriteLine($"\t┏━BATTLE━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                if (battleCtr == 0)
                {
                    text = $"You have encountered {monster.Name}!";
                    Console.WriteLine($"\t┃ {text.PadRight(39)}  ┃");
                    battleCtr++;
                }
                monster.Hp -= player.Attack();
                if (monster.Hp <= 0)
                {
                    text = $"You defeated {monster.Name}!";
                    Console.WriteLine($"\t┃ {text.PadRight(39)}  ┃");
                    text = $"You gained {monster.Exp} Exp and {monster.Gold} gold!";
                    Console.WriteLine($"\t┃ {text.PadRight(39)}  ┃");
                    player.Exp += monster.Exp;
                    player.Gold += monster.Gold;

                    if (player.Exp >= player.MaxExp)
                    {
                        Console.WriteLine("\t┃ Well Done! You leveled up!               ┃");
                        player.LevelUp();
                    }

                    Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                }
                else
                {
                    player.Hp -= monster.Attack();
                    if (player.Hp <= 0)
                    {
                        text = $"You were defeated by { monster.Name}!";
                        Console.WriteLine($"\t┃ {text.PadRight(39)}  ┃");
                        Console.WriteLine($"\t┃ You lose...                              ┃");
                        Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                        Console.WriteLine("\n\t Do you want to try again? (y/n)");
                        Console.Write("\t > ");
                        string choice = Utility.ReadInGreen();
                        if (choice.ToLower() == "y")
                        {
                            StartGame();
                        }
                        else
                        {
                            ExitGame();
                        }
                    }
                    else
                    {
                        Console.Write($"\t┃ {player.Name} Hp: ");
                        text = player.Hp.ToString().PadRight(34 - player.Name.Length);
                        if (player.Hp < player.MaxHp / 5)
                        {
                            Utility.WriteInRed(text);
                        }
                        else
                        {
                            Console.Write(text);
                        }
                        Console.WriteLine("  ┃");
                        Console.WriteLine($"\t┃ {monster.Name} Hp: {monster.Hp.ToString().PadRight(34 - monster.Name.Length)}  ┃");
                        Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                    }
                }
                Console.WriteLine("\t[Press enter to continue]");
                Console.ReadLine();
            }
        }

        private void ShowDetails()
        {
            Console.WriteLine();
            Console.WriteLine($"\t┏━DETAILS━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.Write($"\t┃ Name: ");
            Utility.WriteInYellow(player.Name.PadRight(38));
            Console.WriteLine("  ┃");
            Console.Write($"\t┃ Level: ");
            Utility.WriteInYellow(player.Level.ToString().PadRight(37));
            Console.WriteLine("  ┃");
            Console.Write($"\t┃ Hp: ");
            Utility.WriteInYellow(player.Hp.ToString());
            Console.Write("/");

            int hp = player.Hp;
            int a = hp > 9 && hp < 100 ? 1 : hp > 99 && hp < 1000 ? 2 : hp > 999 ? 3 : 0;
            Utility.WriteInYellow(player.MaxHp.ToString().PadRight(38 - a));
            Console.WriteLine("  ┃");
            Console.Write($"\t┃ Exp: ");
            Utility.WriteInYellow(player.Exp.ToString());
            Console.Write("/");

            int xp = player.Exp;
            int b = xp > 9 && xp < 100 ? 1 : xp > 99 && xp < 1000 ? 2 : xp > 999 && xp < 10000 ? 3 : xp > 9999 ? 4 : 0;
            Utility.WriteInYellow(player.MaxExp.ToString().PadRight(37 - b));
            Console.WriteLine("  ┃");
            Console.Write($"\t┃ Damage: ");
            Utility.WriteInYellow(player.Damage.ToString().PadRight(36));
            Console.WriteLine("  ┃");
            Console.Write($"\t┃ Gold: ");
            Utility.WriteInYellow(player.Gold.ToString().PadRight(38));
            Console.WriteLine("  ┃");
            Console.WriteLine($"\t┣━EQUIPPED━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┫");

            string text;
            if (player.Armor != null)
            {
                text = player.Armor.ToString();
            }
            else
            {
                text = new string(' ', 37);
            }
            Console.Write($"\t┃ Armor: ");
            Utility.WriteInYellow(text.PadRight(37));
            Console.WriteLine("  ┃");
            if (player.Weapon != null)
            {
                text = player.Weapon.ToString();
            }
            else
            {
                text = new string(' ', 36);
            }
            Console.Write($"\t┃ Weapon: ");
            Utility.WriteInYellow(text.PadRight(36));
            Console.WriteLine("  ┃");
            Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
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
                Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ 1. Rest for the night for 100 gold (+ 100% Hp)  ┃");
                Console.WriteLine("\t┃ 2. Eat and drink 60 gold (+ 50% Hp)             ┃");
                Console.WriteLine("\t┃ 3. Purchase or sell items                       ┃");
                Console.WriteLine("\t┃ 4. Leave                                        ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.Write("\t > ");
                int.TryParse(Utility.ReadInGreen(), out int choice);
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
                Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ 1. Buy Armor    ┃");
                Console.WriteLine("\t┃ 2. Buy Weapons  ┃");
                Console.WriteLine("\t┃ 3. Buy Potions  ┃");
                Console.WriteLine("\t┃ 4. Sell items   ┃");
                Console.WriteLine("\t┃ 5. Leave        ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━┛");
                Console.Write("\t > ");
                int.TryParse(Utility.ReadInGreen(), out int choice);
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
            Console.WriteLine($"\t┏━ARMOR━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"\t┃ Nr:   Name:                   Cost:   Hp:   ┃");
            for (int i = 0; i < armor.Length; i++)
            {
                Console.WriteLine($"\t┃ {i + 1}.\t{armor[i].Name.PadRight(24)}{armor[i].Cost.ToString().PadRight(8)}+{armor[i].MaxHp.ToString().PadRight(3)}  ┃");
            }
            Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n\t What weapon do you want to buy?");
                Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ 1. Dagger Damage 10. Cost: 50 gold         ┃");
                Console.WriteLine("\t┃ 2. Rusty sword Damage 20. Cost: 100 gold   ┃");
                Console.WriteLine("\t┃ 3. Broad sword Damage 50. Cost: 200 gold   ┃");
                Console.WriteLine("\t┃ 4. Sell all items                          ┃");
                Console.WriteLine("\t┃ 5. Leave                                   ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.Write("\t > ");
                int.TryParse(Utility.ReadInGreen(), out int choice);
                switch (choice)
                {
                    case 1:
                        if (player.Gold >= 50)
                        {
                            player.Gold -= 50;
                            // Equip(); leta upp metoden för att lägga till skada från dagger.
                        }
                        else
                        {
                            Console.WriteLine("\t Sorry! You don't have enough gold...\n");
                        }
                        break;
                    case 2:
                        if (player.Gold >= 100)
                        {
                            player.Gold -= 100;
                            // Equip(); leta upp metoden för att lägga till weapon.
                        }
                        else
                        {
                            Console.WriteLine("\t Sorry! You don't have enough gold...\n");
                        }
                        break;
                    case 3:
                        if (player.Gold >= 200)
                        {
                            player.Gold -= 200;
                            // Equip(); leta upp metoden för att lägga till skada från dagger.
                        }
                        else
                        {
                            Console.WriteLine("\t Sorry! You don't have enough gold...\n");
                        }
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