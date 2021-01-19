using AdventureGame.Creatures;
using AdventureGame.HelperMethods;
using System;
using System.Threading;
using System.Collections.Generic;
using AdventureGame.Characters;
using System.Dynamic;
using System.Xml.Linq;

namespace AdventureGame
{
    class Game
    {
        public static Player player;
        public void Setup()
        {
            Console.Title = "Adventure Game";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;
            //Draw.MovingTitle();
            StartGame();
        }

        private void StartGame()
        {
            Draw.Title();
            CharacterCreation();
            Run();
        }

        private void CharacterCreation()
        {
            player = new Player(35, 15);
            while (true)
            {
                Console.WriteLine("\n\tWhat is your name?");
                Console.Write("\t> ");
                player.Name = Utility.ReadInGreen();

                if (player.Name.Length < 3)
                {
                    Console.WriteLine("\tThe name is too short...");
                }
                else if (player.Name.Length > 12)
                {
                    Console.WriteLine("\tThe name is too long...");
                }
                else
                {
                    break;
                }
            }
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
                    default:
                        break;
                }
            }
        }

        private int MainMenu()
        {
            Console.WriteLine("\n       ┏━MENU━━━━━━━━━━━━┓");
            Console.WriteLine("       ┃ 1. Go Explore   ┃");
            Console.WriteLine("       ┃ 2. Show Details ┃");
            Console.WriteLine("       ┃ 3. Go to Tavern ┃");
            Console.WriteLine("       ┃ 4. Exit Game    ┃");
            Console.WriteLine("       ┗━━━━━━━━━━━━━━━━━┛");
            Console.Write("\t> ");
            int.TryParse(Utility.ReadInGreen(), out int choice);
            return choice;
        }

        private void Explore()
        {
            int chance = Utility.RollDice(10);
            if (chance == 0)
            {
                Console.WriteLine("\n\tThis is a very peacefull place and you don't sense any trouble near you.");
            }
            else
            {
                Battle();
            }
        }

        private void Battle()
        {
            List<Monster> monsters = Utility.GetMonsters();
            Monster monster = monsters[Utility.RollDice(monsters.Count)];

            Console.WriteLine("\n       ┏━BATTLE━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine($"       ┃ You have encountered {monster.Name}!");
            while (monster.Hp > 0)
            {
                monster.Hp -= player.Attack();
                if (monster.Hp <= 0)
                {
                    Console.WriteLine($"       ┃ You defeated {monster.Name}!");
                    Console.WriteLine($"       ┃ You gained {monster.Exp} Exp and {monster.Gold} gold!");
                    Console.WriteLine("       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    player.Exp += monster.Exp;
                    player.Gold += monster.Gold;

                    if (player.Exp >= player.MaxExp)
                    {
                        player.LevelUp();
                    }
                }
                else
                {
                    player.Hp -= monster.Attack();
                    if (player.Hp <= 0)
                    {
                        Console.WriteLine($"       ┃ You were defeated by {monster.Name}");
                        Console.WriteLine("       ┃ You loose...");
                        Console.WriteLine("       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                        Console.WriteLine("\n\tDo you want to try again? (y/n)");
                        Console.Write("\t> ");
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
                        Console.WriteLine($"       ┃ {player.Name} Hp: {player.Hp.ToString().PadRight(33 - player.Name.Length)} ┃");
                        Console.WriteLine($"       ┃ {monster.Name} Hp: {monster.Hp.ToString().PadRight(33 - monster.Name.Length)} ┃");
                        Console.WriteLine("       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                    }
                }
                Console.WriteLine("\t[Press enter to continue]");
                Console.ReadLine();
            }
        }

        private void ShowDetails()
        {
            int hp = player.Hp;
            int a = hp > 9 && hp < 100 ? 1 : hp > 99 ? 2 : 0;
            int xp = player.Exp;
            int b = xp > 9 && xp < 100 ? 1 : xp > 99 && xp < 1000 ? 2 : xp > 999 && xp < 10000 ? 3 : xp > 9999 ? 4 : 0;

            Console.WriteLine("\n       ┏━DETAILS━━━━━━━━━━━━┓");
            Console.WriteLine($"       ┃ Name: {player.Name.PadRight(12)} ┃");
            Console.WriteLine($"       ┃ Level: {player.Level.ToString().PadRight(11)} ┃");
            Console.WriteLine($"       ┃ Hp: {player.Hp}/{player.MaxHp.ToString().PadRight(12 - a)} ┃");
            Console.WriteLine($"       ┃ Exp: {player.Exp}/{player.MaxExp.ToString().PadRight(11 - b)} ┃");
            Console.WriteLine($"       ┃ Strength: {player.Strength.ToString().PadRight(8)} ┃");
            Console.WriteLine($"       ┃ Gold: {player.Gold.ToString().PadRight(12)} ┃");
            Console.WriteLine("       ┗━━━━━━━━━━━━━━━━━━━━┛");
        }

        private void Tavern()
        {
            Console.WriteLine("\n\tWelcome to the Barbarian Inn!");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\tWhat can we do for you?");
                Console.WriteLine("       ┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("       ┃ 1. Rest for the night for 100 gold (+ 100% Hp) ┃");
                Console.WriteLine("       ┃ 2. Eat and drink 60 gold (+ 50% Hp)            ┃");
                Console.WriteLine("       ┃ 3. Purchase or sell items                      ┃");
                Console.WriteLine("       ┃ 4. Leave                                       ┃");
                Console.WriteLine("       ┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                Console.Write("\t> ");
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
                            Console.WriteLine("\tSorry! You don't have enough gold...\n");
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
                            Console.WriteLine("\tSorry! You don't have enough gold...\n");
                        }
                        break;
                    case 3:
                        Shop();
                        break;
                    case 4:
                        Console.WriteLine("\tThank you for visiting! We hope to see you back again soon!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\tInvalid choice. Try again...\n");
                        break;
                }
            }
        }

        private void Rest()
        {
            Console.WriteLine("\tYou wake up the next day feeling well and rested.");
            Console.WriteLine("\tYour Hp is now fully restored.");
            player.Hp = player.MaxHp;
            Console.WriteLine("\t[Press enter to continue]");
            Console.ReadLine();
        }

        private void Eat()
        {
            Console.WriteLine("\tYou feel much better after a good meal.");
            Console.WriteLine("\tYour Hp is now restored by 50%.");
            player.Hp += player.MaxHp / 2;
            Console.WriteLine("\t[Press enter to continue]");
            Console.ReadLine();
        }

        private void Shop()
        {
            throw new NotImplementedException();
        }

        private static void ExitGame()
        {
            Console.Write("\n\tExiting game");
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