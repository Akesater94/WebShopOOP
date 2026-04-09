using EFCore;
using EFCore.Repositories;
using Entities.Models;
using RajoSpritButik.AdminPages;
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
    public IUserService UserService { get; set; }
    User? User { get; set; }
    bool LoggedIn => User != null;
    public App()
    {
        Context = new();
        ProductRepository productRepository = new(Context);
        ProductService = new ProductService(productRepository);

        CategoryRepository categoryRepository = new(Context);
        CategoryService = new CategoryService(categoryRepository);

        ShoppingCartRepository shoppingCartRepository = new(Context);
        ShoppingCartService = new ShoppingCartService(shoppingCartRepository);

        UserRepository userRepository = new(Context);
        UserService = new UserService(userRepository);
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
        List<string> listItems = new() { "Rajos Spritbutik", "Kunglig hovleverantör", User?.UserName ?? "" };

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
                Page = new MenuPage(User, 0, 10, Console.WindowWidth - 30, 40);
                break;

            case "categories":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        List<Category> categories = await CategoryService.GetAllCategoriesAsync();
                        Page = new CategoriesPage(categories, 0, 10, Console.WindowWidth - 30, 40);
                        break;
                }
                break;

            case "category":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        if (request.Query is int id)
                        {
                            List<Product> productsByCategory = await ProductService.GetAllProductsByCategoryAsync(id);
                            Page = new CategoryPage(productsByCategory, 0, 10, Console.WindowWidth - 30, 40);
                        }
                        break;
                }
                break;

            case "shopping-cart":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        ShoppingCart? shoppingCart = null;
                        if (User != null)
                        {
                            shoppingCart = await ShoppingCartService.GetByUserIdAsync(User.Id);
                        }
                        Page = new ShoppingCartPage(shoppingCart, 0, 10, Console.WindowWidth - 30, 100);
                        break;
                }
                break;

            case "shopping-cart-row":
                switch (request.Action)
                {
                    case RequestAction.Delete:
                        if (request.Query is int id)
                        {
                            await ShoppingCartService.RemoveRowAsync(id);
                        }
                        ShoppingCart? shoppingCart = null;
                        if (User != null)
                        {
                            shoppingCart = await ShoppingCartService.GetByUserIdAsync(User.Id);
                        }
                        Page = new ShoppingCartPage(shoppingCart, 0, 10, Console.WindowWidth - 30, 100);
                        break;
                }
                break;
            case "login":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        Page = new LoginPage(0, 10, Console.WindowWidth - 30, 40);
                        break;
                    case RequestAction.Post:
                        if (request.Query is string userName)
                        {
                            User = await UserService.GetUserByUserNameAsync(userName);
                        }
                        Page = new MenuPage(User, 0, 10, Console.WindowWidth - 30, 40);
                        break;
                }
                break;
            case "logout":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        Page = new LogoutPage(0, 10, Console.WindowWidth - 30, 40);
                        break;
                    case RequestAction.Post:
                        User = null;
                        Page = new MenuPage(User, 0, 10, Console.WindowWidth - 30, 40);
                        break;
                }
                break;
            case "admin-menu":
                if (User?.Role.Name == "Admin")
                {
                    Page = new AdminMenuPage(0, 10, Console.WindowWidth - 30, 40);
                }
                else
                {
                    Page = new MenuPage(User, 0, 10, Console.WindowWidth - 30, 40);
                }
                break;
            default:
                Console.WriteLine(request.Page);
                Console.WriteLine(request.Query);
                Console.ReadKey();
                break;
        }
    }
}
