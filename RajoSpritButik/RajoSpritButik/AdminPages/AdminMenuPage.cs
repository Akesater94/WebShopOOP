namespace RajoSpritButik.AdminPages;

internal class AdminMenuPage : Page
{
    public AdminMenuPage(int x, int y, int width, int height) : base(x, y, width, height)
    {
    }

    public char SelectedItem { get; private set; }

    public override ChangePageRequest? ChangePage()
    {
        if (ShouldChangePage)
        {
            switch (SelectedItem)
            {
                case '1':
                    return new ChangePageRequest() { Page = "manage-products" };
                case '2':
                    return new ChangePageRequest() { Page = "manage-categories" };
                case '3':
                    return new ChangePageRequest() { Page = "manage-users" };
                case 'c':
                    return new ChangePageRequest() { Page = "menu" };
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
                "1. Hantera produkter",
                "2. Hantera kategorier",
                "3. Hantera användare"
            };
        Window menuWindow = new Window("Adminmeny", X, Y, menuContent);
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
            case 'c':
                ShouldChangePage = true;
                break;
            default:
                ShouldChangePage = false;
                break;
        }
    }
}
