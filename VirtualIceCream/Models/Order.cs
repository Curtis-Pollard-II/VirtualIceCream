
namespace VirtualIceCream.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public string Screenshot { get; set; }
        public string CreatorId { get; set; }
        public Account Creator { get; set; }

    }
}