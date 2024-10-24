using HW7;

var auth = new Authentication();
var boxService = new BoxService();
var marketService = new MarketService();

while (true)
{
    Console.Clear();
    Console.WriteLine("Welcome to the E-commerce system!");
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Register");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (auth.LogIn(username, password))
            {
                if (Storage.CurrentAdmin != null)
                {
                    AdminMenu(marketService);  
                }
                else
                {
                    boxService.CreateOrLoadCurrentBox();  
                    UserMenu(boxService);  
                }
            }
            else
            {
                Console.WriteLine("Invalid credentials. Press any key to continue.");
                Console.ReadKey();
            }
            break;

        case "2":
            RegisterNewUser(auth);  
            break;

        case "3":
            return;  

        default:
            Console.WriteLine("Invalid choice. Press any key to continue.");
            Console.ReadKey();
            break;
    }
}

static void RegisterNewUser(Authentication auth)
{
    Console.Write("Enter username: ");
    string newUsername = Console.ReadLine();

    Console.Write("Enter password: ");
    string newPassword = Console.ReadLine();

    Console.Write("Enter email: ");
    string email = Console.ReadLine();

    Console.Write("Enter name: ");
    string name = Console.ReadLine();

    Console.Write("Enter family: ");
    string family = Console.ReadLine();

    Console.Write("Enter phone: ");
    string phone = Console.ReadLine();

    User newUser = new User()
    {
        UserName = newUsername,
        Password = newPassword,
        Email = email,
        Name = name,
        Family = family,
        Phone = phone,
        Credit = 100000
    };

    if (auth.Register(newUser))
    {
        Console.WriteLine("Registration successful. Press any key to continue.");
    }
    else
    {
        Console.WriteLine("Registration failed. Press any key to continue.");
    }
    Console.ReadKey();
}
static void UserMenu(BoxService boxService)
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("User Menu:");
        Console.WriteLine("1. View Products");
        Console.WriteLine("2. Add Product to Box");
        Console.WriteLine("3. Finalize Purchase");
        Console.WriteLine("4. View Previous Purchases");
        Console.WriteLine("5. Add Credit");
        Console.WriteLine("6. Logout");
        Console.Write("Choose an option: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                new MarketService().ShowAllProducts();  
                Console.ReadKey();
                break;

            case "2":
                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                boxService.AddProductToBox(productId, quantity);  
                Console.ReadKey();
                break;

            case "3":
                boxService.FinalizePurchase();  
                Console.ReadKey();
                break;

            case "4":
                boxService.ShowPreviousPurchases();  
                Console.ReadKey();
                break;

            case "5":
                Console.Write("Enter amount to add: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                Storage.CurrentUser.Credit += amount;  
                Console.WriteLine("Credit added successfully.");
                Console.WriteLine($"your credit is {Storage.CurrentUser.Credit}");
                Console.ReadKey();
                break;

            case "6":
                Storage.CurrentUser = null;  
                return;

            default:
                Console.WriteLine("Invalid choice. Press any key to continue.");
                Console.ReadKey();
                break;
        }
    }
}

static void AdminMenu(MarketService marketService)
{
    bool exit = false;
    var adminService = new AdminService();  

    while (!exit)
    {
        Console.Clear();
        Console.WriteLine("Admin Menu:");
        Console.WriteLine("1. Confirm Orders");
        Console.WriteLine("2. Add Product");
        Console.WriteLine("3. Update Product Stock");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. View All Orders");
        Console.WriteLine("0. Logout");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                adminService.ConfirmOrders();
                Console.ReadKey();
                break;
            case "2":
                adminService.AddProduct();
                Console.ReadKey();
                break;
            case "3":
                adminService.UpdateProductStock();
                Console.ReadKey();
                break;
            case "4":
                adminService.DeleteProduct();
                Console.ReadKey();
                break;
            case "5":
                adminService.ViewAllOrders();
                Console.ReadKey();
                break;
            case "0":
                Storage.CurrentAdmin = null;
                exit = true;  
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }
}