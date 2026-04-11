using Entities.Models;

namespace RajoSpritButik.Pages;

internal class CategoryPage : Page
{
    public char? SelectedItem { get; set; }
    public List<Product> Products { get; set; } = [];
    public bool AddMode { get; set; }
    public Product SelectedProduct { get; set; } = null!;
    public bool SelectMode { get; set; }

    public CategoryPage(List<Product> products)
    {
        Products = products;
    }

    public override ChangePageRequest? ChangePage()
    {
        if (AddMode)
        {
            AddMode = false;

            return new ChangePageRequest() { Page = "shopping-cart-row", Action = RequestAction.Post, Query = SelectedProduct.Id };
        }
        else
        {
            if (ShouldChangePage)
            {
                return new ChangePageRequest() { Page = "categories", Query = SelectedItem.ToString() };
            }
            else
            {
                return null;
            }
        }
    }

    public override void Draw()
    {
        int nextX = X;
        int nextY = Y;
        for (int i = 0; i < Products.Count; i++)
        {
            List<string> products = new List<string>()
            {
                (i+1).ToString(),

                "Pris: " + Products[i].Price.ToString() + "kr",
                "Lagersaldo: " + Products[i].Stock.ToString() + " St",
            };

            Window productWindow = new(Products[i].Name, nextX, nextY, products);

            if (nextX + productWindow.WindowWidth > Width)
            {
                nextX = 0;
                productWindow.Left = nextX;
                nextY += 5;
                productWindow.Top = nextY;
            }

            productWindow.Draw();
            nextX += productWindow.WindowWidth + 2;
        }

        if (!AddMode)
        {
            Console.WriteLine("Tryck A för att kunna lägga till produkt i varukorgen.");
            Console.WriteLine("Tryck C för att gå tillbaka till menyn.");
        }
        else
        {
            Console.Write("Välj en produkt att lägga till: ");
        }

    }

    public override void HandleInput()
    {
        if (AddMode)
        {
            var key = Console.ReadKey().KeyChar;
            if (int.TryParse(key.ToString(), out var productId))
            {
                productId -= 1;
                if (productId <= Products.Count && productId >= 0)
                {
                    SelectedProduct = Products[productId];
                    ShouldChangePage = true;
                }
            }
        }
        else
        {
            SelectedItem = Console.ReadKey(true).KeyChar;
            switch (SelectedItem.ToString().ToUpper())
            {
                case "A":
                    AddMode = true;
                    break;

                case "C":
                    ShouldChangePage = true;
                    break;

                case "S":
                    SelectMode = true;
                    break;

                default:
                    ShouldChangePage = false;
                    break;
            }
        }
    }
}
