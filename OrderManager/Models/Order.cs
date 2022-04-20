using System.Text.Json.Serialization;

namespace OrderManager.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public int CustomerId { get; set; }
    }
}
