using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AdventureGame.Characters;
using AdventureGame.Interfaces;
using AdventureGame.Items;
using AdventureGame.Items.Potions;

namespace AdventureGame.Structure

{
    class Display
    {
        public static void Title()
        {
            int top = 2;
            int left = 8;
            int ctr = 0;
            int keyCtr = 0;

            string t = " ▀       █       █       █▀    ▄████████████████████████ █▀    █ █▀    ▀ ██      ▄█▀    ";
            string h = "            ▀      ▄▀    ███████▄███████████████   ▄▀      ▄▀      ▄▀   ████████▄██████▀ ██████    ▄▀      ▄    ";
            string e = "            ▀      ▄▀    ███████▄████████████████  ▄▀  ██  ▄▀  ██  ▄▀  ████  █████▀  ▄████    ██";
            string space = "                                                ";
            string s = "            ▀       █  ▄ ████  █▄████ ▄██████ ███   █  ██   █  ██   █  ██   █  ████ ██████▀ ███▀██  ███ ";
            string i = "         ███████▄██████▀███████   ▌▌▌   ";
            string n = "        ███████ ███████▀████████▄▀      ▄▀      ▄▀      ▄███████ ██████▀ ▄█████ ";
            string o = "         ██████ ▄██████▀█████████      ██      ██      █████████▄██████▀ ██████ ";
            string b = "        ▀   ▀  ▀█  ▄▀  ██████████████████████████  ▄▀  ██  ▄▀  ██  ▄▀  ██  ██  █████████▄██▀▄██▀ ██  ▄█ ";
            string[] title = new string[] { t, h, e, space, s, h, i, n, o, b, i };
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (var letter in title)
            {
                for (int j = 0; j < letter.Length; j++)
                {
                    ctr++;
                    Console.SetCursorPosition(left, top++);
                    Console.Write(letter[j]);

                    if (Console.KeyAvailable)
                    {
                        keyCtr++;
                    }

                    if (keyCtr == 0)
                    {
                        Thread.Sleep(1);
                    }

                    if (ctr % 10 == 8)
                    {
                        ctr = 0;
                        top = 2;
                        left++;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static void Intro(string[] content)
        {
            int keyCtr = 0;
            for (int i = 0; i < content.Length; i++)
            {
                Console.Write("\n\t ");
                for (int j = 0; j < content[i].Length; j++)
                {
                    ColorConsole.WriteInYellow(content[i][j].ToString());
                    if (Console.KeyAvailable)
                    {
                        keyCtr++;
                    }

                    if (keyCtr == 0)
                    {
                        Thread.Sleep(40);
                    }                    
                }
            }
            Console.WriteLine();
        }

        public static void Details()
        {
            Player player = Game.player;
            Console.WriteLine();
            string[] content1 = new string[]
            {
                $"Name: [yellow]{player.Name}[/yellow]",
                $"Level: [yellow]{player.Level}[/yellow]",
                $"Hp: [yellow]{player.Hp}/{player.MaxHp}[/yellow]",
                $"Exp: [yellow]{player.Exp}/{player.MaxExp}[/yellow]",
                $"Damage: [yellow]{player.Damage}[/yellow]",
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
            Display.WithDividedFrame("[darkcyan]DETAILS[/darkcyan]", content1, "EQUIPPED", content2, longest.Length - 17);
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
            Console.SetWindowPosition(0, Console.CursorTop - 30);
        }

        public static bool Backpack(string str = null)
        {
            Player player = Game.player;
            if (player.Backpack.Count > 0)
            {
                bool exit = false;
                List<string> content = new List<string>();
                if (str == null)
                {
                    while (!exit)
                    {
                        content.Clear();
                        int ctr = 1;
                        foreach (var item in player.Backpack)
                        {
                            content.Add($"{ctr++}. [yellow]{item}[/yellow]");
                        }
                        content.Add($"E. Go back");
                        Console.WriteLine("\n\t What item do you want to use");
                        WithFrame("[darkcyan]BACKPACK[/darkcyan]", content.ToArray());
                        Console.Write("\t > ");
                        bool innerExit = false;
                        while (!innerExit)
                        {
                            string input = ColorConsole.ReadInBlue();
                            int.TryParse(input, out int choice);
                            if (choice > 0 && choice < player.Backpack.Count)
                            {
                                Item item = player.Backpack[choice - 1];
                                if (item is IEquipable equipable)
                                {
                                    equipable.Equip(player, equipable);

                                }
                                else if (item is IConsumable consumable)
                                {
                                    consumable.Consume(player);
                                    if (consumable is RedBull)
                                    {
                                        Adventure.isRedBull = true;
                                    }
                                }

                                item.Quantity--;
                                if (item.Quantity == 0)
                                {
                                    player.Backpack.Remove(item);
                                }
                                innerExit = true;
                            }
                            else if (input.ToUpper() == "E")
                            {
                                innerExit = true;
                                exit = true;
                            }
                            else
                            {
                                Utility.TypeOverWrongDoings("Invalid choice, try again!");
                            }
                        }                        
                        Console.SetWindowPosition(0, Console.CursorTop - 30);
                    }
                }
                else
                {
                    for (int i = 0; i < player.Backpack.Count; i++)
                    {
                        content.Add($"{i + 1}. [yellow]{player.Backpack[i]} {player.Backpack[i].Cost}[/yellow]");
                    }
                    Console.WriteLine("\n\t What item do you want to sell?");
                    // Skriv ut alla items i backpack
                }
                return true;
            }
            else
            {
                Utility.TypeOverWrongDoings("Your backpack is empty...");
                return false;
            }

        }

        public static void WithFrame(string title, string[] content)
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

        public static void WithDividedFrame(string title1, string[] texts1, string title2, string[] texts2, int width)
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

        public static void Map()
        {
            Console.WriteLine();
            int mapTop = Console.CursorTop;
            ColorConsole.WriteEmbeddedColorLine("\t┏━[darkcyan]MAP[/darkcyan]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
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
            int mapBottom = Console.CursorTop;
            PrintPlayer(mapTop);
            Console.SetCursorPosition(0, mapBottom);
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadKey(true);
            Console.SetWindowPosition(0, Console.CursorTop - 30);
        }
        private static void PrintPlayer(int mapTop)
        {
            Player player = Game.player;
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
            ColorConsole.WriteInRed("●");
        }

        public static void LoseScreen()
        {
            Console.WriteLine("\n\t Sorry, you lose...");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
            Game.PlayAgain();
        }

        public static void WinScreen()
        {
            Console.WriteLine("\n\t Yeay! You win!");
            Console.WriteLine("\t [Press enter to continue]");
            Console.ReadLine();
            Game.PlayAgain();
        }





    }
}
