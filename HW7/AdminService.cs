
using HW7ک;

namespace HW7;

public class AdminService
{

    public void ConfirmOrders()
    {
        int count = 1;
        var unconfirmedOrders = new List<Purchase>();

        foreach (var order in Storage.purchases)
        {
            if (order.Status == OrderStatus.Registered)
            {
                unconfirmedOrders.Add(order);
            }
        }

        if (unconfirmedOrders.Count == 0)
        {
            Console.WriteLine("No unconfirmed orders.");
            return;
        }
        else
        {
            foreach (var order in unconfirmedOrders)
            {
                Console.WriteLine($"{count}. Order for User {order.UserId}:");
                count++;
                foreach (var product in order.Products)
                {
                    Console.WriteLine($"Product: {product.ProductName}, Quantity: {product.ProductCount}");

                }
                Console.WriteLine("-----------------------------");

                //Console.WriteLine("Confirm this order? (y/n)");
                //var input = Console.ReadLine();
                //if (input == "y")
                //{
                //    order.Status = OrderStatus.Confirmed;
                //    Console.WriteLine("Order confirmed.");
                //}
            }
            Console.WriteLine("Enter the Order ID to confirm:");
            var choose = int.Parse(Console.ReadLine());
            unconfirmedOrders.ElementAt(choose).Status = OrderStatus.Confirmed;
            Console.WriteLine(" Confirmed.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Do you want to confirm more (y/n)?");
            var answer = Console.ReadLine();
            if (answer == "y")
            {
                ConfirmOrders();
            }
            else if (answer == "n")
            {
                return;
            }


        }
    }

    public void AddProduct()
    {
        Console.WriteLine("Enter product name:");
        var name = Console.ReadLine();
        Console.WriteLine("Enter product price:");
        var price = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter product count:");
        var count = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter produc Category : 0.hamooms 1.Cars 2.Mobile 3.Sprots");
        var cat = int.Parse(Console.ReadLine());
        CatEnum cate = (CatEnum)cat;

        var product = new Product
        {
            ProductName = name,
            ProductPrice = price,
            ProductCount = count,
            Category = cate
        };

        Storage.products.Add(product);
        Console.WriteLine("Product added successfully.");
    }

    public void UpdateProductStock()
    {
        Console.WriteLine("Enter product ID:");
        var productId = int.Parse(Console.ReadLine());
        Product product = null;
        foreach (var p in Storage.products)
        {
            if (p.ProductId == productId)
            {
                product = p;
                break;
            }
        }

        if (product != null)
        {
            Console.WriteLine("Enter new count of product:");
            product.ProductCount = int.Parse(Console.ReadLine());
            Console.WriteLine("Stock updated.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DeleteProduct()
    {
        Console.WriteLine("Enter product ID:");
        var productId = int.Parse(Console.ReadLine());
        Product product = null;
        foreach (var p in Storage.products)
        {
            if (p.ProductId == productId)
            {
                product = p;
                break;
            }
        }

        if (product != null)
        {
            Storage.products.Remove(product);
            Console.WriteLine("Product removed.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void ViewAllOrders()
    {
        foreach (var order in Storage.purchases)
        {
            Console.WriteLine($"Order for User {order.UserId}: Status: {order.Status}");
            foreach (var product in order.Products)
            {
                Console.WriteLine($"Product: {product.ProductName}, Quantity: {product.ProductCount}");
            }
        }
    }
}

