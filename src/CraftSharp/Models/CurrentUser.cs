namespace CraftSharp.Models
{
    public class CurrentUser
    {
        public Dictionary<string, string> Claims { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public int NumberOfKeys { get; set; } = 0;
        public List<Item> Inventory { get; set; } = new List<Item>();


    }
}
