using Entities.Models;
using RajoSpritButik.UIComponents;

namespace RajoSpritButik.AdminPages;

internal class ManageProductsPage : Page
{
    public List<Product> Products { get; set; }
    public char SelectedItem { get; set; }
    public bool SelectMode { get; set; }
    public Product? SelectedProduct { get; set; }
    public char Input { get; set; }
    public bool CreateMode { get; private set; }

    public ManageProductsPage(List<Product> products, int x, int y, int width, int height) : base(x, y, width, height)
    {
        Products = products;
    }

    public override ChangePageRequest? ChangePage()
    {
        if (SelectMode && SelectedProduct != null)
        {
            if (Input == 's' || Input == 'S')
            {
                return new ChangePageRequest() { Page = "update-product", Query = SelectedProduct.Id };
            }
            else if (Input == 'd' || Input == 'D')
            {
                return new ChangePageRequest() { Page = "product", Action = RequestAction.Delete, Query = SelectedProduct.Id };
            }
        }
        else if (CreateMode)
        {
            return new ChangePageRequest() { Page = "create-product" };
        }
        else if (Input == 'c' || Input == 'C')
        {
            return new ChangePageRequest() { Page = "admin-menu" };
        }
        return null;
    }

    public override void Draw()
    {
        Table<Product> productTable = new(
            Products,
            "Produkter",
            $"{"#".PadRight(3)}{"Namn".PadRight(15)}{"Kategori".PadRight(15)}{"Saldo".PadRight(15)}{"Pris".PadRight(15)}",
            (p, i) => $"{(i + 1).ToString().PadRight(3)}{p.Name.PadRight(15)}{p.Category.Name.PadRight(15)}{p.Stock.ToString().PadRight(15)}{p.Price.ToString().PadRight(15)}",
            X,
            Y
            );
        productTable.Draw();
        if (SelectMode)
        {
            Console.Write("Vilken produkt vill du välja?: ");
        }
        else
        {
            Console.WriteLine("Tryck S för att välja produkt att hantera.");
            Console.WriteLine("Tryck D för att välja produkt att ta bort.");
            Console.WriteLine("Tryck N för att skapa en ny produkt.");
            Console.WriteLine("Tryck C för att gå tillbaka till menyn.");
        }
    }

    public override void HandleInput()
    {

        if (SelectMode)
        {
            string? selectedItem = Console.ReadLine();
            if (int.TryParse(selectedItem, out var productId))
            {
                productId -= 1;
                if (productId < Products.Count && productId >= 0)
                {
                    SelectedProduct = Products[productId];
                    ShouldChangePage = true;
                }
            }
        }
        else
        {
            Input = Console.ReadKey().KeyChar;
            switch (Input.ToString().ToUpper())
            {
                case "C":
                    ShouldChangePage = true;
                    break;
                case "S":
                case "D":
                    SelectMode = true;
                    break;
                case "N":
                    CreateMode = true;
                    ShouldChangePage = true;
                    break;
            }
        }
    }
}
