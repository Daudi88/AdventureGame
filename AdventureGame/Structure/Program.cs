namespace AdventureGame.Structure
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
        // Narutos Gandalf story och implementering.       
        // pos i GoAdventure måste ändras efter att man har besökt Hiruzen, graveyard, treasure & shop. Annars hamnar man i en evighetsloop...
        // Console.CursorTop
        // om man dricker en RedBull får det en positiv effekt under nästa fight (bool redBullBonusEffect = true;)
        // det är något knas med backpack om den är tom
        // backpack sell måste fixas


        // ÖVERKURS!
        // Sudda ut felaktig inmatning. [HÅKAN]
        // Bakgrundsmusik. [HÅKAN]
    }
}
