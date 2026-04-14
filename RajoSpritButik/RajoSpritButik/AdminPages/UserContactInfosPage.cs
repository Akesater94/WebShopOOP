using Entities.Models;
using RajoSpritButik.UIComponents;

namespace RajoSpritButik.AdminPages;

internal class UserContactInfosPage : Page
{
    public List<ContactInfo> ContactInfos { get; set; }
    public int UserId { get; }

    private ChangePageRequest? request;

    public UserContactInfosPage(List<ContactInfo> contactInfos, int userId)
    {
        ContactInfos = contactInfos;
        UserId = userId;
    }

    public override ChangePageRequest? ChangePage()
    {
        return request;
    }

    public override void Draw()
    {
        Table<ContactInfo> contactInfoTable = new(
            ContactInfos,
            "Kontaktinformation",
            $"{"#".PadRight(3)}{"Typ".PadRight(15)}{"Värde".PadRight(15)}",
            (ci, i) => $"{(i + 1).ToString().PadRight(3)}{ci.ContactType.Name.PadRight(15)}{ci.Value.PadRight(15)}",
            X,
            Y
            );
        contactInfoTable.Draw();
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