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

        public static void PrintWithFrame(string title, string[] content)
        {
            List<int> lengths = new List<int>();
            foreach (var item in content)
            {
                int length = item.Length;
                if (item.Contains("[yellow]"))
                {
                    length -= 17;
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

        public static void TypeOverWrongDoings()
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



        public static void PrintMap()
        {
            Console.WriteLine();
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
            Console.ReadLine();
        }

        //public enum Races : int
        //{
        //    
        //}

        //public enum Classes : int
        //{
        //    Barbarian = 1
        //}

        //public static Player GetClass(Classes choice)
        //{
        //    return choice switch
        //    {
        //        Classes.Barbarian => new Player("Barbarian", 14, "1d12", 15, 13, 14, 8, 12, 10),
        //        Classes.Bard => new Player("Bard", 9, "1d8", 8, 14, 13, 12, 10, 15),
        //        Classes.Cleric => new Player("Cleric", 10, "1d8", 12, 13, 14, 10, 15, 8),
        //        Classes.Druid => new Player("Druid", 10, "1d8", 10, 13, 14, 12, 15, 8),
        //        Classes.Fighter => new Player("Fighter", 12, "1d10", 15, 8, 14, 12, 10, 12),
        //        Classes.Monk => new Player("Monk", 10, "1d8", 12, 15, 14, 10, 12, 8),
        //        Classes.Paladin => new Player("Paladin", 11, "1d10", 15, 8, 13, 10, 12, 14),
        //        Classes.Ranger => new Player("Ranger", 12, "1d10", 10, 15, 14, 12, 13, 8),
        //        Classes.Rouge => new Player("Rogue", 10, "1d8", 8, 15, 14, 10, 13, 12),
        //        Classes.Sorcerer => new Player("Sorcerer", 8, "1d6", 8, 13, 14, 12, 10, 15),
        //        Classes.Warlock => new Player("Warlock", 10, "1d8", 8, 13, 14, 12, 10, 15),
        //        Classes.Wizard => new Player("Wizard", 8, "1d6", 8, 13, 14, 15, 12, 10),
        //        _ => throw new NotImplementedException()
        //    };
        //}

        //internal static void GetRace(Races choice, Player player)
        //{
        //    switch (choice)
        //    {
        //        case Races.Dwarf:
        //            player.Race = "Dwarf";
        //            player.Constitution += 2;
        //            player.Strength += 2;
        //            break;
        //        case Races.Elf:
        //            player.Race = "Elf";
        //            player.Dexterity += 2;
        //            player.Intelligence += 2;
        //            break;                
        //        case Races.Halfling:
        //            player.Race = "Halfling";
        //            player.Dexterity += 2;
        //            player.Constitution += 2;
        //            break;
        //        case Races.Human:
        //            player.Race = "Human";
        //            player.Strength++;
        //            player.Dexterity++;
        //            player.Constitution++;
        //            player.Intelligence++;
        //            player.Wisdom++;
        //            player.Charisma++;
        //            break;
        //        case Races.Dragonborn:
        //            player.Race = "Dragonborn";
        //            player.Strength += 2;
        //            player.Charisma++;
        //            break;
        //        case Races.Gnome:
        //            player.Race = "Gnome";
        //            player.Dexterity += 2;
        //            player.Intelligence += 2;
        //            break;
        //        case Races.HalfElf:
        //            player.Race = "half-Elf";
        //            player.Charisma += 2;
        //            player.Dexterity++;
        //            player.Constitution++;
        //            break;
        //        case Races.HalfOrc:
        //            player.Race = "Half-Orc";
        //            player.Strength += 2;
        //            player.Constitution++;
        //            break;
        //        case Races.Tiefling:
        //            player.Race = "Tiefling";
        //            player.Intelligence++;
        //            player.Charisma += 2;
        //            break;
        //        default:
        //            throw new NotImplementedException();
        //    }
        //}

        //public static int RollDice(string dice)
        //{
        //    int.TryParse(dice[0].ToString(), out int times);
        //    int.TryParse(dice[2..], out int sides);
        //    int result = 0;
        //    for (int i = 0; i < times; i++)
        //    {
        //        result += random.Next(1, sides + 1);
        //    }
        //    return result;
        //}

        //public static int GetAbilityModifier(int ability)
        //{
        //    switch (ability)
        //    {
        //        case 1:
        //            return -5;
        //        case 2:
        //        case 3:
        //            return -4;
        //        case 4:
        //        case 5:
        //            return -3;
        //        case 6:
        //        case 7:
        //            return -2;
        //        case 8:
        //        case 9:
        //            return -1;
        //        case 10:
        //        case 11:
        //            return 0;
        //        case 12:
        //        case 13:
        //            return 1;
        //        case 14:
        //        case 15:
        //            return 2;
        //        case 16:
        //        case 17:
        //            return 3;
        //        case 18:
        //        case 19:
        //            return 4;
        //        case 20:
        //        case 21:
        //            return 5;
        //        case 22:
        //        case 23:
        //            return 6;
        //        case 24:
        //        case 25:
        //            return 7;
        //        case 26:
        //        case 27:
        //            return 8;
        //        case 28:
        //        case 29:
        //            return 9;
        //        case 30:
        //            return 10;
        //        default:
        //            return 0;
        //    };
        //}

        //public static int GetProficiencyBonus(int level)
        //{
        //    switch (level)
        //    {
        //        case 1:
        //        case 2:
        //        case 3:
        //        case 4:
        //            return 2;
        //        case 5:
        //        case 6:
        //        case 7:
        //        case 8:
        //            return 3;
        //        case 9:
        //        case 10:
        //        case 11:
        //        case 12:
        //            return 4;
        //        default:
        //            return 0;
        //    }
        //}        

        //public static List<Armor> GetArmors(Player player)
        //{
        //    List<Armor> armors = new List<Armor>()
        //    {
        //        new Armor("Padded Armor", 5, 2, 11, "Chest", GetAbilityModifier(player.Dexterity), "Dex")
        //    };
        //    return armors;
        //}

        //public static List<Weapon> GetWeapons(Player player)
        //{
        //    List<Weapon> weapons = new List<Weapon>()
        //    {
        //        new Weapon("Handaxe", 5, 2, "1d6", GetAbilityModifier(player.Strength), "Str")
        //    };
        //    return weapons;
        //}

        //public static void GodMode(Player player)
        //{
        //    player.Strength = 30;
        //    player.Dexterity = 30;
        //    player.Constitution = 30;
        //    player.Intelligence = 30;
        //    player.Wisdom = 30;
        //    player.Charisma = 30;
        //    player.Gold = 100000;
        //    player.HitPoints = 1000;
        //    player.MaxHp = 1000;
        //    player.Class = "Priest";
        //    player.Race = "Night elf";
        //    player.Weapon = new Weapon("Greatsword", 50, 6, "2d6", GetAbilityModifier(player.Strength), "Str");
        //    player.Armor.Add(new Armor("Plate", 1500, 65, 18, "Chest", 0, ""));            
        //    player.ArmorClass = 18;
        //}
    }
}
