
using HW7ک;

namespace HW7;

public static class Storage
{
    public static User CurrentUser { get; set; }
    public static Admin CurrentAdmin { get; set; }
    public static Box currentBox = new Box();
    public static int UserCounter = 3;
    public static int ProductCounter = 13;

    public static List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                UserName = "alitn",
                Password = "123",
                Name = "Ali",
                Family = "Tahmasebinia",
                Email = "alitn2000@gmail.com",
                Phone = "09102123542",
                Credit = 1000000
            },
            new User()
            {
                Id = 2,
                UserName = "reza01",
                Password = "123",
                Name = "Ali",
                Family = "Tahmasebinia",
                Email = "Reza01@gmail.com",
                Phone = "09101234567",
                Credit = 5000000
            }
        };

    public static List<Admin> admins = new List<Admin>()
        {
            new Admin()
            {
                AdminUserName = "admin",
                AdminPassword = "admin",
                AdminName = "Ali",
                AdminFamily = "Alizade"
            }
        };

    public static List<Product> products = new List<Product>()
        {
            new Product() { ProductId = 1, Category = CatEnum.Hamooms, ProductName = "Saboon", ProductCount = 10, ProductPrice = 10000 },
            new Product() { ProductId = 2, Category = CatEnum.Hamooms, ProductName = "Shampoo", ProductCount = 10, ProductPrice = 52000 },
            new Product() { ProductId = 3, Category = CatEnum.Hamooms, ProductName = "Lif", ProductCount = 10, ProductPrice = 30000 },
            new Product() { ProductId = 4, Category = CatEnum.Hamooms, ProductName = "Hole", ProductCount = 10, ProductPrice = 200000 },
            new Product() { ProductId = 5, Category = CatEnum.Mobiles, ProductName = "S23 Ultra", ProductCount = 5, ProductPrice = 78600000 },
            new Product() { ProductId = 6, Category = CatEnum.Mobiles, ProductName = "S24 Ultra", ProductCount = 5, ProductPrice = 63000000 },
            new Product() { ProductId = 7, Category = CatEnum.Mobiles, ProductName = "Z Fold 5", ProductCount = 5, ProductPrice = 86500000 },
            new Product() { ProductId = 8, Category = CatEnum.Cars, ProductName = "Pride", ProductCount = 5, ProductPrice = 200000000 },
            new Product() { ProductId = 9, Category = CatEnum.Cars, ProductName = "Haima S5", ProductCount = 5, ProductPrice = 1250000000 },
            new Product() { ProductId = 10, Category = CatEnum.Cars, ProductName = "Haima 8S", ProductCount = 5, ProductPrice = 1800000000 },
            new Product() { ProductId = 11, Category = CatEnum.Sports, ProductName = "BasketBall", ProductCount = 10, ProductPrice = 250000 },
            new Product() { ProductId = 12, Category = CatEnum.Sports, ProductName = "FootBall", ProductCount = 10, ProductPrice = 250000 }
        };

    public static List<Purchase> purchases = new List<Purchase>();
}
