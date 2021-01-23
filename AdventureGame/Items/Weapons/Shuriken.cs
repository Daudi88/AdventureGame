using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Items.Weapons
{
    class Shuriken : Weapon
    {
        public Shuriken()
        {
            Name = "Shuriken";
            Cost = 250;
            Damage = "1d8";
        }
    }
}
