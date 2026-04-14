using Entities.Models;

namespace RajoSpritButik.Pages;

internal class ShoppingCartPage : Page
{
    ShoppingCart? ShoppingCart { get; set; }
    List<ShoppingCartRow> ShoppingCartRows { get; set; } = new();
    public char? SelectedItem { get; set; }
    public ShoppingCartRow SelectedRow { get; set; } = null!;
    int Step { get; set; }
    public bool deleteMode { get; set; }
    public bool editMode { get; set; }
    public ShoppingCartPage(ShoppingCart? shoppingCart)
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
        else if (editMode)
        {
            return new ChangePageRequest() { Page = "shopping-cart-row", Action = RequestAction.Patch, Query = SelectedRow };
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
            Console.WriteLine("Tryck D för att ta bort hela raden eller ändra antal i en produktrad.");
            Console.WriteLine("Tryck C för att gå tillbaka till menyn.");
            Console.WriteLine("Tryck X för att gå till betalning.");
        }
        else
        {
            switch (Step)
            {
                case 1:
                    Console.WriteLine("Välj en produktrad: ");
                    break;
                case 2:
                    Console.WriteLine("Tryck vänsterpil på tangentbordet för att minska antalet produkter i denna rad med en.");
                    Console.WriteLine("Tryck högerpil på tangentbordet för att öka antalet produkter i denna rad med en.");
                    Console.WriteLine("Tryck D för att ta bort hela produktraden.");
                    Console.WriteLine("Tryck C för att gå tillbaka.");
                    break;
            }
        }
    }
    public override void HandleInput()
    {
        if (deleteMode)
        {
            switch (Step)
            {
                case 1:
                    var key = Console.ReadKey().KeyChar;
                    if (int.TryParse(key.ToString(), out var id))
                    {
                        id -= 1;
                        if (id < ShoppingCartRows.Count && id >= 0)
                        {
                            SelectedRow = ShoppingCartRows[id];
                            Step++;
                        }
                    }
                    break;
                case 2:
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.LeftArrow:
                            SelectedRow.Quantity--;
                            break;
                        case ConsoleKey.RightArrow:
                            SelectedRow.Quantity++;
                            break;
                        case ConsoleKey.D:
                            ShouldChangePage = true;
                            break;
                        case ConsoleKey.C:
                            deleteMode = false;
                            editMode = true;
                            ShouldChangePage = true;
                            break;
                    }
                    break;
            }
        }
        else
        {
            SelectedItem = Console.ReadKey().KeyChar;
            switch (SelectedItem)
            {
                case 'd':
                    deleteMode = true;
                    Step++;
                    break;
                case 'c':
                    ShouldChangePage = true;
                    break;
                case 'x':
                    ShouldChangePage = true;
                    break;
                default:
                    ShouldChangePage = false;
                    break;
            }
        }
    }
}
