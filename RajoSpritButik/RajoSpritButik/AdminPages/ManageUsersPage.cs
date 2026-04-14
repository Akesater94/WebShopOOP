using Entities.Models;
using RajoSpritButik.UIComponents;

namespace RajoSpritButik.AdminPages;

internal class ManageUsersPage : Page
{
    public List<User> Users { get; set; }
    public char SelectedItem { get; set; }
    public User? SelectedUser { get; set; }
    public char Input { get; set; }
    public bool SelectMode { get; private set; }

    public ManageUsersPage(List<User> users)
    {
        Users = users;
    }
    public override ChangePageRequest? ChangePage()
    {
        if (SelectMode && SelectedUser != null)
        {
            if (Input == 's' || Input == 'S')
            {
                return new ChangePageRequest() { Page = "manage-user", Query = SelectedUser.Id };
            }
            else if (Input == 'd' || Input == 'D')
            {
                return new ChangePageRequest() { Page = "user", Action = RequestAction.Delete, Query = SelectedUser.Id };
            }
        }
        else if (Input == 'c' || Input == 'C')
        {
            return new ChangePageRequest() { Page = "admin-menu" };
        }
        return null;
    }

    public override void Draw()
    {
        Table<User> productTable = new(
            Users,
            "Användare",
            $"{"#".PadRight(3)}{"Namn".PadRight(15)}",
            (u, i) => $"{(i + 1).ToString().PadRight(3)}{u.Name.PadRight(15)}",
            X,
            Y
            );
        productTable.Draw();
        if (SelectMode)
        {
            Console.Write("Vilken användare vill du välja?: ");
        }
        else
        {
            Console.WriteLine("Tryck S för att välja användare att hantera.");
            Console.WriteLine("Tryck D för att välja användare att ta bort.");
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
                if (productId < Users.Count && productId >= 0)
                {
                    SelectedUser = Users[productId];
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
            }
        }
    }
}
