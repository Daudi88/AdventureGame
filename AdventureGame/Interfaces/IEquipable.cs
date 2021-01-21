namespace AdventureGame.Interfaces
{
    interface IEquipable
    {
        public string Name { get; set; }
        public string Bonus { get; set; }
        public void Equip(IPlayable player, IEquipable item);
    }
}
