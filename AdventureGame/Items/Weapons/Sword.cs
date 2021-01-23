using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Items.Weapons
{
    class Sword : Weapon
    {
        public Sword()
        {
            Name = "Sword";
            Cost = 2500;
            Damage = "2d12";
        }
    }
}
