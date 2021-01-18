using AdventureGame.Interfaces;
using AdventureGame.Items;
using System;
using System.Collections.Generic;

namespace AdventureGame.Creatures
{
    class Player : Creature, IPlayable
    {
        public string Class { get; set; }
        public string Race { get; set; }
        public int MaxHp { get; set; }
        public string HitDie { get; set; }
        public int MaxExp { get; set; } = 300;

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int ProficiencyBonus { get; set; } = 2;
        public Weapon Weapon { get; set; }
        public List<Armor> Armor { get; set; } = new List<Armor>();
        public List<Item> Backpack { get; set; } = new List<Item>();

        public Player(string _class, int hitPoints, string hitDie, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
        {
            Level = 1;
            Class = _class;
            HitPoints = hitPoints;
            MaxHp = hitPoints;
            HitDie = hitDie;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
        }

        public override void Attack(Creature defender)
        {
            throw new NotImplementedException();
        }

        public void LevelUp()
        {

        }
    }
}
