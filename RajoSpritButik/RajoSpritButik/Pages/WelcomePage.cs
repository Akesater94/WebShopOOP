using Entities.Models;

namespace RajoSpritButik.Pages;

internal class WelcomePage : Page
{
    public List<Product> Products { get; set; } = [];

    public char? SelectedItem = null;

    public WelcomePage(List<Product> products, int x, int y, int width, int height) : base(x, y, width, height)
    {
        Products = products;
    }

    public override void Draw()
    {
        int nextX = X;
        int nextY = Y;
        char nextChar = 'A';
        foreach (Product product in Products)
        {
            List<string> items = new() {
                product.Name,
                "Pris: " + product.Price.ToString() + "kr",
                "Tryck " + nextChar.ToString() + " för att välja produkt"
            };
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
        switch (SelectedItem.ToString().ToUpper())
        {
            case "A":
                ShouldChangePage = true;
                break;
            case "B":
                ShouldChangePage = true;
                break;
            case "C":
                ShouldChangePage = true;
                break;
            default:
                ShouldChangePage = false;
                break;
        }
    }

    public override ChangePageRequest? ChangePage()
    {
        if (ShouldChangePage)
        {
            return new ChangePageRequest() { Page = "products", Query = SelectedItem.ToString() };
        }
        else
        {
            return null;
        }
    }
}