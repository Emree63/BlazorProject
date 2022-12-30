namespace CraftSharp.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public int numberOfKeys { get; set; } = 10;
        public int numberOfEmeralds { get; set; } = 250;

        public string Password { get; set; }
        public List<UserRoles> Roles { get; set; } = new List<UserRoles>() { UserRoles.User };
        public string UserName { get; set; }
        public List<Item> inventory { get; set; } = new List<Item>();

    }
}
