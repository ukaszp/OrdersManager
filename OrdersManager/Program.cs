using OrdersManager.Services;
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

            bool exit = false;
            Menu menu = new Menu();
            List<string> elements = new List<string>{ "Dodaj produkt", "Usuń produkt", "Wyświetl wartość zamówienia", "Wyjdź"};
            menu.Setup(elements);

            while (!exit)
            {
                var selection = menu.Open();
                switch (selection)
                {
                    case 0:
                        // case
                        break;
                    case 1:
                        //case
                        break;
                    case 3:
                        System.Environment.Exit(1);
                        break;
                }
                Console.Clear();
            }

            Console.ReadKey(true);
        }
    }
    }

