using AdventureGame.Characters;
using AdventureGame.Creatures;
using AdventureGame.Items;
using System;
using System.Collections.Generic;

namespace AdventureGame.HelperMethods
{
    //public enum Races : int
    //{
    //    
    //}

    //public enum Classes : int
    //{
    //    Barbarian = 1
    //}

    static class Utility
    {
        static readonly Random random = new Random();

        public static int RollDice(int dice)
        {
            return random.Next(dice);
        }

        public static List<Monster> GetMonsters()
        {
            List<Monster> monsters = new List<Monster>()
            {
                new Monster("Frogman", 1, 15, 7, 50)
            };
            return monsters;
        }

        public static string ReadInGreen()
        {
            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            return input;
        }

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
