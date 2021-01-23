using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Items.Weapons
{
    class ChakraBlade : Weapon
    {
        public ChakraBlade()
        {
            Name = "Chakra Blade";
            Cost = 1500;
            Damage = "2d8";
        }
    }
}
