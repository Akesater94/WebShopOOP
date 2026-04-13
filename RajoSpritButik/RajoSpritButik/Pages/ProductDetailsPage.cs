using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajoSpritButik.Pages;

internal class ProductDetailsPage : Page
{
    public Product SelectedProduct { get; set; }
    public ChangePageRequest? Redirect { get; set; }
    public bool AddMode { get; set; }

    public ProductDetailsPage(Product product, ChangePageRequest redirect)
    {
        SelectedProduct = product;
        Redirect = redirect;
    }
    public override ChangePageRequest? ChangePage()
    {
        if (AddMode)
        {
            AddMode = false;
            ShouldChangePage = false;
            return new ChangePageRequest() { Page = "shopping-cart-row", Action = RequestAction.Post, Query = SelectedProduct.Id };

        }
        if (Redirect == null)
        {
            return new ChangePageRequest() { Page = "menu" };
        }
        return Redirect;
    }

    public override void Draw()
    {
        List<string> productInfo = new List<string>()
        {
            $"Pris: {SelectedProduct.Price}kr",
            $"Beskrivning: {SelectedProduct.Description}",
            $"Tillverkare: {SelectedProduct.Manufacturer.Name}",
            $"Ursprungsland: {SelectedProduct.Manufacturer.Country.Name}",
        };

        Window productWindow = new Window(SelectedProduct.Name, X, Y, productInfo);
        productWindow.Draw();

        Console.WriteLine("Tryck A för att välja en produkt att lägga till.");
        Console.Write("Tryck C för att komma tillbaka.");
    }

    public override void HandleInput()
    {
        var input = Console.ReadKey().Key;
        if (input == ConsoleKey.C)
        {
            ShouldChangePage = true;
        }
        else if (input == ConsoleKey.A)
        {
            AddMode = true;
            ShouldChangePage = true;
        }
    }
}
