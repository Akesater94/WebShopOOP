using Entities.Models;

namespace RajoSpritButik.AdminPages;

internal class CreateProductPage : Page
{
    private int step = 1;
    public Product Product { get; set; }

    public CreateProductPage(int x, int y, int width, int height) : base(x, y, width, height)
    {
        Product = new Product();
    }

    public override ChangePageRequest? ChangePage()
    {
        if (ShouldChangePage)
        {
            if (Product == null)
            {
                return new ChangePageRequest() { Page = "manage-products" };
            }

            return new ChangePageRequest() { Page = "product", Action = RequestAction.Post, Query = Product };
        }
        return null;
    }

    public override void Draw()
    {
        Console.Clear();
        Console.WriteLine("Skapa ny produkt:");


        switch (step)
        {
            case 1: Console.Write("1. Skriv in namn på produkten: "); break;
            case 2: Console.Write("2. Skriv in pris på produkten: "); break;
            case 3: Console.Write("3. Skriv in lagersaldo: "); break;
            case 4: Console.Write("4. Skriv in ID för tillverkaren: "); break;
            case 5: Console.Write("5. Skriv in ID för kategorin: "); break;
            case 6: Console.Write("6. Visa varan på startsidan J/N: "); break;
            default: Console.WriteLine("Sparar produkt..."); break;
        }
    }

    public override void HandleInput()
    {
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            bool success = false;

            switch (step)
            {
                case 1:
                    Product.Name = input;
                    success = true;
                    break;
                case 2:
                    if (decimal.TryParse(input, out var price))
                    {
                        Product.Price = price;
                        success = true;
                    }
                    break;
                case 3:
                    if (int.TryParse(input, out var stock))
                    {
                        Product.Stock = stock;
                        success = true;
                    }
                    break;
                case 4:
                    if (int.TryParse(input, out var manufacturerId))
                    {
                        Product.ManufacturerId = manufacturerId;
                        success = true;
                    }
                    break;
                case 5:
                    if (int.TryParse(input, out var categoryId))
                    {
                        Product.CategoryId = categoryId;
                        success = true;
                    }
                    break;
                case 6:
                    if (input.ToUpper() == "J")
                    {
                        Product.Showcase = true;
                        success = true;
                    }
                    else if (input.ToUpper() == "N")
                    {
                        Product.Showcase = false;
                        success = true;
                    }
                    break;
            }

            if (success)
            {
                step++;
                if (step > 6)
                {
                    ShouldChangePage = true;
                }
            }
            else
            {
                Console.WriteLine("Ogiltig inmatning, försök igen.");
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}