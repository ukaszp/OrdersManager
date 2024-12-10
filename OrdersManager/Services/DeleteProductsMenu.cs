namespace OrdersManager.Services
{
    using global::OrdersManager.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace OrdersManager.Services
    {
        public class DeleteProductsMenu : IMenu
        {
            private readonly IOrderService orderService;
            private List<Product> productsToBuy;

            public DeleteProductsMenu(IOrderService orderService)
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
                            orderService.RemoveProduct(1);
                            Display();
                            return MenuAction.Stay;
                        case 1:
                            orderService.RemoveProduct(2);
                            Display();
                            return MenuAction.Stay;
                        case 2:
                            orderService.RemoveProduct(3);
                            Display();
                            return MenuAction.Stay;
                        case 3:
                            orderService.RemoveProduct(4);
                            Display();
                            return MenuAction.Stay;
                        case 4:
                            orderService.RemoveProduct(5);
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


}
