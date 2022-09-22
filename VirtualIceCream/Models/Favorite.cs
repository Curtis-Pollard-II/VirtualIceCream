namespace VirtualIceCream.Models
{
    public class Favorite : RepoItem<int>
    {
        public int OrderId { get; set; }
        public string AccountId { get; set; }

    }
}