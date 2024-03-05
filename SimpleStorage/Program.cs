using SimpleStorage;

var inventory = new List<Product>();
var isRunning = true;
while (isRunning)
{
    Console.WriteLine("1. Legg til produkt");
    Console.WriteLine("2. Fjern produkt");
    Console.WriteLine("3. Søk etter produkt");
    Console.WriteLine("4. Vis alle produkter");
    Console.WriteLine("5. Avslutt");
    Console.Write("Velg en handling: ");
    var action = Console.ReadLine();
    Console.Clear();
    if (action == "1") AddProduct();
    else if (action == "2") RemoveProduct();
    else if (action == "3") SearchProduct();
    else if (action == "4") ListAllProducts();
    else if (action == "5") isRunning = false;
    else Console.WriteLine("Ugyldig valg, prøv igjen.");
    Console.WriteLine();

}

void AddProduct()
{
    var product = new Product();

    Console.Write("Skriv inn product id: ");
    product.ID = Convert.ToInt32(Console.ReadLine());

    Console.Write("Skriv inn produkt navn: ");
    product.Name = Console.ReadLine();

    inventory.Add(product);
    Console.WriteLine("Produkt lagt til.");
}

void RemoveProduct()
{
    Console.Write("Skriv inn product id som skal fjernes: ");
    int id = Convert.ToInt32(Console.ReadLine());
    var product = inventory.FirstOrDefault(p => p.ID == id);
    if (product != null)
    {
        inventory.Remove(product);
        Console.WriteLine("Produkt fjernet.");
    }
    else
    {
        Console.WriteLine("Produkt ikke funnet.");
    }
}

void SearchProduct()
{
    Console.Write("Skriv inn product id eller nam som du vil søke etter: ");
    var input = Console.ReadLine();
    var isId = int.TryParse(input, out int id);
    var products = inventory.Where(p => isId && p.ID == id || p.Name.Contains(input)).ToList();

    if (products.Any())
    {
        Console.WriteLine("Funnet produkter:");
        foreach (var product in products)
        {
            Console.WriteLine($"ID: {product.ID}, Navn: {product.Name}");
        }
    }
    else
    {
        Console.WriteLine("Ingen produkter funnet.");
    }
}

void ListAllProducts()
{
    if (inventory.Any())
    {
        Console.WriteLine("Alle produkter i lager:");
        foreach (var product in inventory)
        {
            Console.WriteLine($"ID: {product.ID}, Navn: {product.Name}");
        }
    }
    else
    {
        Console.WriteLine("Ingen produkter i lager.");
    }
}
