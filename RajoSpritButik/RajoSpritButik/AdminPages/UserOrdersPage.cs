using Entities.Models;
using RajoSpritButik.UIComponents;

namespace RajoSpritButik.AdminPages;

internal class UserOrdersPage : Page
{
    private List<Order> Orders { get; set; }
    private int UserId { get; set; }
    private ChangePageRequest? request;

    public UserOrdersPage(List<Order> orders, int id)
    {
        Orders = orders;
        UserId = id;
    }

    public override ChangePageRequest? ChangePage()
    {
        return request;
    }

    public override void Draw()
    {
        Table<Order> ordersTable = new(
            Orders,
            "Ordrar",
            $"{"#".PadRight(3)}{"Status".PadRight(10)}{"Kundnamn".PadRight(20)}",
            (o, i) => $"{(i + 1).ToString().PadRight(3)}{o.Status.PadRight(10)}{o.User.Name.PadRight(20)}",
            X,
            Y
            );
        ordersTable.Draw();
        Console.WriteLine("Tryck C för att gå tillbaka till menyn.");
    }

    public override void HandleInput()
    {
        char input = Console.ReadKey().KeyChar;
        if (input == 'c' || input == 'C')
        {
            request = new ChangePageRequest { Page = "manage-user", Query = UserId };
            ShouldChangePage = true;
        }
    }
}