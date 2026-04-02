using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace RajoSpritButik.Pages
{
    internal class MenuPage : Page
    {
        public char? SelectedItem { get; set; }
        public MenuPage(int x, int y, int width, int height) : base(x, y, width, height)
        {

        }
        public override ChangePageRequest? ChangePage()
        {
            if (ShouldChangePage)
            {
                switch (SelectedItem)
                {
                    case '1':
                        return new ChangePageRequest() { Page = "welcome" };
                    case '2':
                        return null;
                    case '3':
                        return null;
                    case '4':
                        return null;
                    default:
                        return null;
                }
            }
            return null;

        }

        public override void Draw()
        {
            List<string> menuContent = new List<string>()
            {
                "1. Hem",
                "2. Handla",
                "3. Gå till varukorg",
                "4. Logga in (Administratör)"
            };
            Window menuWindow = new Window("Menu", X, Y, menuContent);
            menuWindow.Draw();
        }

        public override void HandleInput()
        {

            SelectedItem = Console.ReadKey().KeyChar;
            switch (SelectedItem)
            {
                case '1':
                    ShouldChangePage = true;
                    break;
                case '2':
                    ShouldChangePage = true;
                    break;
                case '3':
                    ShouldChangePage = true;
                    break;
                case '4':
                    ShouldChangePage = true;
                    break;
                default:
                    ShouldChangePage = false;
                    break;
            }
        }
    }
}
