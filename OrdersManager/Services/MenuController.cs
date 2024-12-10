using OrdersManager.Services.OrdersManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class MenuController
    {
        private readonly IMenu mainMenu;
        private readonly IMenu productMenu;
        private readonly IMenu deleteMenu;
        private IMenu currentMenu;

        public MenuController(IMenu mainMenu, IMenu productMenu, IMenu deleteMenu)
        {
            this.mainMenu = mainMenu;
            this.productMenu = productMenu;
            this.deleteMenu = deleteMenu;
            this.currentMenu = mainMenu;
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                var action = currentMenu.Display();

                switch (action)
                {
                    case MenuAction.GoToMainMenu:
                        currentMenu = mainMenu;
                        break;
                    case MenuAction.GoToProductMenu:
                        currentMenu = productMenu;
                        break;
                    case MenuAction.GoToDeleteMenu:
                        currentMenu = deleteMenu;
                        break;
                    case MenuAction.Exit:
                        running = false;
                        break;
                    case MenuAction.Stay:
                    default:
                        break;
                }
            }
        }
    }

}
