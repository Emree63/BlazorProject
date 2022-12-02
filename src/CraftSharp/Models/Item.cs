namespace CraftSharp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StackSize { get; set; }
        public string ImageBase64 { get; set; }
        public Rarities Rarity { get; set; }
    }
}
