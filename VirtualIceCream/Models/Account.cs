namespace VirtualIceCream.Models
{

    public class Profile: RepoItem<string>
    {
        public string Picture { get; set; }
        public string Name { get; set; }
    }
    public class Account : Profile
    {
        public string Email { get; set; }
    }

    public class Hearts : Profile
    {
        public int favoritesId { get; set; }
    }
}