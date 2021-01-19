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
        // Fixa implementeringen av Shop.
        // Vapen, Armor, Items, Potions , Backpack osv...
        // Armor och Weapon ska ha public string Describe() som returnerar Name (+Hp).
        // Håkan ska skriva sitt äventyr! Implementeringen får ske i Explore().
        // Drick potion (RedBull) under strid mellan rundorna. Ger dig 10% Hp. Kostar 20-30 guld. 
        // Console.WriteLine("\n\tYou take the time to drink a powerfull potion. It feels like you have wings."); => När man dricker en potion!    
        // Gandalf story och implementering.

        // ÖVERKURS!
        // Sudda ut felaktig inmatning.
        // Bakgrundsmusik.
        // Implementera Ascii-karta, visa karaktären med x- y-kordinater på ascii-kartan.
        // Öppna kartan med M, alternativt ha kartan placerad till höger om textdelen.
    }
}
