using RajoSpritButik.UIComponents;
using Services.DTOs;

namespace RajoSpritButik.AdminPages.StatsPages;

internal class MostSoldProductsPage : Page
{
    public List<MostSoldProductDTO> Products { get; }
    private ChangePageRequest? request;
    public MostSoldProductsPage(List<MostSoldProductDTO> products)
    {
        Products = products;
    }

    public override ChangePageRequest? ChangePage()
    {
        return request;
    }

    public override void Draw()
    {
        Table<MostSoldProductDTO> productTable = new(
            Products,
            "Produkter",
            $"{"#".PadRight(3)}{"Namn".PadRight(30)}{"Antal sålda".PadRight(15)}",
            (p, i) => $"{(i + 1).ToString().PadRight(3)}{p.Name.PadRight(30)}{p.NumberSold.ToString().PadRight(15)}",
            X,
            Y
        );
        productTable.Draw();
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
