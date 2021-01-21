using System;
using System.Threading;

namespace AdventureGame.HelperMethods
{
    static class Draw
    {
        public static void MovingTitle()
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

        public static void Title()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();
            Console.WriteLine("\t    ███        ▄█    █▄       ▄████████         ▄████████    ▄█    █▄     ▄█  ███▄▄▄▄    ▄██████▄  ▀█████████▄   ▄█  ");
            Console.WriteLine("\t▀█████████▄   ███    ███     ███    ███        ███    ███   ███    ███   ███  ███▀▀▀██▄ ███    ███   ███    ███ ███  ");
            Console.WriteLine("\t   ▀███▀▀██   ███    ███     ███    █▀         ███    █▀    ███    ███   ███▌ ███   ███ ███    ███   ███    ███ ███▌");
            Console.WriteLine("\t    ███   ▀  ▄███▄▄▄▄███▄▄  ▄███▄▄▄            ███         ▄███▄▄▄▄███▄▄ ███▌ ███   ███ ███    ███  ▄███▄▄▄██▀  ███▌ ");
            Console.WriteLine("\t    ███     ▀▀███▀▀▀▀███▀  ▀▀███▀▀▀          ▀███████████ ▀▀███▀▀▀▀███▀  ███▌ ███   ███ ███    ███ ▀▀███▀▀▀██▄  ███▌ ");
            Console.WriteLine("\t    ███       ███    ███     ███    █▄                ███   ███    ███   ███  ███   ███ ███    ███   ███    ██▄ ███  ");
            Console.WriteLine("\t    ███       ███    ███     ███    ███         ▄█    ███   ███    ███   ███  ███   ███ ███    ███   ███    ███ ███  ");
            Console.WriteLine("\t   ▄████▀     ███    █▀      ██████████       ▄████████▀    ███    █▀    █▀    ▀█   █▀   ▀██████▀  ▀█████████▀  █▀  ");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
