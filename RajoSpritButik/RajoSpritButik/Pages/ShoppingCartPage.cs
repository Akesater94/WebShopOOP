using Entities.Models;

namespace RajoSpritButik.Pages;

internal class ShoppingCartPage : Page
{
    ShoppingCart? ShoppingCart { get; set; }
    List<ShoppingCartRow> ShoppingCartRows { get; set; } = new();
    public char? SelectedItem { get; set; }
    public ShoppingCartRow SelectedRow { get; set; }
    public bool deleteMode { get; set; }
    public ShoppingCartPage(ShoppingCart? shoppingCart, int x, int y, int width, int height) : base(x, y, width, height)
    {
        ShoppingCart = shoppingCart;
        if (shoppingCart != null)
        {
            ShoppingCartRows = shoppingCart.ShoppingCartRows.ToList();
        }
    }
    public override ChangePageRequest? ChangePage()
    {
        if (deleteMode)
        {
            return new ChangePageRequest() { Page = "shopping-cart-row", Action = RequestAction.Delete, Query = SelectedRow.Id };
        }
        switch (SelectedItem)
        {
            case 'c':
                return new ChangePageRequest() { Page = "menu" };
            case 'x':
                return new ChangePageRequest() { Page = "checkout" };
            default:
                return null;
        }
    }

    public override void Draw()
    {
        List<string> cartItems = new List<string>();
        if (ShoppingCart != null)
        {
            cartItems.Add($"{"#".PadRight(3)}{"Namn".PadRight(15)}{"Antal".PadRight(15)}{"Pris".PadRight(15)}{"Totalpris".PadRight(15)}");
            cartItems.Add("");

            for (int i = 0; i < ShoppingCartRows.Count; i++)
            {
                var row = ShoppingCartRows[i];
                var product = row.Product;
                string productIndex = (i + 1).ToString();
                string productName = product.Name.Length <= 10 ? product.Name : product.Name.Substring(0, 7) + "...";
                string productQuantity = row.Quantity.ToString() + "st";
                string productPrice = product.Price.ToString() + "kr";
                string totalProductPrice = (product.Price * row.Quantity).ToString() + "kr";
                cartItems.Add($"{productIndex.PadRight(3)}{productName.PadRight(15)}{productQuantity.PadRight(15)}{productPrice.PadRight(15)}{totalProductPrice.PadRight(15)}");
            }

        }
        else
        {
            cartItems.Add("Kunde inte hitta din varukorg!");
        }
        Window menuWindow = new Window("Varukorg", X, Y, cartItems);
        menuWindow.Draw();
        if (!deleteMode)
        {
            Console.WriteLine("Tryck D för att kunna välja produkt att ta bort.");
            Console.WriteLine("Tryck C för att gå tillbaka till menyn.");
            Console.WriteLine("Tryck X för att gå till betalning.");
        }
        else
        {
            Console.Write("Välj en produkt att ta bort: ");
        }
    }

    public override void HandleInput()
    {
        if (deleteMode)
        {
            var key = Console.ReadKey().KeyChar;
            if (int.TryParse(key.ToString(), out var id))
            {
                id -= 1;
                if (id < ShoppingCartRows.Count && id >= 0)
                {
                    SelectedRow = ShoppingCartRows[id];
                    ShouldChangePage = true;
                }
            }
        }
        else
        {
            SelectedItem = Console.ReadKey().KeyChar;
            switch (SelectedItem)
            {
                case 'd':
                    deleteMode = true;
                    break;
                case 'c':
                    ShouldChangePage = true;
                    break;
                case 'x':
                    ShouldChangePage= true;
                    break;
                default:
                    ShouldChangePage = false;
                    break;
            }
        }
    }
}
