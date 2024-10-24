

namespace HW7;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductCount { get; set; }
    public CatEnum Category { get; set; }
    public bool Empty { get; set; }

}
