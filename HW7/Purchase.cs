
using HW7;

namespace HW7ک
{
    public class Purchase
    {
        public int UserId { get; set; }
        public List<Product> Products { get; set; }
        public DateTime PurchaseDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
