namespace CraftSharp.Models
{
    public class CurrentUser
    {
        public Dictionary<string, string> Claims { get; set; }
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public int NumberOfKeys { get; set; } = 0;
        public int numberOfEmeralds { get; set; } = 250;
        public List<Item> Inventory { get; set; } = new List<Item>();
        public List<UserRoles> Roles { get; set; } = new List<UserRoles>() { UserRoles.User };

        public void addItem(Item item)
        {
            Inventory.Add(item);
        }
        public void DeleteItem(Item item)
        {
            Inventory.Remove(item);
        }
        public int getSizeInventory()
        {
            return Inventory.Count;
        }

    }
}
