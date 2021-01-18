using AdventureGame.Creatures;
using AdventureGame.Items;
using System;
using System.Threading;

namespace AdventureGame.HelperMethods
{
    class Display
    {
        private const int left = 10;
        private static int top;

        public static Player CharacterCreation()
        {
            Console.Clear();
            Draw.Title();
            Draw.CharaterCreation();
            top = 10;
            AtPosition("Choose a class:");
            AtPosition("[1] Barbarian  [2] Bard       [3] Cleric    [4] Druid");
            AtPosition("[5] Fighter    [6] Monk       [7] Paladin   [8] Ranger");
            AtPosition("[9] Rouge      [10] Sorcerer  [11] Warlock  [12] Wizard");
            AtPosition("> ");
            int.TryParse(Utility.ReadInGreen(), out int choice);
            Player player = Utility.GetClass((Classes)choice);

            top++;
            AtPosition("Choose a race:");
            AtPosition("[1] Dwarf       [2] Elf    [3] Halfling  [4] Human");
            AtPosition("[5] Dragonborn  [6] Gnome  [7] Half-Elf  [8] Half-Orc  [9] Tiefling");
            AtPosition("> ");
            int.TryParse(Utility.ReadInGreen(), out choice);
            Utility.GetRace((Races)choice, player);

            top++;
            AtPosition("What is your name?");
            AtPosition("> ");
            string name = Utility.ReadInGreen();
            player.Name = char.ToUpper(name[0]) + name[1..].ToLower();
            if (player.Name == "Robin" || player.Name == "Daudi")
            {
                Utility.GodMode(player);
            }

            top++;
            AtPosition($"Welcome {player.Name}, the {player.Race} {player.Class}!");
            Thread.Sleep(2000);
            return player;
        }

        public static void AtPosition(string text)
        {
            Console.SetCursorPosition(left, top++);
            Console.Write(text);
        }

        public static int MainMenu()
        {
            Console.Clear();
            Draw.Title();
            Draw.MainMenu();
            top = 10;
            AtPosition("What do you want to do?");
            AtPosition("1. Go adventuring");
            AtPosition("2. Show details about your character");
            AtPosition("3. Go to shop");
            AtPosition("4. Exit game");
            AtPosition("> ");
            int.TryParse(Utility.ReadInGreen(), out int choice);
            return choice;
        }
        public static void CharacterPanel(Player player)
        {
            Console.Clear();
            Draw.Title();
            Draw.CharacterPanel(player);
            top = 10;
            AtPosition($"{player.Name} the {player.Race} {player.Class}");
            AtPosition($"Level: {player.Level}");
            AtPosition($"Exp: {player.ExperiencePoints}/{player.MaxExp}");
            AtPosition($"Armor Class: {player.ArmorClass}");
            AtPosition($"Hit Points: {player.HitPoints}/{player.MaxHp}");
            AtPosition($"Gold: {player.Gold}");

            top += 2;
            AtPosition($"Strength {player.Strength} ({(Utility.GetAbilityModifier(player.Strength) < 0 ? "" : "+") + Utility.GetAbilityModifier(player.Strength)})");
            AtPosition($"Dextrerity {player.Dexterity} ({(Utility.GetAbilityModifier(player.Dexterity) < 0 ? "" : "+") + Utility.GetAbilityModifier(player.Dexterity)})");
            AtPosition($"Constitution {player.Constitution} ({(Utility.GetAbilityModifier(player.Constitution) < 0 ? "" : "+") + Utility.GetAbilityModifier(player.Constitution)})");
            AtPosition($"Intelligence {player.Intelligence} ({(Utility.GetAbilityModifier(player.Intelligence) < 0 ? "" : "+") + Utility.GetAbilityModifier(player.Intelligence)})");
            AtPosition($"Wisdom {player.Wisdom} ({(Utility.GetAbilityModifier(player.Wisdom) < 0 ? "" : "+") + Utility.GetAbilityModifier(player.Wisdom)})");
            AtPosition($"Charisma {player.Charisma} ({(Utility.GetAbilityModifier(player.Charisma) < 0 ? "" : "+") + Utility.GetAbilityModifier(player.Charisma)})");

            top += 2;
            Console.SetCursorPosition(left, top++);
            if (player.Weapon != null)
            {
                if (player.Weapon.AbilityModifier >= 0)
                    Console.Write($"{player.Weapon.Name} = {player.Weapon.Damage} (+{player.Weapon.AbilityModifier} {player.Weapon.ModifierName}) Damage");
                else
                    Console.Write($"{player.Weapon.Name} = {player.Weapon.Damage} ({player.Weapon.AbilityModifier} {player.Weapon.ModifierName}) Damage");
            }
            top += 2;

            if (player.Armor != null)
            {
                foreach (Armor armor in player.Armor)
                {
                    Console.SetCursorPosition(left, top++);
                    if (armor.Placement.Equals("Off-hand"))
                        Console.Write($"{armor.Name} =  +{armor.ArmorClass} Armor Class");
                    else if (armor.AbilityModifier > 0)
                        Console.Write($"{armor.Name} = {armor.ArmorClass} (+{armor.AbilityModifier} {armor.ModifierName}) Armor Class");
                    else
                        Console.Write($"{armor.Name} = {armor.ArmorClass} Armor Class");
                }
            }
            Console.ReadLine();
        }

        private static void Stat(string title, int stat)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{title}: {stat}");
        }

        private static void Stat(string title, int stat, int modifier)
        {
            Console.SetCursorPosition(left, top++);
            if (modifier >= 0)
                Console.WriteLine($"{title}: {stat} (+{modifier})");
            else
                Console.WriteLine($"{title}: {stat} ({modifier})");
        }

        private static void StatMax(string title, int current, int max)
        {
            Console.SetCursorPosition(left, top++);
            Console.WriteLine($"{title}: {current}/{max}");
        }

        public static void Delayed(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write(text[i]);
                Thread.Sleep(50);
            }
        }
    }
}
