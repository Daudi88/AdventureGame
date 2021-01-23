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

        // Fixa implementeringen av Abu Hassans Shop. => AK-47, Bulletproof vest, Red Bull

        // Fixa implementeringen Så man får något vid graveyard.
        // Fixa implementeringen Så man får något vid Treasure.

        // Monster ska droppa items när de dör!

        // Kan man köpa/sälja flera quantity på samma gång? Hur många vill du köpa? Bara om det är en consumable.    
        // Om man dricker en RedBull får det en positiv effekt under nästa fight (bool redBullBonusEffect = true;)

        // Backpack sell måste fixas

        // Göra alla vapen till enskilda klasser???
    }
}
