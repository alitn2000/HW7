using HW7;
using HW7ک;

public class MarketService
{
    public void ShowAllProducts()
    {
        foreach (var product in Storage.products)
        {
            Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.ProductPrice}, Stock: {product.ProductCount}");
        }
    }

   

}