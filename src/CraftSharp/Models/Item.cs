namespace CraftSharp.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StackSize { get; set; }
        public Rarities Rarity { get; set; }
    }
}
