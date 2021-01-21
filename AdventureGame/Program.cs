using AdventureGame.HelperMethods;
using System;

namespace AdventureGame
{
    class Program
    {
        static void Main()
        {
            Game game = new Game();
            game.Setup();
        }

        // TODO
        // Låt fiender ha vapen (iaf ett vapennamn);
        // Fixa implementeringen av Shop.
        // Monster ska droppa items när de dör!
        // Visa föremålen i ryggsäcken.
        // Vapen, Armor, Items, Potions , Backpack osv...
        // Armor och Weapon ska ha public string Describe() som returnerar Name (+Hp).
        // Håkan ska skriva sitt äventyr! Implementeringen får ske i Explore().
        // Kan man köpa/sälja flera quantity på samma gång? Hur många vill du köpa? Bara om det är en consumable.
        // Drick potion (RedBull) under strid mellan rundorna. Ger dig 10% Hp. Kostar 20-30 guld.
        // Console.WriteLine("\n\tYou take the time to drink a powerfull potion. It feels like you have wings."); => När man dricker en potion!    
        // Gandalf story och implementering.       
        // Fixa backpack problemet med akumelering av items rensas

        // ÖVERKURS!
        // Sudda ut felaktig inmatning.
        // Bakgrundsmusik.
        // Visa spelaren på kartan.
    }
}
