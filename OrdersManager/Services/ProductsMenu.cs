using Newtonsoft.Json;
using OrdersManager.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class ProductsMenu : IMenu
    {
        private readonly IOrderService orderService;
        private List<Product> productsToBuy;

        public ProductsMenu(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        public MenuAction Display()
        {

            Console.Clear();
            bool exit = false;
            Menu menu = new Menu();
            var productsNames = orderService.ListOfProducts.Select(p => p.Name).ToList();
            productsNames.Add("Cofnij");

            menu.Setup(productsNames);
            orderService.DisplayOrder();


            while (!exit)
            {
                var selection = menu.Open();
                switch (selection)
                {
                    case 0:
                        orderService.AddProduct(1);
                        Display();
                        return MenuAction.Stay;
                    case 1:
                        orderService.AddProduct(2);
                        Display();
                        return MenuAction.Stay;
                    case 2:
                        orderService.AddProduct(3);
                        Display();
                        return MenuAction.Stay;
                    case 3:
                        orderService.AddProduct(4);
                        Display();
                        return MenuAction.Stay;
                    case 4:
                        orderService.AddProduct(5);
                        Display();
                        return MenuAction.Stay;
                    case 5:
                        return MenuAction.GoToMainMenu;
                }

            }

            return MenuAction.Stay;
        }




    }


}

