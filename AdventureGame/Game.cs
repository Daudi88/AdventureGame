using AdventureGame.Creatures;
using AdventureGame.HelperMethods;
using AdventureGame.Items;
using System;
using System.Collections.Generic;

namespace AdventureGame
{
    class Game
    {
        public static Player player;
        public void Setup()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Adventure Game";
            Console.CursorVisible = false;
        }

        public void Test()
        {
            //Draw.MovingTitle();
            player = Display.CharacterCreation();
            int choice = Display.MainMenu();
            if (choice == 2)
            {
                Display.CharacterPanel(player);
            }
            Display.MainMenu();
        }

    }
}