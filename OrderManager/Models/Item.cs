using System.Text.Json.Serialization;

namespace OrderManager.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; } = string.Empty;
        [JsonIgnore]
        public int OrderId { get; set; }
    }
}
