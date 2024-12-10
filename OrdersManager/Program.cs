using Microsoft.Extensions.DependencyInjection;
using OrdersManager.Services;
using OrdersManager.Services.OrdersManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddSingleton<IOrderService, OrderService>()
               .AddSingleton<IMenu, MainMenu>()
               .AddSingleton<IMenu, ProductsMenu>()
               .AddSingleton<IMenu, DeleteProductsMenu>()
               .BuildServiceProvider();

            var orderService = serviceProvider.GetService<IOrderService>();

            IMenu mainMenu = new MainMenu(orderService);
            IMenu productMenu = new ProductsMenu(orderService);
            IMenu deleteMenu = new DeleteProductsMenu(orderService);

            var controller = new MenuController(mainMenu, productMenu, deleteMenu);
            controller.Run();

            Console.ReadKey(true);
        }
    }
    }

