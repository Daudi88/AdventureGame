using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Items.Weapons
{
    class Spear :Weapon
    {
        public Spear()
        {
            Name = "Spear";
            Cost = 2000;
            Damage = "2d10";
        }
    }
}
