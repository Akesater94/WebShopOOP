using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RajoSpritButik.Pages;

internal class CheckoutPage : Page
{
    public ShoppingCart ShoppingCart { get; set; }

    public char? SelectedItem = null;
    public List<Address> Addresses { get; set; }
    public Address SelectedAddress { get; set; } = null!;
    public int Step { get; set; } = 1;

    public CheckoutPage(List<Address> addresses, ShoppingCart shoppingCart, int x, int y, int width, int height) : base(x, y, width, height)
    {
        Addresses = addresses;
        ShoppingCart = shoppingCart;
    }
    public override ChangePageRequest? ChangePage()
    {
        if (Step == 7)
        {
            return new ChangePageRequest() { Page = "user-address", Action = RequestAction.Post, Query = SelectedAddress };
        }
        else if (Step == 8)
        {
            return new ChangePageRequest() { Page = "checkout" };
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
                Console.WriteLine("Adress tillagd!");
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
                Console.ReadKey();
                ShouldChangePage = true;
                Step++;
                break;
        }

    }

}

