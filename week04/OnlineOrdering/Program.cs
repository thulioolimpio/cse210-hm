using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Emma Johnson", address2);

        // Create products
        Product product1 = new Product("Laptop", "P100", 999.99, 1);
        Product product2 = new Product("Mouse", "P101", 25.50, 2);
        Product product3 = new Product("Keyboard", "P102", 49.99, 1);
        Product product4 = new Product("Monitor", "P103", 199.99, 2);
        Product product5 = new Product("Headphones", "P104", 79.99, 1);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display order information
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("====================================");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order.CalculateTotalCost():0.00}");
        Console.WriteLine("====================================\n");
    }
}