using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Items.Weapons
{
    class Kunai : Weapon
    {
        public Kunai()
        {
            Name = "Kunai";
            Cost = 150;
            Damage = "1d6";
        }
    }
}
