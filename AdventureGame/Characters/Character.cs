namespace AdventureGame.Characters
{
    abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int Hp { get; set; }
        public int Exp { get; set; } = 0;
        public string Damage { get; set; }
        public int Gold { get; set; } = 0;

        public Character(int hp, string damage)
        {
            Hp = hp;
            Damage = damage;
        }

        public abstract int Attack(out string text);
    }
}
