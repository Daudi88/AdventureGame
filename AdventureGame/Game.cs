using AdventureGame.Creatures;
using AdventureGame.HelperMethods;
using System;
using System.Threading;
using System.Collections.Generic;
using AdventureGame.Characters;

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
            Console.WriteLine("\n\tWhat is your name?");
            Console.Write("\t> ");
            player.Name = Utility.ReadInGreen();
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
                        Tavern();
                        break;
                    case 3:
                        ShowDetails();
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
            Console.WriteLine("\n\t1. Go Explore");
            Console.WriteLine("\t2. Go to Tavern");
            Console.WriteLine("\t3. Check Status");
            Console.WriteLine("\t4. Exit Game");
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
                
                //Console.WriteLine("\n\tYou take the time to drink a powerfull potion. It feels like you have wings."); => När man dricker en potion!
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
            Console.WriteLine($"\n\tYou have encountered {monster.Name}!");
            while (monster.Hp > 0)
            {
                monster.Hp -= player.Attack();
                if (monster.Hp <= 0)
                {
                    Console.WriteLine($"\tYou defeated {monster.Name}!");
                    Console.WriteLine($"\tYou gained {monster.Exp} Exp and {monster.Gold} gold!");
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
                        Console.WriteLine($"\tYou were defeated by {monster.Name}");
                        Console.WriteLine("\tYou loose...");
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
                        Console.WriteLine($"\tPlayer Hp: {player.Hp}");
                        Console.WriteLine($"\t{monster.Name} Hp: {monster.Hp}");
                    }
                }
                Console.WriteLine("\t[Press enter to continue]");
                Console.ReadLine();
            }
        }

        private void Tavern()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n\tWelcome to the Barbarian Inn!");
                Console.WriteLine("\tWhat can we do for you?");
                Console.WriteLine("\t1. Rest for the night");
                Console.WriteLine("\t2. Eat and drink");
                Console.WriteLine("\t3. Purchase or sell items");
                Console.WriteLine("\t4. Leave");
                Console.Write("\t> ");
                int.TryParse(Utility.ReadInGreen(), out int choice);
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\tInvalid choice. Try again...");
                        break;
                } 
            }
        }

        private void ShowDetails()
        {
            Console.WriteLine("\n\t***************");
            Console.WriteLine($"\t* Name: {player.Name}");
            Console.WriteLine($"\t* Level: {player.Level}");
            Console.WriteLine($"\t* Hp: {player.Hp}/{player.MaxHp}");
            Console.WriteLine($"\t* Exp: {player.Exp}/{player.MaxExp}");
            Console.WriteLine($"\t* Strength: {player.Strength}");
            Console.WriteLine($"\t* Gold: {player.Gold}");
            Console.WriteLine("\t***************");
            Console.ReadLine();
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