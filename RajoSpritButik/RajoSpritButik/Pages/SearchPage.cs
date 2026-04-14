using System;
using System.Collections.Generic;
using System.Text;

namespace RajoSpritButik.Pages;
internal class SearchPage : Page
{
public string? Input { get; set; }
    public override ChangePageRequest? ChangePage()
    {
        return new ChangePageRequest() { Page = "search", Action = RequestAction.Post, Query = Input };
    }

    public override void Draw()
    {
        List<string> searchInput = new List<string>()
        {
            "Sök efter en produkt: ".PadRight(40)
        };
        Window searchWindow = new Window("", X, Y, searchInput);
        searchWindow.Draw();
    }

    public override void HandleInput()
    {
        Console.SetCursorPosition(X + 24, Y + 1);
        Input = Console.ReadLine();
        ShouldChangePage = true;
    }
}
