using Entities.Models;

namespace RajoSpritButik.Pages
{
    internal class MenuPage : Page
    {
        public char? SelectedItem { get; set; }
        public User? User { get; set; }
        public MenuPage(User? user, int x, int y, int width, int height) : base(x, y, width, height)
        {
            User = user;
        }
        public override ChangePageRequest? ChangePage()
        {
            if (ShouldChangePage)
            {
                switch (SelectedItem)
                {
                    case '1':
                        return new ChangePageRequest() { Page = "welcome" };
                    case '2':
                        return new ChangePageRequest() { Page = "categories" };
                    case '3':
                        return new ChangePageRequest() { Page = "shopping-cart" };
                    case '4':
                        if (User == null)
                        {
                            return new ChangePageRequest() { Page = "login" };
                        }
                        else
                        {
                            return new ChangePageRequest() { Page = "logout" };
                        }
                    case '5':
                        if (User?.Role.Name == "Admin")
                        {
                            return new ChangePageRequest() { Page = "admin-menu" };
                        }
                        break;
                    default:
                        return null;
                }
            }
            return null;

        }

        public override void Draw()
        {
            List<string> menuContent = new List<string>()
            {
                "1. Hem",
                "2. Handla",
                "3. Gå till varukorg",

            };
            if (User == null)
            {
                menuContent.Add("4. Logga in");
            }
            else
            {
                menuContent.Add("4. Logga ut");
            }
            if (User?.Role.Name == "Admin")
            {
                menuContent.Add("5. Admin");
            }
            Window menuWindow = new Window("Menu", X, Y, menuContent);
            menuWindow.Draw();
        }

        public override void HandleInput()
        {

            SelectedItem = Console.ReadKey().KeyChar;
            switch (SelectedItem)
            {
                case '1':
                    ShouldChangePage = true;
                    break;
                case '2':
                    ShouldChangePage = true;
                    break;
                case '3':
                    ShouldChangePage = true;
                    break;
                case '4':
                    ShouldChangePage = true;
                    break;
                case '5':
                    if (User?.Role.Name == "Admin")
                    {
                        ShouldChangePage = true;
                    }
                    break;
                default:
                    ShouldChangePage = false;
                    break;
            }
        }
    }
}
