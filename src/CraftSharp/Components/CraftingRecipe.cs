using CraftSharp.Models;

namespace CraftSharp.Components
{
    public class CraftingRecipe
    {
        public Item Give { get; set; }
        public List<List<string>> Have { get; set; }
    }

}
