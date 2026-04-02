namespace RajoSpritButik;

internal class App
{
    public Page Page { get; set; }
    public void Run()
    {
        Page = new WelcomePage(0, 10, Console.WindowWidth - 30, 40);
        while (true)
        {
            Page.Width = Console.WindowWidth - 30;
            Console.Clear();
            DrawHeader();
            Page.Draw();
            Page.HandleInput();
            if (Page.ShouldChangePage)
            {
                Page? newPage = Page.ChangePage();
                if (newPage != null)
                {
                    Page = newPage;
                }
            }
            Console.ReadKey();
        }
    }

    public void DrawHeader()
    {

        List<string> listItems = new() { "Rajos Spritbutik", "Kunglig hovleverantör" };

        string longestItem = listItems.OrderBy(s => s.Length).First();

        Window window = new Window("", (Console.WindowWidth - longestItem.Length) / 2 - 4, 0, listItems);
        window.Draw();
    }
}
