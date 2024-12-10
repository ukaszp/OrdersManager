using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class MainMenu:IMenu
    {
        private readonly IOrderService orderService;

        public MainMenu(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public MenuAction Display()
        {
            Console.Clear();
            bool exit = false;
            Menu menu = new Menu();
            List<string> elements = new List<string> { "Dodaj produkt", "Usuń produkt", "Wyjdź" };
            menu.Setup(elements);
            orderService.DisplayOrder();

            while (!exit)
            {
                var selection = menu.Open();
                switch (selection)
                {
                    case 0:
                        return MenuAction.GoToProductMenu;
                    case 1:
                        return MenuAction.GoToDeleteMenu;
                    case 3:
                        Environment.Exit(0);
                        return MenuAction.Exit;
                }
            }
            return MenuAction.Stay;
        }

    }
}
