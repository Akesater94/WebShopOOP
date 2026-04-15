namespace RajoSpritButik.AdminPages;

internal class StatsMenuPage : Page
{
    private ChangePageRequest? request;
    public override ChangePageRequest? ChangePage()
    {
        return request;
    }

    public override void Draw()
    {
        List<string> menuContent = new List<string>()
            {
                "1. Mest sålda produkter"
            };
        Window menuWindow = new Window("Adminmeny", X, Y, menuContent);
        menuWindow.Draw();
    }

    public override void HandleInput()
    {
        ShouldChangePage = true;
        char input = Console.ReadKey().KeyChar;
        switch (input)
        {
            case '1':
                request = new ChangePageRequest() { Page = "most-sold-products" };
                break;
            case 'c':
                request = new ChangePageRequest() { Page = "admin-menu" };
                break;
            default:
                ShouldChangePage = false;
                break;
        }
    }
}
