using EFCore;
using EFCore.Repositories;
using Entities.Models;
using RajoSpritButik.Pages;
using Services;
using Services.Interfaces;

namespace RajoSpritButik;

internal class App
{
    public Page Page { get; set; } = null!;
    public RajoDbContext Context { get; set; }
    public IProductService ProductService { get; set; }
    public ICategoryService CategoryService { get; set; }
    public IShoppingCartService ShoppingCartService { get; set; }
    public App()
    {
        Context = new();
        ProductRepository productRepository = new(Context);
        ProductService = new ProductService(productRepository);

        CategoryRepository categoryRepository = new(Context);
        CategoryService = new CategoryService(categoryRepository);

        ShoppingCartRepository shoppingCartRepository = new(Context);
        ShoppingCartService = new ShoppingCartService(shoppingCartRepository);
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
            case "categories":
                List<Category> categories = await CategoryService.GetAllCategoriesAsync();
                Page = new CategoriesPage(categories, 0, 10, Console.WindowWidth - 30, 40);
                break;
            case "category":
                List<Product> productsByCategory = await ProductService.GetAllProductsByCategoryAsync(int.Parse(request.Query));
                Page = new CategoryPage(productsByCategory, 0, 10, Console.WindowWidth - 30, 40);
                break;
            case "shopping-cart":
                ShoppingCart? shoppingCart = await ShoppingCartService.GetByUserIdAsync(2);
                Page = new ShoppingCartPage(shoppingCart, 0, 10, Console.WindowWidth - 30, 40);
                break;
            default:
                Console.WriteLine(request.Page);
                Console.WriteLine(request.Query);
                Console.ReadKey();
                break;
        }
    }
}
