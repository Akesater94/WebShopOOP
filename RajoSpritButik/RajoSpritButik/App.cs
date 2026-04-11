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
    public IShippingAlternativeService ShippingAlternativeService { get; set; }
    public ICategoryService CategoryService { get; set; }
    public IAddressService AddressService { get; set; }
    public IShoppingCartService ShoppingCartService { get; set; }
    public ICountryService CountryService { get; set; }
    public IUserService UserService { get; set; }
    public IUserAddressService UserAddressService { get; set; }
    public IPaymentAlternativeService PaymentAlternativeService { get; set; }

    User? User { get; set; }
    bool LoggedIn => User != null;
    public App()
    {
        Context = new();
        ProductService = new ProductService(new ProductRepository(Context));
        CategoryService = new CategoryService(new CategoryRepository(Context));
        ShoppingCartService = new ShoppingCartService(new ShoppingCartRepository(Context));
        UserAddressService = new UserAddressService(new UserAddressRepository(Context));
        UserService = new UserService(new UserRepository(Context), UserAddressService);
        CountryService = new CountryService(new CountryRepository(Context));
        AddressService = new AddressService(new AddressRepository(Context), CountryService);
        ShippingAlternativeService = new ShippingAlternativeService(new ShippingAlternativeRepository(Context));
        PaymentAlternativeService = new PaymentAlternativeService(new PaymentAlternativeRepository(Context));
    }
    public async Task Run()
    {
        await ChangePage(new ChangePageRequest { Page = "menu" });
        while (true)
        {
            Page.X = 0;
            Page.Y = 10;
            Page.Width = Console.WindowWidth - 30;
            Page.Height = 40;

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
        Context = new();
        ProductService = new ProductService(new ProductRepository(Context));
        CategoryService = new CategoryService(new CategoryRepository(Context));
        ShoppingCartService = new ShoppingCartService(new ShoppingCartRepository(Context));
        UserAddressService = new UserAddressService(new UserAddressRepository(Context));
        UserService = new UserService(new UserRepository(Context), UserAddressService);
        CountryService = new CountryService(new CountryRepository(Context));
        AddressService = new AddressService(new AddressRepository(Context), CountryService);
        ShippingAlternativeService = new ShippingAlternativeService(new ShippingAlternativeRepository(Context));
        PaymentAlternativeService = new PaymentAlternativeService(new PaymentAlternativeRepository(Context));

        switch (request.Page)
        {
            case "welcome":
                List<Product> showcaseProducts = await ProductService.GetShowCaseProductsAsync();
                Page = new WelcomePage(showcaseProducts);
                break;

            case "menu":
                Page = new MenuPage(User);
                break;

            case "categories":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        List<Category> categories = await CategoryService.GetAllCategoriesAsync();
                        Page = new CategoriesPage(categories);
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
                            Page = new CategoryPage(productsByCategory);
                        }
                        break;
                }
                break;
            case "product":
                switch (request.Action)
                {
                    case RequestAction.Patch:
                        {
                            if (request.Query is Product product)
                            {
                                await ProductService.UpdateAsync(product);
                                await ChangePage(new() { Page = "update-product", Query = product.Id, Action = RequestAction.Get });
                            }
                        }
                        break;
                    case RequestAction.Post:
                        {
                            if (request.Query is Product product)
                            {
                                await ProductService.UpdateAsync(product);
                                await ChangePage(new() { Page = "manage-products" });
                            }
                        }
                        break;
                    case RequestAction.Delete:
                        {
                            if (request.Query is int id)
                            {
                                if (await ProductService.GetProductByIdWithDetailsAsync(id) is Product product)
                                {
                                    await ProductService.RemoveAsync(product);
                                }
                                await ChangePage(new() { Page = "manage-products" });
                            }
                        }
                        break;
                }
                break;
            case "user-address":
                switch (request.Action)
                {
                    case RequestAction.Post:
                        if (request.Query is Address address)
                        {
                            await AddressService.AddAddressAsync(address);
                            await UserAddressService.AddUserAddressAsync(User.Id, address.Id);
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
                        Page = new ShoppingCartPage(shoppingCart);
                        break;
                }
                break;

            case "checkout":
                {
                    if (User != null)
                    {
                        List<Address> addresses = await UserService.GetAllAddressesAsync(User.Id);
                        ShoppingCart? shoppingCart = await ShoppingCartService.GetByUserIdAsync(User.Id);
                        List<ShippingAlternative> shippingAlternatives = await ShippingAlternativeService.GetAllShippingAlternativesAsync();

                        List<PaymentAlternative> paymentAlternatives = await PaymentAlternativeService.GetAllPaymentAlternativesAsync();

                        Page = new CheckoutPage(addresses, shoppingCart, shippingAlternatives, paymentAlternatives);
                    }
                    break;
                }
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
                        Page = new ShoppingCartPage(shoppingCart);
                        break;

                    case RequestAction.Post:

                        if (request.Query is int productId)
                        {
                            shoppingCart = null;
                            if (User != null)
                            {
                                shoppingCart = await ShoppingCartService.GetByUserIdAsync(User.Id);
                            }
                            await ShoppingCartService.AddRowAsync(shoppingCart.Id, productId);
                        }
                        break;
                }
                break;
            case "login":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        Page = new LoginPage();
                        break;
                    case RequestAction.Post:
                        if (request.Query is string userName)
                        {
                            User = await UserService.GetUserByUserNameAsync(userName);
                        }
                        Page = new MenuPage(User);
                        break;
                }
                break;
            case "logout":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        Page = new LogoutPage();
                        break;
                    case RequestAction.Post:
                        User = null;
                        Page = new MenuPage(User);
                        break;
                }
                break;
            case "admin-menu":
                if (User?.Role.Name == "Admin")
                {
                    Page = new AdminMenuPage();
                }
                else
                {
                    Page = new MenuPage(User);
                }
                break;
            case "manage-products":
                List<Product> products = await ProductService.GetProductsWithDetailsAsync();
                Page = new ManageProductsPage(products);
                break;
            case "update-product":
                {
                    if (request.Query is int id)
                    {
                        Product? product = await ProductService.GetProductByIdWithDetailsAsync(id);
                        if (product != null)
                        {
                            Page = new UpdateProductPage(product);
                        }
                        else
                        {
                            await ChangePage(new() { Page = "manage-products" });
                        }
                    }
                }
                break;
            case "create-product":
                Page = new CreateProductPage();
                break;

            default:
                Console.WriteLine(request.Page);
                Console.WriteLine(request.Query);
                Console.ReadKey();
                break;
        }
    }
}
