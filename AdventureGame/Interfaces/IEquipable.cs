namespace AdventureGame.Interfaces
{
    interface IEquipable
    {
        public string Bonus { get; set; }
        public void Equip(IPlayable player, IEquipable item);
    }
}
