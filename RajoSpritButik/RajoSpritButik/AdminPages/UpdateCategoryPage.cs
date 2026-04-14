using Entities.Models;

namespace RajoSpritButik.AdminPages;

internal class UpdateCategoryPage : Page
{
    private char selectedField = '0';
    private bool shouldPatch;
    public Category Category { get; set; }
    public UpdateCategoryPage(Category category)
    {
        Category = category;
    }


    public override ChangePageRequest? ChangePage()
    {
        if (shouldPatch)
        {
            shouldPatch = false;
            return new ChangePageRequest() { Page = "category", Action = RequestAction.Patch, Query = Category };
        }
        return new ChangePageRequest() { Page = "manage-categories" };

    }

    public override void Draw()
    {
        List<string> categoryFields = new()
        {
            $"1. Namn: {Category.Name}",
        };
        Window productWindow = new("Vald kategory", X, Y, categoryFields);
        productWindow.Draw();

        if (selectedField == '0')
        {
            Console.WriteLine("Tryck 1 för att redigera ett fält.");
            Console.WriteLine("Tryck C för att gå tillbaka");
        }
        else
        {
            switch (selectedField)
            {
                case '1': Console.Write("Skriv in ett nytt namn på kategorin: "); break;
                default: break;
            }
        }
    }

    public override void HandleInput()
    {
        if (selectedField == '0')
        {
            var key = Console.ReadKey(true).KeyChar;
            if (key >= '1' && key <= '1')
            {
                selectedField = key;
            }
            if (key == 'c' || key == 'C')
            {
                ShouldChangePage = true;
            }
        }
        else
        {
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                switch (selectedField)
                {
                    case '1':
                        Category.Name = input;
                        break;
                }

                shouldPatch = true;
                ShouldChangePage = true;
            }
            selectedField = '0';
        }
    }
}
