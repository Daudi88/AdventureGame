using AdventureGame.Creatures;
using System;
using System.Threading;

namespace AdventureGame.HelperMethods
{
    static class Draw
    {
        public static void MovingTitle()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.Write("\n\t\t\t");
            string text = "Welcome to the";
            Delayed(text);
            Console.WriteLine();

            int top = 2;
            int left = 8;
            int ctr = 0;

            string a = " ▐▄▐ ▄███▀▄ ▀  ▄▀▀   ██▐▀   ▌ ";
            string d = " █▐█▀▄███▀▄   ▀▄   ▀▄█▐█▀ ███   ▌  ";
            string v = "  ▐  ▌███   ▐█▀▐███  ▌   ";
            string e = "▄▀▐▐ ▄▄▀█▀▄ ▀▄▀ ▀ ▄▀  ▄▌ ";
            string n = "  ▐█▀▐███▀ ▌▐▐ ▄▐▐██ █▌▌ ";
            string t = "▄    ▄█▐▐▀▄███▀▄  ▌▀▄    ";
            string u = "▄██▐   ▌█▀ █▐▄▀▄███▀▌▌▌▌ ";
            string r = "▄▀▐▐ ▄▄▀█▀▄ ▀   █▄█    ▌▀";
            string space = "                    ";
            string g = " ▐▄▐ ▄███▀▄  ▄▀ ▀▀ ▀  █▐▀  ▄█ ";
            string m = "  ▐█▀ ███▀▌█     ▌█ ▄▐▐██ █▌▌  █▐▐▀ ███▀   ▌▀";

            string[] title = new string[] { a, d, v, e, n, t, u, r, e, space, g, a, m, e };
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var letter in title)
            {
                for (int i = 0; i < letter.Length; i++)
                {
                    ctr++;
                    Console.SetCursorPosition(left, top++);
                    Console.Write(letter[i]);
                    Thread.Sleep(1);
                    if (ctr % 10 == 5)
                    {
                        ctr = 0;
                        top = 2;
                        left++;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n\t\t\t\t\t");
            text = "An adventure like never before...";
            Delayed(text);
            Thread.Sleep(1000);
            Console.WriteLine("\n\n\t[Press enter to continue]");
            Console.ReadLine();
        }

        public static void Title()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine("\n\t\t\tWelcome to the");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t ▄▄▄   ▄▄▄▄   ▌ ▐ ▄▄▄   ▐ ▄ ▄▄▄▄▄▄  ▄▌▄▄▄  ▄▄▄       ▄▄    ▄▄▄    ▌ ▄    ▄▄▄");
            Console.WriteLine("\t▐█ ▀█ ██  ██  █ █▌▀▄ ▀  █▌▐█ ██  █ ██▌▀▄ █ ▀▄ ▀     ▐█ ▀  ▐█ ▀█  ██ ▐███ ▀▄ ▀");
            Console.WriteLine("\t▄█▀▀█ ▐█  ▐█▌▐█▐█ ▐▀▀ ▄▐█▐▐▌ ▐█  █▌▐█▌▐▀▀▄ ▐▀▀ ▄    ▄█ ▀█▄▄█▀▀█ ▐█ ▌▐▌▐█ ▐▀▀ ▄");
            Console.WriteLine("\t▐█  ▐▌██  ██  ███ ▐█▄▄▌██▐█▌ ▐█▌ ▐█▄█▌▐█ █▌▐█▄▄▌    ▐█▄ ▐█▐█  ▐▌██ ██▌▐█▌▐█▄▄▌");
            Console.WriteLine("\t ▀  ▀ ▀▀▀▀▀    ▀   ▀▀▀ ▀▀ █  ▀▀▀  ▀▀▀  ▀  ▀ ▀▀▀      ▀▀▀▀  ▀  ▀ ▀▀  █ ▀▀▀ ▀▀▀");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\tAn adventure like never before...\n");
        }

        private static void Delayed(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(50);
            }
        }

        //private const int width = 79;

        //public static void CharaterCreation()
        //{
        //    Top("CARACTER CREATION");
        //    Sides(15);
        //    Bottom();
        //}

        //public static void MainMenu()
        //{
        //    Top();
        //    Sides(6);
        //    Bottom();
        //}

        //public static void CharacterPanel(Player player)
        //{
        //    Top("CHARACTER");
        //    Sides(7);
        //    DividingLine("ABILITIES");
        //    Sides(7);
        //    DividingLine("WEAPON");
        //    Sides(2);
        //    DividingLine("ARMOR");
        //    Sides(3);
        //    Bottom();
        //}

        //private static void Top()
        //{
        //    Console.Write("\t\u2554");
        //    for (int i = 0; i < width; i++)
        //    {
        //        Console.Write("\u2550");
        //    }
        //    Console.WriteLine("\u2557");
        //}

        //private static void Top(string text)
        //{
        //    Console.Write($"\t\u2554\u2550{text}");
        //    for (int i = 0; i < width - text.Length - 1; i++)
        //    {
        //        Console.Write("\u2550");
        //    }
        //    Console.WriteLine("\u2557");
        //}

        //private static void TopDivided(string text)
        //{
        //    Console.Write($"\n\t\u2554\u2550{text}");
        //    for (int i = 0; i < width / 2 - text.Length - 1; i++)
        //    {
        //        Console.Write("\u2550");
        //    }
        //    Console.Write("\u2566");
        //    for (int i = 0; i < width / 2; i++)
        //    {
        //        Console.Write("\u2550");
        //    }
        //    Console.WriteLine("\u2557");
        //}

        //private static void Sides(int height)
        //{
        //    for (int i = 0; i < height; i++)
        //    {
        //        Console.Write("\t\u2551");
        //        for (int j = 0; j < width; j++)
        //        {
        //            Console.Write(" ");
        //        }
        //        Console.WriteLine("\u2551");
        //    }
        //}

        //private static void SidesDivided(int height)
        //{
        //    for (int i = 0; i < height; i++)
        //    {
        //        Console.Write("\t\u2551");
        //        for (int j = 0; j < width / 2; j++)
        //        {
        //            Console.Write(" ");
        //        }
        //        Console.Write("\u2551");
        //        for (int j = 0; j < width / 2; j++)
        //        {
        //            Console.Write(" ");
        //        }
        //        Console.WriteLine("\u2551");
        //    }
        //}

        //private static void Bottom()
        //{
        //    Console.Write("\t\u255A");
        //    for (int i = 0; i < width; i++)
        //    {
        //        Console.Write("\u2550");
        //    }
        //    Console.WriteLine("\u255D");
        //}

        //private static void DividingLine()
        //{
        //    Console.Write("\t\u2560");
        //    for (int i = 0; i < width; i++)
        //    {
        //        Console.Write("\u2550");
        //    }
        //    Console.WriteLine("\u2563");
        //}

        //private static void DividingLine(string text)
        //{
        //    Console.Write($"\t\u2560\u2550{text}");
        //    for (int i = 0; i < width - text.Length - 1; i++)
        //    {
        //        Console.Write("\u2550");
        //    }
        //    Console.WriteLine("\u2563");
        //}
    }
}
