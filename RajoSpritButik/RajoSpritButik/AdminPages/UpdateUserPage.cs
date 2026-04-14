using Entities.Models;

namespace RajoSpritButik.AdminPages;

internal class UpdateUserPage : Page
{
    public User User { get; set; }
    private ChangePageRequest? request;
    private char? selectedField;
    public UpdateUserPage(User user)
    {
        User = user;
    }
    public override ChangePageRequest? ChangePage()
    {
        return request;
    }

    public override void Draw()
    {
        List<string> productFields = new()
        {
            $"1. Namn: {User.Name}",
            $"2. Användarnamn: {User.UserName}",
            $"3. Roll: {User.Role.Name} ({User.RoleId})",
            $"4. Kontot skapades: {User.CreatedAt.ToString()}",
        };
        Window productWindow = new("Vald produkt", X, Y, productFields);
        productWindow.Draw();

        switch (selectedField)
        {
            case '1': Console.Write("Skriv in ett nytt namn för användare: "); break;
            case '2': Console.Write("Skriv in ett nytt användarnamn för användaren: "); break;
            case '3': Console.Write("Skriv in ID:t för den nya rollen: "); break;
            case '4': Console.Write("Skriv in ett nytt datum för när kontot skapades: "); break;
            default:
                Console.WriteLine("Tryck 1-4 för att redigera ett fält.");
                Console.WriteLine("Tryck C för att gå tillbaka");
                break;
        }
    }

    public override void HandleInput()
    {
        if (selectedField == null)
        {
            var key = Console.ReadKey(true).KeyChar;
            if (key >= '1' && key <= '4')
            {
                selectedField = key;
            }
            if (key == 'c' || key == 'C')
            {
                request = new ChangePageRequest() { Page = "manage-user", Query = User.Id };
                ShouldChangePage = true;
            }
        }
        else
        {
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                switch (selectedField)
                {
                    case '1':
                        User.Name = input;
                        break;
                    case '2':
                        User.UserName = input;
                        break;
                    case '3':
                        if (int.TryParse(input, out var roleId))
                        {
                            User.RoleId = roleId;
                            User.Role = null!;
                        }
                        break;
                    case '4':
                        if (DateTime.TryParse(input, out var createdAt))
                        {
                            User.CreatedAt = createdAt;
                        }
                        break;
                }
            }
            request = new ChangePageRequest() { Page = "user", Action = RequestAction.Patch, Query = User };
            ShouldChangePage = true;
        }
    }
}
