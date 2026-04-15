using EFCore;
using EFCore.Repositories;
using Entities.Models;
using RajoSpritButik.AdminPages;
using RajoSpritButik.AdminPages.StatsPages;
using RajoSpritButik.Pages;
using Services;
using Services.DTOs;

namespace RajoSpritButik;

internal class App
{
    public Page Page { get; set; } = null!;
    User? User { get; set; }
    bool LoggedIn => User != null;
    public App()
    {
    }
    public async Task Run()
    {
        await ChangePage(new ChangePageRequest { Page = "menu" });

        Console.BufferHeight = 100;

        while (true)
        {
            Page.X = 0;
            Page.Y = 6;
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
        using RajoDbContext context = new();
        ProductService productService = new ProductService(new ProductRepository(context));
        CategoryService categoryService = new CategoryService(new CategoryRepository(context));
        ShoppingCartService shoppingCartService = new ShoppingCartService(new ShoppingCartRepository(context));
        UserAddressService userAddressService = new UserAddressService(new UserAddressRepository(context));
        ContactInfoService contactInfoService = new ContactInfoService(new ContactInfoRepository(context));
        UserService userService = new UserService(new UserRepository(context), userAddressService, contactInfoService);
        CountryService countryService = new CountryService(new CountryRepository(context));
        AddressService addressService = new AddressService(new AddressRepository(context), countryService);
        ShippingAlternativeService shippingAlternativeService = new ShippingAlternativeService(new ShippingAlternativeRepository(context));
        PaymentAlternativeService paymentAlternativeService = new PaymentAlternativeService(new PaymentAlternativeRepository(context));
        OrderService orderService = new OrderService(new OrderRepository(context), shoppingCartService);

        switch (request.Page)
        {
            case "welcome":
                List<Product> showcaseProducts = await productService.GetShowCaseProductsAsync();
                Page = new WelcomePage(showcaseProducts);
                break;

            case "menu":
                Page = new MenuPage(User);
                break;

            case "browse-page":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        {
                            List<Category> categories = await categoryService.GetAllCategoriesAsync();
                            Page = new BrowsePage(categories);
                        }
                        break;
                }
                break;
            case "search":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        {
                            Page = new SearchPage();
                        }
                        break;
                    case RequestAction.Post:
                        {
                            if (request.Query is string searchTerm)
                            {
                                if (searchTerm == string.Empty)
                                {
                                    await ChangePage(new ChangePageRequest() { Page = "browse-page" });
                                }
                                else
                                {
                                    List<Product> products = await productService.SearchProductsAsync(searchTerm);
                                    Page = new ProductsPage(products);
                                }
                            }
                        }
                        break;
                }
                break;
            case "category":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        {
                            if (request.Query is int id)
                            {
                                List<Product> productsByCategory = await productService.GetAllProductsByCategoryAsync(id);
                                Page = new ProductsPage(productsByCategory);
                            }
                        }
                        break;
                    case RequestAction.Post:
                        {
                            if (request.Query is Category category)
                            {
                                await categoryService.AddCategoryAsync(category);
                                await ChangePage(new ChangePageRequest { Page = "manage-categories" });
                            }
                        }
                        break;
                    case RequestAction.Patch:
                        {
                            if (request.Query is Category category)
                            {
                                await categoryService.UpdateCategoryAsync(category);
                                await ChangePage(new ChangePageRequest { Page = "update-category", Query = category.Id });
                            }
                        }
                        break;
                    case RequestAction.Delete:
                        {
                            if (request.Query is int id)
                            {
                                await categoryService.RemoveCategoryAsync(id);
                            }
                        }
                        await ChangePage(new ChangePageRequest { Page = "manage-categories" });
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
                                await productService.UpdateAsync(product);
                                await ChangePage(new() { Page = "update-product", Query = product.Id, Action = RequestAction.Get });
                            }
                        }
                        break;
                    case RequestAction.Post:
                        {
                            if (request.Query is Product product)
                            {
                                await productService.UpdateAsync(product);
                                await ChangePage(new() { Page = "manage-products" });
                            }
                        }
                        break;
                    case RequestAction.Delete:
                        {
                            if (request.Query is int id)
                            {
                                if (await productService.GetProductAsync(id) is Product product)
                                {
                                    await productService.RemoveAsync(product);
                                }
                                await ChangePage(new() { Page = "manage-products" });
                            }
                        }
                        break;
                    case RequestAction.Get:
                        {
                            if (request.Query is int id)
                            {
                                Product? product = await productService.GetProductAsync(id);
                                Page = new ProductDetailsPage(product!, request.Redirect);
                            }
                            break;
                        }
                }
                break;

            case "user":
                switch (request.Action)
                {
                    case RequestAction.Patch:
                        {
                            if (request.Query is User user)
                            {
                                await userService.UpdateAsync(user);
                                await ChangePage(new ChangePageRequest { Page = "update-user", Query = user.Id });
                            }
                        }
                        break;
                    case RequestAction.Delete:
                        {
                            if (request.Query is int id)
                            {
                                await userService.RemoveUserAsync(id);
                            }
                            await ChangePage(new ChangePageRequest { Page = "manage-users" });
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
                            await addressService.AddAddressAsync(address);
                            await userAddressService.AddUserAddressAsync(User.Id, address.Id);
                        }
                        break;
                }
                break;

            case "user-contact-infos":
                {
                    if (request.Query is int id)
                    {
                        List<ContactInfo> contactInfos = await userService.GetContactInfosAsync(id);
                        Page = new UserContactInfosPage(contactInfos, id);
                    }
                }
                break;

            case "user-orders":
                {
                    if (request.Query is int id)
                    {
                        List<Order> orders = await orderService.GetOrdersByUserIdAsync(id);
                        Page = new UserOrdersPage(orders, id);
                    }

                }
                break;
            case "user-addresses":
                {
                    if (request.Query is int id)
                    {
                        List<Address> addresses = await userAddressService.GetAllAddressesAsync(id);
                        Page = new UserAddressesPage(addresses, id);
                    }
                }
                break;
            case "shopping-cart":
                switch (request.Action)
                {
                    case RequestAction.Get:
                        ShoppingCart? shoppingCart = null;
                        if (User != null)
                        {
                            shoppingCart = await shoppingCartService.GetByUserIdAsync(User.Id);
                        }
                        Page = new ShoppingCartPage(shoppingCart);
                        break;
                }
                break;

            case "checkout":
                {
                    if (User != null)
                    {
                        List<Address> addresses = await userService.GetAllAddressesAsync(User.Id);
                        ShoppingCart? shoppingCart = await shoppingCartService.GetByUserIdAsync(User.Id);
                        List<ShippingAlternative> shippingAlternatives = await shippingAlternativeService.GetAllShippingAlternativesAsync();
                        List<PaymentAlternative> paymentAlternatives = await paymentAlternativeService.GetAllPaymentAlternativesAsync();

                        Page = new CheckoutPage(addresses, shoppingCart, shippingAlternatives, paymentAlternatives);
                    }
                    break;
                }
            case "order":
                switch (request.Action)
                {
                    case RequestAction.Post:
                        {
                            if (User == null)
                            {
                                return;
                            }

                            if (request.Query is (int adressId, int paymentId, int shippingId, int shoppingCartId))
                            {
                                Order? order = await orderService.AddOrderAsync(User.Id, adressId, paymentId, shippingId, shoppingCartId);

                                Page = new OrderConfirmationPage(order!);
                            }
                        }
                        break;
                }
                break;
            case "shopping-cart-row":
                switch (request.Action)
                {
                    case RequestAction.Delete:
                        if (request.Query is int id)
                        {
                            await shoppingCartService.RemoveRowAsync(id);
                        }
                        ShoppingCart? shoppingCart = null;
                        if (User != null)
                        {
                            shoppingCart = await shoppingCartService.GetByUserIdAsync(User.Id);
                        }
                        Page = new ShoppingCartPage(shoppingCart);
                        break;
                    case RequestAction.Patch:
                        {
                            if (request.Query is ShoppingCartRow shoppingCartRow)
                            {
                                await shoppingCartService.UpdateRowAsync(shoppingCartRow);
                            }
                            await ChangePage(new ChangePageRequest() { Page = "shopping-cart" });
                        }
                        break;
                    case RequestAction.Post:

                        if (request.Query is int productId)
                        {
                            shoppingCart = null;
                            if (User != null)
                            {
                                shoppingCart = await shoppingCartService.GetByUserIdAsync(User.Id);
                                await shoppingCartService.AddRowAsync(shoppingCart.Id, productId);
                            }
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
                            User = await userService.GetUserByUserNameAsync(userName);
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
                {
                    List<Product> products = await productService.GetProductsWithDetailsAsync();
                    Page = new ManageProductsPage(products);
                }
                break;
            case "update-product":
                {
                    if (request.Query is int id)
                    {
                        Product? product = await productService.GetProductAsync(id);
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
            case "manage-categories":
                {
                    List<Category> categories = await categoryService.GetAllCategoriesAsync();
                    Page = new ManageCategoriesPage(categories);
                }
                break;
            case "create-category":
                Page = new CreateCategoryPage();
                break;
            case "update-category":
                {
                    if (request.Query is int id)
                    {
                        Category? category = await categoryService.GetCategoryAsync(id);
                        if (category != null)
                        {
                            Page = new UpdateCategoryPage(category);
                        }
                        else
                        {
                            await ChangePage(new ChangePageRequest { Page = "manage-categories" });
                        }
                    }
                }
                break;
            case "manage-users":
                {
                    List<User> users = await userService.GetAllUsersAsync();
                    Page = new ManageUsersPage(users);
                }
                break;
            case "manage-user":
                {
                    if (request.Query is int id)
                    {
                        User? user = await userService.GetUserAync(id);
                        if (user != null)
                        {
                            Page = new ManageUserPage(user);
                        }
                        else
                        {
                            await ChangePage(new ChangePageRequest { Page = "manage-users" });
                        }
                    }
                }
                break;
            case "update-user":
                {
                    if (request.Query is int id)
                    {
                        User? user = await userService.GetUserAync(id);
                        if (user != null)
                        {
                            Page = new UpdateUserPage(user);
                        }
                        else
                        {
                            await ChangePage(new ChangePageRequest { Page = "manage-user", Query = id });
                        }
                    }
                }
                break;

            case "stats":
                Page = new StatsMenuPage();
                break;
            case "most-sold-products":
                List<MostSoldProductDTO> mostSoldProducts = await productService.GetMostSoldProductsAsync(10);
                Page = new MostSoldProductsPage(mostSoldProducts);
                break;
            default:
                Console.WriteLine(request.Page);
                Console.WriteLine(request.Query);
                Console.ReadKey();
                break;
        }
    }
}
