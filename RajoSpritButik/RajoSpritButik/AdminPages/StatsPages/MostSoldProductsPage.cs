using Entities.Models;
using RajoSpritButik.UIComponents;

namespace RajoSpritButik.AdminPages.StatsPages;

internal class MostSoldProductsPage : Page
{
    public List<Product> Products { get; }
    private ChangePageRequest? request;
    public MostSoldProductsPage(List<Product> products)
    {
        Products = products;
    }

    public override ChangePageRequest? ChangePage()
    {
        return request;
    }

    public override void Draw()
    {
        Table<Product> productTable = new(
            Products,
            "Produkter",
            $"{"#".PadRight(3)}{"Namn".PadRight(30)}{"Kategori".PadRight(15)}{"Saldo".PadRight(15)}{"Pris".PadRight(15)}",
            (p, i) => $"{(i + 1).ToString().PadRight(3)}{p.Name.PadRight(30)}{p.Category.Name.PadRight(15)}{p.Stock.ToString().PadRight(15)}{p.Price.ToString().PadRight(15)}",
            X,
            Y
        );

        Console.WriteLine("Tryck C för att gå tillbaka till menyn.");

    }

    public override void HandleInput()
    {
        ShouldChangePage = true;
        char input = Console.ReadKey().KeyChar;
        switch (input)
        {
            case 'c':
                request = new ChangePageRequest() { Page = "stats" };
                break;
            default:
                ShouldChangePage = false;
                break;
        }
    }
}
