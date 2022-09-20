namespace VirtualIceCream.Models
{
    public class Ingredient : RepoItem<int>
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string OrderId { get; set; }
        public Profile Creator { get; set; }

    }

}