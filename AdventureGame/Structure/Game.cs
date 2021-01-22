using AdventureGame.Characters;
using AdventureGame.Items;
using System;
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

            var soundLocation = Environment.CurrentDirectory + @"C:\Orginal.wav";
            SoundPlayer player = new SoundPlayer(@"C:\Orginal.wav");
            player.Play();
            player.Play();            
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
                string choice = Display.MainMenu();
                switch (choice.ToUpper())
                {
                    case "1":
                        Adventure.GoOnAdventure();
                        break;
                    case "2":
                        Tavern.Inn(player);
                        break;
                    case "C":
                        Display.Details();
                        break;
                    case "B":
                        Display.Backpack();
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