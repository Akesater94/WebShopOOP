using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RajoSpritButik.Pages;

internal class OrderConfirmationPage : Page
{
    public Order Order { get; set; }

    public OrderConfirmationPage(Order order)
    {
        Order = order;
    }

    public override ChangePageRequest? ChangePage()
    {
    }

    public override void Draw()
    {
        List<string> orderInfo = new List<string>()
        {
            "Tack för din beställning!",
            " ",
        };

        foreach (var orderRow in Order.OrderRows)
        {
            Product product = orderRow.Product;
            orderInfo.Add($"{orderRow.Quantity}st {product.Name} á {product.Price}kr.");
            orderInfo.Add($"Totalt: {product.Price * orderRow.Quantity}kr");

        }


        orderInfo.Add($"Du har valt att få dina varor genom {Order.ShippingAlternative.Name} till: ");
        orderInfo.Add($"{Order.Address.Street} {Order.Address.StreetNumber}");
        orderInfo.Add($"{Order.Address.ZipCode} {Order.Address.City}");
        orderInfo.Add($"{Order.Address.Country.Name}");


    }

    public override void HandleInput()
    {
    }
}
