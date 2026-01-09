using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public int UserId { get; set; }
        public DateTime Created {  get; set; }
        public decimal TotalAmount {  get; set; }
        public OrderStatus Status { get; set; }
    }
}
