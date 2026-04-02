namespace RajoSpritButik;

internal class App
{
    public void Run()
    {
        while (true)
        {
            Console.Clear();
            DrawHeader();

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
