using Entities.Models;

namespace RajoSpritButik.AdminPages;

internal class CreateCategoryPage : Page
{
    Category Category { get; set; }
    public CreateCategoryPage()
    {
        Category = new();
    }

    public override ChangePageRequest? ChangePage()
    {
        return new ChangePageRequest { Page = "category", Action = RequestAction.Post, Query = Category };
    }

    public override void Draw()
    {
        Console.Write("Skriv in namnet på den nya kategorin: ");
    }

    public override void HandleInput()
    {
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
        {
            Category.Name = input;
            ShouldChangePage = true;
        }
        else
        {
            Console.WriteLine("Ogiltig inmatning, försök igen.");
            System.Threading.Thread.Sleep(500);
        }
    }
}

