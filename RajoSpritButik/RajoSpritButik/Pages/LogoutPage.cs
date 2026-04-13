namespace RajoSpritButik.Pages;

internal class LogoutPage : Page
{
    char? SelectedItem { get; set; }
    public LogoutPage()
    {
    }

    public override ChangePageRequest? ChangePage()
    {
        switch (SelectedItem)
        {
            case 'j':
                return new ChangePageRequest() { Page = "logout", Action = RequestAction.Post };
            case 'n':
                return new ChangePageRequest() { Page = "menu" };
            default:
                return null;
        }
    }

    public override void Draw()
    {
        List<string> logoutList = new()
        {
            "Vill du logga ut?",
            "(J)a / (N)ej)"
        };
        Window logoutWindow = new("Logga ut", X, Y, logoutList);
        logoutWindow.Draw();
    }

    public override void HandleInput()
    {
        SelectedItem = Console.ReadKey().KeyChar;
        switch (SelectedItem)
        {
            case 'j':
                ShouldChangePage = true;
                break;
            case 'n':
                ShouldChangePage = true;
                break;
            default:
                ShouldChangePage = false;
                break;
        }
    }
}
