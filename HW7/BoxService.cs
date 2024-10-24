
using HW7ک;

namespace HW7;



public class BoxService
{
    private Box currentBox;

    public void CreateOrLoadCurrentBox()
    {
        if (Storage.CurrentUser == null)
        {
            Console.WriteLine("No user is logged in.");
            return;
        }

        if (currentBox == null)
        {
            currentBox = new Box
            {
                UserId = Storage.CurrentUser.Id,
                product = new List<Product>()
            };
        }
    }

    public void AddProductToBox(int productId, int quantity)
    {
        CreateOrLoadCurrentBox();
        Product product = null;
        foreach (var p in Storage.products)
        {
            if (p.ProductId == productId)
            {
                product = p;
                break;
            }
        }

        if (product == null || product.ProductCount < quantity)
        {
            Console.WriteLine("Invalid product or count.");
            return;
        }

        product.ProductCount -= quantity;

        currentBox.product.Add(
        new Product
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            ProductPrice = product.ProductPrice,
            ProductCount = quantity
        });

        Console.WriteLine($"{quantity} of {product.ProductName} added to your box.");
    }

    public void FinalizePurchase()
    {
        if (currentBox != null && currentBox.product.Count > 0)
        {
            decimal totalCost = 0;
            foreach (var product in currentBox.product)
            {
                Product storeProduct = null;
                foreach (var p in Storage.products)
                {
                    if (p.ProductId == product.ProductId)
                    {
                        storeProduct = p;
                        break;
                    }
                }
                if (storeProduct != null)
                {
                    totalCost += storeProduct.ProductPrice * product.ProductCount; 
                }
            }

            if (Storage.CurrentUser.Credit >= totalCost)
            {
                Storage.CurrentUser.Credit -= totalCost;

                foreach (var product in currentBox.product)
                {
                    Product storeProduct = null;
                    foreach (var p in Storage.products)
                    {
                        if (p.ProductId == product.ProductId)
                        {
                            storeProduct = p;
                            break;
                        }
                    }
                    if (storeProduct != null)
                    {
                        storeProduct.ProductCount -= product.ProductCount; 
                    }
                }

                var newPurchase = new Purchase()
                {
                    UserId = Storage.CurrentUser.Id,
                    Products = new List<Product>(currentBox.product),
                    Status = OrderStatus.Registered
                };

                Storage.purchases.Add(newPurchase);
                Console.WriteLine("Your purchase has been registered!");

                currentBox.product.Clear();
                Console.WriteLine($"Total cost: {totalCost}, your new credit is: {Storage.CurrentUser.Credit}");
            }
            else
            {
                Console.WriteLine("credit error!!!.");
            }
        }
        else
        {
            Console.WriteLine("Your cart is empty.");
        }
    }

    public void ShowPreviousPurchases()
    {
        List<Purchase> userPurchases = new List<Purchase>();

        foreach (var purchase in Storage.purchases)
        {
            if (purchase.UserId == Storage.CurrentUser.Id)
            {
                userPurchases.Add(purchase);
            }
        }

        if (userPurchases.Count == 0)
        {
            Console.WriteLine("You have no previous purchases.");
            return;
        }

        foreach (var purchase in userPurchases)
        {
            Console.WriteLine($"Purchase on {purchase.PurchaseDate}:");

            foreach (var product in purchase.Products)
            {
                Console.WriteLine($"{product.ProductName} - {product.ProductCount}  - {product.ProductPrice} ");
            }
            Console.WriteLine();
        }
    }

}




