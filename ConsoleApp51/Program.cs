using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; }
    public double Price { get; }
    public int Quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public double CalculateTotalPrice()
    {
        return Price * Quantity;
    }
}

class Cart
{
    private List<Product> products;

    public Cart()
    {
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        products.Remove(product);
    }

    public double CalculateTotalPrice()
    {
        double totalPrice = 0;

        foreach (Product product in products)
        {
            totalPrice += product.CalculateTotalPrice();
        }

        return totalPrice;
    }

    public void PrintInvoice()
    {
        Console.WriteLine("Invoice:");

        foreach (Product product in products)
        {
            Console.WriteLine("Product: " + product.Name);
            Console.WriteLine("Price: " + product.Price);
            Console.WriteLine("Quantity: " + product.Quantity);
            Console.WriteLine("Total Price: " + product.CalculateTotalPrice());
            Console.WriteLine();
        }

        Console.WriteLine("Total Amount: " + CalculateTotalPrice());
    }

    public List<Product> Products
    {
        get { return products; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cart cart = new Cart();

        Product product1 = new Product("Product 1", 10.99, 2);
        Product product2 = new Product("Product 2", 5.99, 3);
        Product product3 = new Product("Product 3", 7.50, 1);

        cart.AddProduct(product1);
        cart.AddProduct(product2);
        cart.AddProduct(product3);

        Console.WriteLine("Welcome to the Shopping Cart!");

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. Remove a product");
            Console.WriteLine("3. Calculate total price");
            Console.WriteLine("4. Print invoice");
            Console.WriteLine("0. Exit");

            Console.Write("Your option: ");
            string option = Console.ReadLine();

            Console.WriteLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter product name: ");
                    string productName = Console.ReadLine();

                    Console.Write("Enter product price: ");
                    double productPrice = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter product quantity: ");
                    int productQuantity = Convert.ToInt32(Console.ReadLine());
                    Product newProduct = new Product(productName, productPrice, productQuantity);
                    cart.AddProduct(newProduct);

                    Console.WriteLine("Product added successfully.");
                    break;

                case "2":
                    Console.Write("Enter the index of the product you want to remove: ");
                    int productIndex = Convert.ToInt32(Console.ReadLine());

                    if (productIndex >= 0 && productIndex < cart.Products.Count)
                    {
                        Product productToRemove = cart.Products[productIndex];
                        cart.RemoveProduct(productToRemove);
                        Console.WriteLine("Product removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid product index. Please try again.");
                    }
                    break; // Adăugarea instrucțiunii 'break' pentru a rezolva eroarea CS0163

                case "3":
                    double totalPrice = cart.CalculateTotalPrice();
                    Console.WriteLine("Total price: " + totalPrice);
                    break;

                case "4":
                    cart.PrintInvoice();
                    break;

                case "0":
                    exit = true;
                    Console.WriteLine("Thank you for using the Shopping Cart. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
            Console.WriteLine();
        }
    }
}