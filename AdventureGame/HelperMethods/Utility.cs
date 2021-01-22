using AdventureGame.Characters;
using AdventureGame.Interfaces;
using AdventureGame.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureGame.HelperMethods
{
    static class Utility
    {
        static readonly Random random = new Random();

        public static int RollDice(int dice)
        {
            return random.Next(dice);
        }

        public static int RollDice(string dice)
        {
            int times = int.Parse(dice[0].ToString());
            int sides = int.Parse(dice[2..]);
            int result = 0;
            for (int i = 0; i < times; i++)
            {
                result += random.Next(1, sides + 1);
            }
            return result;
        }

        // [HÅKAN] Ge alla fiender balanserad armor 
        public static List<Enemy> GetEnemies()
        {
            List<Enemy> monsters = new List<Enemy>()
              {
                new Enemy("Kisame", 1, 10, "1d4", 50),
                new Enemy("Kabuto", 1, 10, "1d4", 50),
                new Enemy("Obito", 1, 10, "1d4", 50),
                new Enemy("Madara", 1, 10, "1d4", 50),
                new Enemy("Ginkaku", 2, 20, "2d4", 100),
                new Enemy("Kimimaro", 3, 30, "2d6", 150),
                new Enemy("Deidara", 4, 40, "2d8", 200),
                new Enemy("Kakuzu", 5, 60, "2d10", 250),
                new Enemy("Hanzo", 6, 80, "3d8", 300),
                new Enemy("Orochimaru", 7, 25, "3d10", 350),
                new Enemy("Nagato", 8, 200, "2d16", 400),
                new Enemy("Haku", 9, 250, "3d16", 450)
              };
            return monsters;


        }

        // Lägg i Draw-klassen
        public static void PrintWithFrame(string title, string[] content)
        {
            List<int> lengths = new List<int>();
            foreach (var item in content)
            {
                int length = item.Length;
                if (item.Contains("[magenta]"))
                {
                    length -= 19;
                }
                lengths.Add(length);
            }
            int width = lengths.OrderByDescending(s => s).First();

            ColorConsole.WriteEmbeddedColor($"\t┏━{title}");
            if (title.Contains("[darkcyan]"))
            {
                for (int i = 0; i < width - title.Length + 23; i++)
                {
                    Console.Write("━");
                }
            }
            else if (title.Contains("[red]"))
            {
                for (int i = 0; i < width - title.Length + 13; i++)
                {
                    Console.Write("━");
                }
            }
            else if (title.Contains("[magenta]"))
            {
                for (int i = 0; i < width - title.Length + 21; i++)
                {
                    Console.Write("━");
                }
            }
            else
            {
                for (int i = 0; i < width - title.Length + 2; i++)
                {
                    Console.Write("━");
                }
            }
            Console.WriteLine("┓");
            foreach (string text in content)
            {
                if (text.Contains("[red]"))
                {
                    ColorConsole.WriteEmbeddedColorLine($"\t┃ {text.PadRight(width + 11)}  ┃");
                }
                else if (text.Contains("[yellow]"))
                {
                    ColorConsole.WriteEmbeddedColorLine($"\t┃ {text.PadRight(width + 17)}  ┃");
                }
                else if (text.Contains("[magenta]"))
                {
                    ColorConsole.WriteEmbeddedColorLine($"\t┃ {text.PadRight(width + 19)}  ┃");
                }
                else
                {
                    Console.WriteLine($"\t┃ {text.PadRight(width)}  ┃");
                }
            }
            Console.Write("\t┗");
            for (int i = 0; i < width + 3; i++)
            {
                Console.Write("━");
            }
            Console.WriteLine("┛");

        }

        // Lägg i Draw-klassen
        public static void PrintWithDividedFrame(string title1, string[] texts1, string title2, string[] texts2, int width)
        {
            ColorConsole.WriteEmbeddedColor($"\t┏━{title1}");
            for (int i = 0; i < width - title1.Length + 2 + 21; i++)
            {
                Console.Write("━");
            }
            Console.WriteLine("┓");
            foreach (string text in texts1)
            {
                if (text.Contains("[yellow]"))
                {
                    ColorConsole.WriteEmbeddedColorLine($"\t┃ {text.PadRight(width + 17)}  ┃");
                }
                else
                {
                    Console.WriteLine($"\t┃ {text.PadRight(width)}  ┃");
                }
            }
            Console.Write($"\t┣━{title2}");
            for (int i = 0; i < width - title2.Length + 2; i++)
            {
                Console.Write("━");
            }
            Console.WriteLine("┫");
            foreach (string text in texts2)
            {
                if (text.Contains("yellow"))
                {
                    ColorConsole.WriteEmbeddedColorLine($"\t┃ {text.PadRight(width + 17)}  ┃");
                }
                else
                {
                    Console.WriteLine($"\t┃ {text.PadRight(width)}  ┃");
                }
            }
            Console.Write("\t┗");
            for (int i = 0; i < width + 3; i++)
            {
                Console.Write("━");
            }
            Console.WriteLine("┛");

        }

        public static void TypeOverWrongDoings() // Lägg i Draw-klassen
        {

        }

        internal static Armor[] GetArmors()
        {
            Armor[] armor = new Armor[]
            {
                new Armor("Flak Jacket", 100, 15),
                new Armor("Steam Armour", 200, 20),
                new Armor("Shinobi Battle Armour", 500, 50),
                new Armor("Chakra Armour", 2000, 75),
                new Armor("Infinite Armour", 5000, 100)
            };
            return armor;
        }

        public static Weapon[] GetWeapons()
        {
            Weapon[] weapons = new Weapon[]
            {
                new Weapon("Kunai", 150, "1d6"),
                new Weapon("Shuriken", 250, "1d8"),
                new Weapon("Bow & Arrow", 500, "1d10"),
                new Weapon("Crossbow", 750, "1d12"),
                new Weapon("Tekagi-Shuko", 1000, "2d6"),
                new Weapon("Chakra Blade", 1500, "2d8"),
                new Weapon("Spear", 2000, "2d10"),
                new Weapon("Sword", 2500, "2d12")
            };
            return weapons;

            // Seven Swordsmen of the Mist vapen:
            // Kiba, Kubikiribōchō, Nuibari, Samehada, Shibuki, Hiramekarei, Kabutowari
        }

        public static Potion[] GetPotions()
        {
            Potion[] potions = new Potion[]
            {
                new Potion("Powerking", 15, 5, ""),
                new Potion("Red Bull", 30, 20, "\t You drink a powerfull potion that gives you wings.")
            };
            return potions;

        }



        public static void PrintMap() // Lägg den här metoden i Draw-klassen
        {
            Console.WriteLine();
            int mapTop = Console.CursorTop;
            Console.WriteLine("\t┏━MAP━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]AAA AAA AAA AAA  AAA  AAA[/darkgray]  [red]X[/red]   [darkgray]AAA AAA AAA A A AAA AAA AA AAA AA AAA AAAA A AA[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]A AAA  AAA AAA AAA AAAAA      AA A AA AAA AAA AAA AAA AAA A AAA A AAA AA AAA A[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]AA[/darkgray] [darkcyan]S[/darkcyan]           [darkgray]AAA A AAA      AAA AAA AAA AAA AAA AAA AAA AAA AAA AA A AAA AAA[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]AA              AA AAA AAAA                                               AAAA[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]AA AAA A AA     A AAA AA AA                                                 AA[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]AA A AAA AAA     AA AA AAA AAA AA AAA     A AA AAA AA AAA AA AAA AAAA      AAA[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]A AAA AAA AAA     AA AAAA AA AAA A AA     AA A AA AAA A AAA AA A AAA        AA[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]A AA AAA A AA                            AAA AA AA[/darkgray] [blue]≈≈≈≈≈≈≈[/blue][darkgray] A AA AAA          A[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]AA AAA A AA A                             AA AAAA[/darkgray][blue] ≈≈≈≈≈≈≈≈≈[/blue] [magenta]δ[/magenta]               [darkgray]AA[/darkgray]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]A[/darkgray] [yellow]Ω[/yellow]    [darkgray]AA A AA[/darkgray]     [blue]≈≈≈≈≈[/blue]      [darkgreen]### ##       # ### #[/darkgreen] [blue]≈≈≈≈≈≈≈≈≈[/blue]                [darkgreen]##[/darkgreen]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]AA     AA AA A[/darkgray]    [blue]≈≈≈≈≈≈≈≈[/blue]    [darkgreen]# ## ###     ### ## ###[/darkgreen] [blue]≈≈≈≈≈≈[/blue] [darkgreen]## ### ##      ##[/darkgreen]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgray]AA      AA AAA[/darkgray]     [blue]≈≈≈≈≈≈[/blue]      [darkgreen]# ### #     ### ## # #### ## # ### ## ##     ##[/darkgreen]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[green]##[/green]       [darkgray]AA A[/darkgray]       [blue]≈≈≈≈[/blue]     [darkgreen]  ## ###       ## ### # #### ## ### # ###      ##[/darkgreen]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]###                                                                         ##[/darkgreen]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]# ##                                                                         #[/darkgreen]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]# ### # ## # #### # ## ###[/darkgreen]        [darkgreen]# ### # ### ## ## # ###[/darkgreen]       ┼ ┼ ┼ ┼ ┼ ┼ ┼ ┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]# ### ### # ## # # ### # ##[/darkgreen]      [darkgreen]### ## # ### # ### ### ##[/darkgreen]       ┼ ┼ ┼ ┼ ┼ ┼ ┼┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]#### ### ## # #### ###[/darkgreen] ╔──────────────╗ [darkgreen]## ##### ## ### ##[/darkgreen]      ┼ ┼ ┼ ┼ ┼ ┼ ┼ ┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]##### ### ## ### ### #[/darkgreen] │ Leaf Village │ [darkgreen]# ### ## ### ## # #[/darkgreen]      ┼ ┼ ┼ ┼ ┼ ┼ ┼┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]###### ### ## # ## ###[/darkgreen] ╚──────────────╝  [darkgreen]### ## ### ## ### #[/darkgreen]                [yellow]Ω[/yellow] ┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]# ##### ## # ### # ##[/darkgreen] [darkgray]AAA AA A AAAA A AAA[/darkgray] [darkgreen]## ### # ### #### #[/darkgreen]                 ┃");
            ColorConsole.WriteEmbeddedColorLine("\t┃[darkgreen]### ## #### ######[/darkgreen] [darkgray]AAA AA AAAAA AAA AA AAAA[/darkgray] [darkgreen]# ### ## # ### ## #### ## ### ####[/darkgreen]┃");
            ColorConsole.WriteEmbeddedColorLine("\t┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.WriteLine("\t [Press enter to continue]");
            int mapBottom = Console.CursorTop;
            PrintPlayer(mapTop);
            Console.ReadLine();
            Console.SetWindowPosition(0, Console.CursorTop - 30);
            Console.SetCursorPosition(0, mapBottom);
        }

        private static void PrintPlayer(int mapTop) // [HÅKAN] Lägg den här metoden i Draw-klassen.
        {
            IPlayable player = Game.player; // [HÅKAN] lös ;)
            int left = 0;
            int top = mapTop;
            switch (player.Pos)
            {
                case -2.3:
                    left = 12;
                    top += 4;
                    break;
                case -2.2:
                    left = 13;
                    top += 10;
                    break;
                case -2.1:
                    left = 15;
                    top += 15;
                    break;
                case -1.3:
                    left = 21;
                    top += 4;
                    break;
                case -1.2:
                    left = 25;
                    top += 9;
                    break;
                case -1.1:
                    left = 25;
                    top += 15;
                    break;
                case 0.0:
                    left = 38;
                    top += 19;
                    break;
                case 0.1:
                    left = 38;
                    top += 15;
                    break;
                case 0.2:
                    left = 36;
                    top += 9;
                    break;
                case 0.3:
                    left = 38;
                    top += 5;
                    break;
                case 0.4:
                    left = 36;
                    top += 2;
                    break;
                case 1.1:
                    left = 49;
                    top += 15;
                    break;
                case 1.2:
                    left = 48;
                    top += 9;
                    break;
                case 1.3:
                    left = 48;
                    top += 5;
                    break;
                case 2.0:
                    left += 72;
                    top += 21;
                    break;
                case 2.1:
                    left = 69;
                    top += 15;
                    break;
                case 2.2:
                    left = 70;
                    top += 10;
                    break;
                case 2.3:
                    left = 65;
                    top += 5;
                    break;
                case 3.0:
                    left += 85;
                    top += 21;
                    break;
                case 3.1:
                    left = 82;
                    top += 15;
                    break;
                case 3.2:
                    left = 82;
                    top += 10;
                    break;
                case 3.3:
                    left = 80;
                    top += 5;
                    break;
                default:
                    break;
            }
            Console.SetCursorPosition(left, top);
            ColorConsole.WriteInRed("*");
        }
    }
}
