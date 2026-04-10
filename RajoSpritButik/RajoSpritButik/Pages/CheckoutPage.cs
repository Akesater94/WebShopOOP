using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RajoSpritButik.Pages;

internal class CheckoutPage : Page
{
    public List<Product> Products { get; set; } = [];
    public bool AddMode { get; set; }

    public char? SelectedItem = null;
    public List<Address> Addresses { get; set; }
    public Address SelectedAddress { get; set; }
    public int Step { get; set; }

    public CheckoutPage(List<Product> products, int x, int y, int width, int height, List<Address> addresses) : base(x, y, width, height)
    {
        Products = products;
        Addresses = addresses;
    }
    public override ChangePageRequest? ChangePage()
    {
        throw new NotImplementedException();
    }

    public override void Draw()
    {
        switch (Step)
        {
            case 1:
                if (AddMode)
                {
                    AddNewAddress();
                }
                else
                {
                    ShowAddresses();
                }
                break;

            case 2:
                break;
        }
        //if (AddMode)
        //{

        //}
        //else
        //{
        //ShowAddresses();
        //}
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
                "Gata: " + Addresses[i].Street.ToString() + Addresses[i].StreetNumber.ToString(),
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
                if (!AddMode)
                {
                    var key = Console.ReadKey().KeyChar;
                    if (int.TryParse(key.ToString(), out int addressId))
                    {
                        addressId -= 1;
                        if (addressId <= Addresses.Count && addressId >= 0)
                        {
                            Step++;
                            SelectedAddress = Addresses[addressId];
                        }
                    }

                }
                else
                {
                    var key = Console.ReadKey().KeyChar;
                    
                }
                    break;
        }

    }
    public void AddNewAddress()
    {
        
    }
    
}

