using Entities.Models;
using RajoSpritButik.UIComponents;

namespace RajoSpritButik.AdminPages;

internal class ManageCategoriesPage : Page
{
    public List<Category> Categories { get; set; }
    public char SelectedItem { get; set; }
    public bool SelectMode { get; set; }
    public Category? SelectedCategory { get; set; }
    public char Input { get; set; }
    public bool CreateMode { get; private set; }
    public ManageCategoriesPage(List<Category> categories)
    {
        Categories = categories;
    }

    public override ChangePageRequest? ChangePage()
    {
        if (SelectMode && SelectedCategory != null)
        {
            if (Input == 's' || Input == 'S')
            {
                return new ChangePageRequest() { Page = "update-category", Query = SelectedCategory.Id };
            }
            else if (Input == 'd' || Input == 'D')
            {
                return new ChangePageRequest() { Page = "category", Action = RequestAction.Delete, Query = SelectedCategory.Id };
            }
        }
        else if (CreateMode)
        {
            return new ChangePageRequest() { Page = "create-category" };
        }
        else if (Input == 'c' || Input == 'C')
        {
            return new ChangePageRequest() { Page = "admin-menu" };
        }
        return null;
    }

    public override void Draw()
    {
        Table<Category> categoryTable = new(
            Categories,
            "Produkter",
            $"{"#".PadRight(3)}{"Namn".PadRight(15)}",
            (c, i) => $"{(i + 1).ToString().PadRight(3)}{c.Name.PadRight(15)}",
            X,
            Y
        );
        categoryTable.Draw();
        if (SelectMode)
        {
            Console.Write("Vilken kategori vill du välja?: ");
        }
        else
        {
            Console.WriteLine("Tryck S för att välja kategori att hantera.");
            Console.WriteLine("Tryck D för att välja kategori att ta bort.");
            Console.WriteLine("Tryck N för att skapa en ny kategori.");
            Console.WriteLine("Tryck C för att gå tillbaka till menyn.");
        }
    }

    public override void HandleInput()
    {
        if (SelectMode)
        {
            string? selectedItem = Console.ReadLine();
            if (int.TryParse(selectedItem, out var productId))
            {
                productId -= 1;
                if (productId < Categories.Count && productId >= 0)
                {
                    SelectedCategory = Categories[productId];
                    ShouldChangePage = true;
                }
            }
        }
        else
        {
            Input = Console.ReadKey().KeyChar;
            switch (Input.ToString().ToUpper())
            {
                case "C":
                    ShouldChangePage = true;
                    break;
                case "S":
                case "D":
                    SelectMode = true;
                    break;
                case "N":
                    CreateMode = true;
                    ShouldChangePage = true;
                    break;
            }
        }
    }
}
