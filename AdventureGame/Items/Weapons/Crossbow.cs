using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Items.Weapons
{
    class Crossbow : Weapon
    {
        public Crossbow()
        {
            Name = "Crossbow";
            Cost = 750;
            Damage = "1d12";
        }
    }
}
