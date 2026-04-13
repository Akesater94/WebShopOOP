using Entities.Models;

namespace RajoSpritButik.Pages
{
    internal class CategoriesPage : Page
    {
        public List<Category> Categories { get; set; }
        public Category? SelectedCategory { get; set; }
        public char? SelectedItem { get; set; }
        public CategoriesPage(List<Category> categories) : base()
        {
            Categories = categories;
        }
        public override ChangePageRequest? ChangePage()
        {
            if (ShouldChangePage && SelectedCategory != null)
            {
                return new ChangePageRequest() { Page = "category", Query = SelectedCategory.Id };
            }
            else
            {
                return new ChangePageRequest() { Page = "menu" };
            }
        }

        public override void Draw()
        {
            List<string> categoryList = new List<string>();
            for (int i = 0; i < Categories.Count; i++)
            {
                categoryList.Add($"{i + 1}. {Categories[i].Name}");
            }
            Window categoryWindow = new Window("Kategorier", X, Y, categoryList);
            categoryWindow.Draw();

            Console.WriteLine("Tryck en siffra för att välja en kategori.");
            Console.WriteLine("Tryck C för att gå tillbaka till menyn.");

        }

        public override void HandleInput()
        {
            SelectedItem = Console.ReadKey(true).KeyChar;

            if (int.TryParse(SelectedItem.ToString(), out int keynum))
            {
                keynum -= 1;
                if (keynum < Categories.Count && keynum >= 0)
                {
                    ShouldChangePage = true;
                    SelectedCategory = Categories[keynum];
                }
            }
            else
            {
                switch (SelectedItem.ToString().ToUpper())
                {
                    case "C":
                        ShouldChangePage = true;
                        break;

                    default:
                        ShouldChangePage = false;
                        break;
                }
            }
        }
    }
}
