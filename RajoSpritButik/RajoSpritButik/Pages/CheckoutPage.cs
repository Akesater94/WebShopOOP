using Entities.Models;

namespace RajoSpritButik.Pages;

internal class CheckoutPage : Page
{
    public ShoppingCart ShoppingCart { get; set; }

    public char? SelectedItem = null;
    public List<Address> Addresses { get; set; }
    public ShippingAlternative SelectedShippingAlternative { get; set; }
    public List<ShippingAlternative> ShippingAlternatives { get; set; }
    public List<PaymentAlternative> PaymentAlternatives { get; set; }
    public PaymentAlternative SelectedPaymentAlternative { get; set; }
    public Address SelectedAddress { get; set; } = null!;
    public int Step { get; set; } = 1;

    public CheckoutPage(List<Address> addresses, ShoppingCart shoppingCart, List<ShippingAlternative> shippingAlternatives, List<PaymentAlternative> paymentAlternatives, int x, int y, int width, int height) : base(x, y, width, height)
    {
        Addresses = addresses;
        ShoppingCart = shoppingCart;
        ShippingAlternatives = shippingAlternatives;
        PaymentAlternatives = paymentAlternatives;
    }
    public override ChangePageRequest? ChangePage()
    {
        switch (Step)
        {
            case 7:
                ShouldChangePage = false;
                return new ChangePageRequest() { Page = "user-address", Action = RequestAction.Post, Query = SelectedAddress };
        }

        return null;
    }

    public override void Draw()
    {
        switch (Step)
        {
            case 1:
                ShowAddresses();
                break;

            case 2:
                Console.Write("Lägg till gata: ");
                break;
            case 3:
                Console.Write("Lägg till gatunummer: ");
                break;
            case 4:
                Console.Write("Lägg till postnummer: ");
                break;
            case 5:
                Console.Write("Lägg till stad: ");
                break;
            case 6:
                Console.Write("Lägg till land: ");
                break;
            case 7:
                ShowShippingAlternatives();
                break;
            case 8:
                ShowPaymentAlternatives();
                break;
        }
    }

    public override void HandleInput()
    {
        switch (Step)
        {
            case 1:
                var key = Console.ReadKey().KeyChar;
                if (int.TryParse(key.ToString(), out int addressId))
                {
                    addressId -= 1;
                    if (addressId <= Addresses.Count && addressId >= 0)
                    {
                        Step = 7;
                        SelectedAddress = Addresses[addressId];
                    }
                }
                else if (key == 'n' || key == 'N')
                {
                    Step++;
                    SelectedAddress = new Address();
                }
                break;
            case 2:
                SelectedAddress.Street = Console.ReadLine();
                Step++;
                break;
            case 3:
                SelectedAddress.StreetNumber = Console.ReadLine();
                Step++;
                break;
            case 4:
                SelectedAddress.ZipCode = Console.ReadLine();
                Step++;
                break;
            case 5:
                SelectedAddress.City = Console.ReadLine();
                Step++;
                break;
            case 6:
                SelectedAddress.Country = new Country();
                SelectedAddress.Country.Name = Console.ReadLine();
                ShouldChangePage = true;
                Step++;
                break;
            case 7:

                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shippingAlternativeId))
                {
                    shippingAlternativeId -= 1;
                    if (shippingAlternativeId < ShippingAlternatives.Count && ShippingAlternatives.Count >= 0)
                    {
                        SelectedShippingAlternative = ShippingAlternatives[shippingAlternativeId];
                    }
                }
                Step++;
                break;
            case 8:
                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int paymentAlternativeId))
                {
                    paymentAlternativeId -= 1;
                    if (paymentAlternativeId < PaymentAlternatives.Count && PaymentAlternatives.Count >= 0)
                    {
                        SelectedPaymentAlternative = PaymentAlternatives[paymentAlternativeId];
                    }
                }
                Step++;
                break;
            case 9:
                Console.ReadKey();
                break;
        }

    }
    private void ShowAddresses()
    {
        int nextX = X;
        int nextY = Y;
        for (int i = 0; i < Addresses.Count; i++)
        {
            List<string> adresses = new List<string>()
            {
                (i+1).ToString(),
                "Gata: " + Addresses[i].Street.ToString() + " " + Addresses[i].StreetNumber.ToString(),
                "Postnummer: " + Addresses[i].ZipCode.ToString(),
                "Stad: " + Addresses[i].City.ToString(),
                "Land: " + Addresses[i].Country.Name.ToString(),
            };
            Window productWindow = new("", nextX, nextY, adresses);

            if (nextX + productWindow.WindowWidth > Width)
            {
                nextX = 0;
                productWindow.Left = nextX;
                nextY += 5;
                productWindow.Top = nextY;
            }

            productWindow.Draw();
            nextX += productWindow.WindowWidth + 2;
        }
        Console.WriteLine("Tryck N för att lägga till en ny adress");
        Console.Write("Tryck en siffra för att välja adress: ");
    }
    private void ShowShippingAlternatives()
    {
        int nextX = X;
        int nextY = Y;
        int i = 1;

        foreach (var shippingAlternative in ShippingAlternatives)
        {
            List<string> shippingInfo = new List<string>()
            {
                i.ToString(),
                shippingAlternative.Name,
                "Pris: " + shippingAlternative.Price
            };

            Window shippingWindow = new Window("", nextX, nextY, shippingInfo);

            if (nextX + shippingWindow.WindowWidth > Width)
            {
                nextX = 0;
                shippingWindow.Left = nextX;
                nextY += 5;
                shippingWindow.Top = nextY;
            }

            shippingWindow.Draw();
            nextX += shippingWindow.WindowWidth + 2;
            i++;
        }
        Console.Write("Välj fraktsätt genom att trycka in en siffra: ");
    }

    private void ShowPaymentAlternatives()
    {
        int nextX = X;
        int nextY = Y;
        int i = 1;

        foreach (var paymentAlternative in PaymentAlternatives)
        {
            List<string> paymentInfo = new List<string>()
            {
                i.ToString(),
                paymentAlternative.Name,
                "Avgift: " + paymentAlternative.Fee
            };

            Window paymentWindow = new Window("", nextX, nextY, paymentInfo);

            if (nextX + paymentWindow.WindowWidth > Width)
            {
                nextX = 0;
                paymentWindow.Left = nextX;
                nextY += 5;
                paymentWindow.Top = nextY;
            }

            paymentWindow.Draw();
            nextX += paymentWindow.WindowWidth + 2;
            i++;
        }

        Console.Write("Välj betalningsmetod genom att trycka in en siffra: ");
    }
}

