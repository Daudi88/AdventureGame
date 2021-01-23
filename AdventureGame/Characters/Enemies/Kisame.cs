using AdventureGame.Items.Armors;
using AdventureGame.Items.Weapons;
using AdventureGame.Structure;
using System;

namespace AdventureGame.Characters.Enemies
{
    class Kisame : Character
    {
        public Kisame()
        {
            Name = "Kisame";
            Level = 1;
            Hp = 25;
            Exp = 50;
            Gold = Utility.RollDice(100 * Level);
            Armor = new FlakJacket();
            Defence = Armor.Defence;
            Weapon = new Kunai();
            Damage = Weapon.Damage;

        }
    }
}
