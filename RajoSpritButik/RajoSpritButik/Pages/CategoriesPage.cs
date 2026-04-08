using Entities.Models;

namespace RajoSpritButik.Pages
{
    internal class CategoriesPage : Page
    {
        public List<Category> Categories { get; set; }
        public Category? SelectedItem { get; set; }
        public CategoriesPage(List<Category> categories, int x, int y, int width, int height) : base(x, y, width, height)
        {
            Categories = categories;
        }
        public override ChangePageRequest? ChangePage()
        {
            if (ShouldChangePage && SelectedItem != null)
            {
                return new ChangePageRequest() { Page = "category", Query = SelectedItem.Id };
            }
            return null;
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
        }

        public override void HandleInput()
        {
            var key = Console.ReadKey(true).KeyChar;

            if (int.TryParse(key.ToString(), out int keynum))
            {
                keynum -= 1;
                if (keynum < Categories.Count && keynum >= 0)
                {
                    ShouldChangePage = true;
                    SelectedItem = Categories[keynum];
                }
            }
        }
    }
}
