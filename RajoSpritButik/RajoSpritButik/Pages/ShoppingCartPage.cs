using Entities.Models;

namespace RajoSpritButik.Pages;

internal class ShoppingCartPage : Page
{
    ShoppingCart? ShoppingCart { get; set; }
    public char? SelectedItem { get; set; }
    public ShoppingCartPage(ShoppingCart? shoppingCart, int x, int y, int width, int height) : base(x, y, width, height)
    {
        ShoppingCart = shoppingCart;
    }
    public override ChangePageRequest? ChangePage()
    {
        switch (SelectedItem)
        {
            case 'c':
                return new ChangePageRequest() { Page = "menu" };
            default:
                return null;
        }
    }

    public override void Draw()
    {
        List<string> cartItems = new List<string>();
        if (ShoppingCart != null)
        {
            foreach (ShoppingCartRow row in ShoppingCart.ShoppingCartRows)
            {
                cartItems.Add(row.Product.Name + ": " + row.Quantity + "st");
            }
        }
        else
        {
            cartItems.Add("Kunde inte hitta din varukorg!");
        }
        Window menuWindow = new Window("Varukorg", X, Y, cartItems);
        menuWindow.Draw();
    }

    public override void HandleInput()
    {
        SelectedItem = Console.ReadKey().KeyChar;
        switch (SelectedItem)
        {
            case 'c':
                ShouldChangePage = true;
                break;
            default:
                ShouldChangePage = false;
                break;
        }
    }
}
