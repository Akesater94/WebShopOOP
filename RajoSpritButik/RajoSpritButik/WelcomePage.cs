using Entities.Models;

namespace RajoSpritButik;

internal class WelcomePage : Page
{

    public List<Product> Products { get; set; }

    public char? SelectedItem = null;

    public WelcomePage(int x, int y, int width, int height) : base(x, y, width, height)
    {
        Products = new List<Product>
        {
            new Product {Name = "Test1"},
            new Product {Name = "Test2"},
            new Product {Name = "Test3"},
        };
    }

    public override void Draw()
    {
        int nextX = X;
        int nextY = Y;
        char nextChar = 'A';
        foreach (Product product in Products)
        {
            List<string> items = new() { product.Name, "Press " + nextChar.ToString() + " to select this product" };
            Window productWindow = new("", nextX, nextY, items);
            if (nextX + productWindow.WindowWidth > Width)
            {
                nextX = 0;
                productWindow.Left = nextX;
                nextY += 5;
                productWindow.Top = nextY;
            }
            productWindow.Draw();
            var charValue = (int)nextChar;
            nextChar = (char)(charValue + 1);
            nextX += productWindow.WindowWidth + 2;
        }
    }

    public override void HandleInput()
    {
        SelectedItem = Console.ReadKey(true).KeyChar;
    }

    public override Page? ChangePage()
    {
        return null;
    }
}
