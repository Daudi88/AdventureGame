using AdventureGame.Characters;
using AdventureGame.Items.Weapons;
using AdventureGame.Items.Armors;
using AdventureGame.Items.Potions;
using System;
using System.IO;
using System.Media;
using System.Threading;

namespace AdventureGame.Structure
{
    class Game
    {
        public static Player player;

        public void Setup()
        {
            Console.Title = "The Shinobi";
            Console.SetWindowSize(130, 75);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            var soundLocation = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\NarutoFinal.wav");
            SoundPlayer player = new SoundPlayer(soundLocation);
            player.PlayLooping();
            StartGame();
        }

        private static void StartGame()
        {
            Console.Clear();
            Display.Title();
            CharacterCreation();
            string[] content = new string[]
            {
                $"You, {player.Name} wake up in the Hidden Leaf Village and sense that something is wrong!",
                "Kaguya Otsutsuki have kidnapped Hanare and taken her to his cave in the mountains.",
                "It is your duty to find and rescue her!"
            };
            Display.Intro(content);
            Run();
        }

        private static void CharacterCreation()
        {
            player = new Player();
            Console.WriteLine("\n\t What is your name?");
            Console.Write("\t > ");
            while (true)
            {
                string name = ColorConsole.ReadInBlue();
                name = name.Trim();

                if (name.Length < 3)
                {
                    Utility.TypeOverWrongDoings("The name is too short. Try again!");
                }
                else if (name.Length > 12)
                {
                    Utility.TypeOverWrongDoings("The name is too long. Try again!");
                }
                else if (name.Trim().ToLower() == "robin")
                {
                    GodMode();
                    break;
                }
                else
                {
                    player.Name = name[0].ToString().ToUpper() + name[1..].ToLower();
                    player.Weapon = new Fists();
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
            player.Armor = new InfiniteArmor();
            player.Weapon = new Kubikiribōchō();
            Potion potion = new RedBull();
            potion.Quantity = 100;
            player.Backpack.Add(potion);
        }

        private static void Run()
        {
            while (true)
            {
                string[] content = new string[]
                {
                    "1. Go on an Adventure",
                    "2. Eat at Lightning Burger",
                    "3. Heal yourself at Konoha Hospital",
                    "4. Go to the Ninja Tool Shop",
                    "D. Show Details",
                    "B. Show Backpack",
                    "M. Show Map",
                    "E. Exit Game"
                };
                Console.WriteLine();
                Display.WithFrame("[darkcyan]MENU[/darkcyan]", content);
                Console.Write("\t > ");
                bool exit = false;
                while (!exit)
                {
                    string choice = ColorConsole.ReadInBlue();
                    switch (choice.ToUpper())
                    {
                        case "1":
                            Adventure.GoOnAdventure();
                            exit = true;
                            break;
                        case "2":
                            Locations.LightningBurger(player);
                            exit = true;
                            break;
                        case "3":
                            Locations.KonohaHospital(player);
                            break;
                        case "4":
                            Locations.NinjaToolShop(player);
                            break;
                        case "D":
                            Display.Details();
                            exit = true;
                            break;
                        case "B":
                            if (Display.Backpack())
                            {
                                exit = true;
                            }
                            break;
                        case "M":
                            Display.Map();
                            exit = true;
                            break;
                        case "E":
                            ExitGame();
                            exit = true;
                            break;
                        default:
                            Utility.TypeOverWrongDoings("Invalid choice. Try again!");
                            break;
                    } 
                }
            }
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