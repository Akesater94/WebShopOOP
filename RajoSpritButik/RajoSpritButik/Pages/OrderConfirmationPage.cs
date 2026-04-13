using Entities.Models;
using RajoSpritButik.UIComponents;

namespace RajoSpritButik.Pages;

internal class OrderConfirmationPage : Page
{
    public Order Order { get; set; }

    public OrderConfirmationPage(Order order)
    {
        Order = order;
    }

    public override ChangePageRequest? ChangePage()
    {
        return new ChangePageRequest() { Page = "menu" };
    }

    public override void Draw()
    {
        List<string> orderInfo = new List<string>()
        {
            "Tack för din beställning!",
            " ",
        };

        orderInfo.Add($"Du har valt att få dina varor genom {Order.ShippingAlternative.Name} till: ");
        orderInfo.Add($"{Order.Address.Street} {Order.Address.StreetNumber}");
        orderInfo.Add($"{Order.Address.ZipCode} {Order.Address.City}");
        orderInfo.Add($"{Order.Address.Country.Name}");

        Window orderConfirmationWindow = new Window("", X, Y, orderInfo);
        orderConfirmationWindow.Draw();

        Table<OrderRow> orderRowTable = new(

            Order.OrderRows.ToList(),
            $"Order: {Order.Id}",
            $"{"#".PadRight(3)}{"Namn".PadRight(15)}{"Antal".PadRight(7)}{"Styckpris".PadRight(12)}{"Totalpris".PadRight(12)}",
            $"Totalt: {Order.OrderTotal()} kr",
            (or, i) => $"{(i + 1).ToString().PadRight(3)}{or.Product.Name.PadRight(15)}{or.Quantity.ToString().PadRight(7)}{or.Product.Price.ToString().PadRight(12)}{or.RowTotal.ToString().PadRight(12)}",
            X + orderConfirmationWindow.WindowWidth + 2,
            Y
            );

        orderRowTable.Draw();

        Console.WriteLine("Tryck C för att gå till menyn");
    }

    public override void HandleInput()
    {
        if (Console.ReadKey().Key == ConsoleKey.C)
        {
            ShouldChangePage = true;
        }
    }
}