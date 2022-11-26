namespace CraftSharp.Models
{
    public class Trade
    {
        public Item GivenItem { get; set; }
        public int GivenItemQuantity { get; set; }
        public Item ReceivedItem { get; set; }
        public int ReceivedItemQuantity { get; set; }
    }
}
