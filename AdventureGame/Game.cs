using AdventureGame.Characters;
using AdventureGame.Creatures;
using AdventureGame.HelperMethods;
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
                Console.WriteLine("\n\t What is your name?");
                Console.Write("\t > ");
                player.Name = Utility.ReadInGreen();

                if (player.Name.Length < 3)
                {
                    Console.WriteLine("\t The name is too short...");
                }
                else if (player.Name.Length > 12)
                {
                    Console.WriteLine("\t The name is too long...");
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
            Console.WriteLine();
            Console.WriteLine("\t┏━MENU━━━━━━━━━━━━┓");
            Console.WriteLine("\t┃ 1. Go Explore   ┃");
            Console.WriteLine("\t┃ 2. Show Details ┃");
            Console.WriteLine("\t┃ 3. Go to Tavern ┃");
            Console.WriteLine("\t┃ 4. Exit Game    ┃");
            Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━┛");
            Console.Write("\t > ");
            int.TryParse(Utility.ReadInGreen(), out int choice);
            return choice;
        }

        private void Explore()
        {
            int chance = Utility.RollDice(10);
            if (chance == 0)
            {
                Console.WriteLine("\n\t This is a very peacefull place and you don't sense any trouble near you.");
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
            int ctr = 0;
            string text;
            while (monster.Hp > 0)
            {
                Console.WriteLine($"\n\t┏━BATTLE━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                if (ctr == 0)
                {
                    text = $"You have encountered {monster.Name}!";
                    Console.WriteLine($"\t┃ {text.PadRight(38)} ┃");
                    ctr++;
                }
                monster.Hp -= player.Attack();
                if (monster.Hp <= 0)
                {
                    text = $"You defeated {monster.Name}!";
                    Console.WriteLine($"\t┃ {text.PadRight(38)} ┃");
                    text = $"You gained {monster.Exp} Exp and {monster.Gold} gold!";
                    Console.WriteLine($"\t┃ {text.PadRight(38)} ┃");
                    Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
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
                        text = $"You were defeated by { monster.Name}!";
                        Console.WriteLine($"\t┃ {text.PadRight(38)} ┃");
                        Console.WriteLine($"\t┃ You loose...                           ┃");
                        Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                        Console.WriteLine("\n\t Do you want to try again? (y/n)");
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
                        Console.WriteLine($"\t┃ {player.Name} Hp: {player.Hp.ToString().PadRight(33 - player.Name.Length)} ┃");
                        Console.WriteLine($"\t┃ {monster.Name} Hp: {monster.Hp.ToString().PadRight(33 - monster.Name.Length)} ┃");
                        Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
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

            Console.WriteLine();
            Console.WriteLine($"\t┏━DETAILS━━━━━━━━━━━━┓");
            Console.WriteLine($"\t┃ Name: {player.Name.PadRight(12)} ┃");
            Console.WriteLine($"\t┃ Level: {player.Level.ToString().PadRight(11)} ┃");
            Console.WriteLine($"\t┃ Hp: {player.Hp}/{player.MaxHp.ToString().PadRight(12 - a)} ┃");
            Console.WriteLine($"\t┃ Exp: {player.Exp}/{player.MaxExp.ToString().PadRight(11 - b)} ┃");
            Console.WriteLine($"\t┃ Damage: {player.Damage.ToString().PadRight(8)} ┃");
            Console.WriteLine($"\t┃ Gold: {player.Gold.ToString().PadRight(12)} ┃");
            Console.WriteLine($"\t┣━EQUIPPED━━━━━━━━━━━┫");
            Console.WriteLine($"\t┃ Armor:             ┃");
            Console.WriteLine($"\t┃ Weapon:            ┃");
            Console.WriteLine($"\t┗━━━━━━━━━━━━━━━━━━━━┛");
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
                Console.WriteLine("\t┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("\t┃ 1. Rest for the night for 100 gold (+ 100% Hp) ┃");
                Console.WriteLine("\t┃ 2. Eat and drink 60 gold (+ 50% Hp)            ┃");
                Console.WriteLine("\t┃ 3. Purchase or sell items                      ┃");
                Console.WriteLine("\t┃ 4. Leave                                       ┃");
                Console.WriteLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
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
                Console.WriteLine("\n\t Welcome to the Abracapothecary!");
                Console.WriteLine("\t The shop that holds everything an adventurer could want.");
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