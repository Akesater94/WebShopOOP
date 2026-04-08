namespace RajoSpritButik.Pages;

internal class LoginPage : Page
{
    string UserName { get; set; } = "";
    public LoginPage(int x, int y, int width, int height) : base(x, y, width, height)
    {
    }

    public override ChangePageRequest? ChangePage()
    {
        return new ChangePageRequest { Page = "login", Action = RequestAction.Post, Query = UserName };
    }

    public override void Draw()
    {
        List<string> loginList = new()
        {
            UserName.PadRight(20)
        };
        Window userNameWindow = new("User name", 0, Y, loginList);
        userNameWindow.Draw();
    }

    public override void HandleInput()
    {
        Console.SetCursorPosition(X + UserName.Length + 1, Y + 1);
        UserName = Console.ReadLine() ?? "";
        ShouldChangePage = true;
    }
}