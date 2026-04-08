using Entities.Models;

namespace RajoSpritButik.Pages;

internal class CategoryPage : Page
{
    public Product SelectedItem { get; set; }
    public List<Product> Products { get; set; } = [];


    public CategoryPage(List<Product> products, int x, int y, int width, int height) : base(x, y, width, height)
    {
        Products = products;
    }

    public override ChangePageRequest? ChangePage()
    {
        if (ShouldChangePage && SelectedItem != null)
        {
            return new ChangePageRequest() { Page = "product", Query = SelectedItem.Id };
        }
        return null;
    }

    public override void Draw()
    {
        int nextX = X;
        int nextY = Y;
        foreach (var products in Products)
        {
            List<string> productInfo = new List<string>();
            productInfo.Add($"Pris: {products.Price.ToString()}");
            productInfo.Add($"Lagersaldo: {products.Stock.ToString()}");

            Window productWindow = new Window($"{products.Name}", nextX, nextY, productInfo);
            if (nextX + productWindow.WindowWidth > Width)
            {
                nextX = 0;
                productWindow.Left = nextX;
                nextY += 5;
                productWindow.Top = nextY;
            }
            nextX += productWindow.WindowWidth + 2;
            productWindow.Draw();
        }
    }

    public override void HandleInput()
    {
        Console.ReadKey();
    }
}
