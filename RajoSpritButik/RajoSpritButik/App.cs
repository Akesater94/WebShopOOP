using EFCore;
using EFCore.Repositories;
using Entities.Models;
using Services;
using Services.Interfaces;

namespace RajoSpritButik;

internal class App
{
    public Page Page { get; set; } = null!;
    public RajoDbContext Context { get; set; }
    public IProductService ProductService { get; set; }
    public App()
    {
        Context = new();
        ProductRepository productRepository = new(Context);
        ProductService = new ProductService(productRepository);
    }
    public async Task Run()
    {
        await ChangePage(new ChangePageRequest { Page = "menu" });
        while (true)
        {
            Page.Width = Console.WindowWidth - 30;
            Console.Clear();
            DrawHeader();
            Page.Draw();
            Page.HandleInput();
            if (Page.ShouldChangePage)
            {
                ChangePageRequest? request = Page.ChangePage();
                if (request != null)
                {
                    await ChangePage(request);
                }
            }
        }
    }

    public void DrawHeader()
    {
        List<string> listItems = new() { "Rajos Spritbutik", "Kunglig hovleverantör" };

        string longestItem = listItems.OrderBy(s => s.Length).First();

        Window window = new Window("", (Console.WindowWidth - longestItem.Length) / 2 - 4, 0, listItems);
        window.Draw();
    }

    public async Task ChangePage(ChangePageRequest request)
    {
        switch (request.Page)
        {
            case "welcome":
                List<Product> showcaseProducts = await ProductService.GetShowCaseProductsAsync();
                Page = new WelcomePage(showcaseProducts, 0, 10, Console.WindowWidth - 30, 40);
                break;
            case "menu":
                Page = new MenuPage(0, 10, Console.WindowWidth - 30, 40);
                break;
            default:
                Console.WriteLine(request.Page);
                Console.WriteLine(request.Query);
                Console.ReadKey();
                break;
        }
    }
}
