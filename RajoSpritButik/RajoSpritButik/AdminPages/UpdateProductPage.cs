using Entities.Models;

namespace RajoSpritButik.AdminPages;

internal class UpdateProductPage : Page
{
    private bool editMode;
    private char selectedField;
    private bool shouldPatch;

    public Product Product { get; set; }

    public UpdateProductPage(Product product)
    {
        Product = product;
    }

    public override ChangePageRequest? ChangePage()
    {
        if (shouldPatch && ShouldChangePage)
        {
            shouldPatch = false;
            return new ChangePageRequest() { Page = "product", Action = RequestAction.Patch, Query = Product };
        }
        else if (ShouldChangePage)
        {
            return new ChangePageRequest() { Page = "manage-products" };
        }
        return null;
    }

    public override void Draw()
    {
        List<string> productFields = new()
        {
            $"1. Namn: {Product.Name}",
            $"2. Pris: {Product.Price}",
            $"3. Lagersaldo: {Product.Stock}",
            $"4. Tillverkare: {Product.Manufacturer.Name} ({Product.ManufacturerId})",
            $"5. Kategori: {Product.Category.Name} ({Product.CategoryId})",
            $"6. Beskrivning: {Product.Description}",
            $"7. Erbjudande: {(Product.Showcase ? "Ja" : "Nej")}"
        };
        Window productWindow = new("Vald produkt", X, Y, productFields);
        productWindow.Draw();

        if (editMode)
        {
            switch (selectedField)
            {
                case '1': Console.Write("Skriv in ett nytt namn på produkten: "); break;
                case '2': Console.Write("Skriv in ett nytt pris på produkten: "); break;
                case '3': Console.Write("Skriv in ett nytt lagersaldo: "); break;
                case '4': Console.Write("Skriv in ID:t för nya tillverkaren: "); break;
                case '5': Console.Write("Skriv in ID:t för nya kategorin: "); break;
                case '6': Console.Write("Skriv in den nya beskrivningen: "); break;
                case '7': Console.Write("Visa varan på startsidan J/N: "); break;
                default: break;
            }
        }
        else
        {
            Console.WriteLine("Tryck 1-7 för att redigera ett fält.");
            Console.WriteLine("Tryck C för att gå tillbaka");
        }
    }

    public override void HandleInput()
    {
        if (!editMode)
        {
            var key = Console.ReadKey(true).KeyChar;
            if (key >= '1' && key <= '7')
            {
                selectedField = key;
                editMode = true;
            }
            if (key == 'c' || key == 'C')
            {
                ShouldChangePage = true;
            }
        }
        else
        {
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                switch (selectedField)
                {
                    case '1':
                        Product.Name = input;
                        break;
                    case '2':
                        if (decimal.TryParse(input, out var price))
                        {
                            Product.Price = price;
                        }
                        break;
                    case '3':
                        if (int.TryParse(input, out var stock))
                        {
                            Product.Stock = stock;
                        }
                        break;
                    case '4':
                        if (int.TryParse(input, out var manufacturerId))
                        {
                            Product.ManufacturerId = manufacturerId;
                            Product.Manufacturer = null!;
                        }
                        break;
                    case '5':
                        if (int.TryParse(input, out var categoryId))
                        {
                            Product.CategoryId = categoryId;
                            Product.Category = null!;
                        }
                        break;
                    case '6':
                        Product.Description = input;
                        break;
                    case '7':
                        if (input.ToUpper() == "J")
                        {
                            Product.Showcase = true;
                        }
                        else if (input.ToUpper() == "N")
                        {
                            Product.Showcase = false;
                        }
                        break;
                }

                shouldPatch = true;
                ShouldChangePage = true;
            }

            editMode = false;
        }
    }
}
