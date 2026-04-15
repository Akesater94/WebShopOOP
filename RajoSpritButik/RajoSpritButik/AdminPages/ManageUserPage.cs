using Entities.Models;

namespace RajoSpritButik.AdminPages;

internal class ManageUserPage : Page
{
    public User User { get; set; }
    public char SelectedItem { get; private set; }
    private ChangePageRequest? request;
    public ManageUserPage(User user)
    {
        User = user;
    }

    public override ChangePageRequest? ChangePage()
    {
        return request;
    }

    public override void Draw()
    {
        List<string> menuContent = new List<string>()
            {
                "1. Ändra info för användaren",
                "2. Se användares kontaktinformation",
                "3. Se användarens ordrar",
                "4. Se användarens adresser"

            };
        Window menuWindow = new Window("Användarmeny", X, Y, menuContent);
        menuWindow.Draw();
    }

    public override void HandleInput()
    {
        SelectedItem = Console.ReadKey().KeyChar;
        switch (SelectedItem)
        {
            case '1':
                request = new ChangePageRequest { Page = "update-user", Query = User.Id };
                break;
            case '2':
                request = new ChangePageRequest { Page = "user-contact-infos", Query = User.Id };
                break;
            case '3':
                request = new ChangePageRequest { Page = "user-orders", Query = User.Id };
                break;
            case '4':
                request = new ChangePageRequest { Page = "user-addresses", Query = User.Id };
                break;
            case 'c':
                request = new ChangePageRequest { Page = "manage-users" };
                break;
            default:
                request = null;
                break;
        }
        ShouldChangePage = true;
    }
}
