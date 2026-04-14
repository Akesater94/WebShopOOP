using Entities.Models;
using RajoSpritButik.UIComponents;

namespace RajoSpritButik;

internal class UserAddressesPage : Page
{
    public List<Address> Addresses { get; set; }
    public int UserId { get; }
    private ChangePageRequest? request;

    public UserAddressesPage(List<Address> addresses, int userId)
    {
        Addresses = addresses;
        UserId = userId;
    }

    public override ChangePageRequest? ChangePage()
    {
        return request;
    }

    public override void Draw()
    {
        Table<Address> addressTable = new(
            Addresses,
            "Kontaktinformationer",
            $"{"#".PadRight(3)}{"Gatuaddress".PadRight(15)}{"Postnummer".PadRight(15)}{"Stad".PadRight(15)}{"Land".PadRight(15)}",
            (a, i) => $"{(i + 1).ToString().PadRight(3)}{(a.Street + " " + a.StreetNumber).PadRight(15)}{a.ZipCode.PadRight(15)}{a.City.PadRight(15)}{a.Country.Name.PadRight(15)}",
            X,
            Y
        );
        addressTable.Draw();
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
