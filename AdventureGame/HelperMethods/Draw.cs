using System;
using System.Threading;

namespace AdventureGame.HelperMethods
{
    static class Draw
    {

        //const int left = 10;
        //public static void Menu()
        //{
        //    Top("MENU", 18);
        //    Sides(18, 4);
        //    Bottom(18);
        //    int top = 11;
        //    string[] text = new string[] 
        //    { 
        //        "1. Go Explore", 
        //        "2. Show Details", 
        //        "3. Go to Tavern", 
        //        "4. Exit Game" 
        //    };
        //    WriteAtPosition(text, top);
        //}

        //public static void Battle()
        //{
        //    Console.Clear();
        //    Title();
        //    Top("BATTLE", 42);
        //    Sides(42, 5);
        //    Bottom(42);
        //}

        //private static void WriteAtPosition(string[] text, int top)
        //{
        //    for (int i = 0; i < text.Length; i++)
        //    {
        //        Console.SetCursorPosition(left, top++);
        //        Console.Write(text[i]);
        //    }
            
        //}
        private static void Top(int width)
        {
            Console.Write("\t┏");
            for (int i = 0; i < width; i++)
            {
                Console.Write("━");
            }
            Console.WriteLine("┓");
        }
        private static void Top(string text, int width)
        {
            Console.Write($"\t┏━{text}");
            for (int i = 0; i < width - text.Length - 1; i++)
            {
                Console.Write("━");
            }
            Console.WriteLine("┓");
        }

        private static void Sides(int width, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.Write("\t┃");
                for (int j = 0; j < width; j++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("┃");
            }
        }

        private static void Bottom(int width)
        {
            Console.Write("\t┗");
            for (int i = 0; i < width; i++)
            {
                Console.Write("━");
            }
            Console.WriteLine("┛");
        }

        //private const int width = 79;

        //public static void CharaterCreation()
        //{
        //    Top("CARACTER CREATION");
        //    Sides(15);
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

        public static void MovingTitle()
        {
            Console.Clear();
            Console.Write("\n\t\t\t");
            string text = "Welcome to the";
            Delayed(text);
            Console.WriteLine();

            int top = 6;
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
                        top = 6;
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
    }
}
