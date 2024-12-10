using OrdersManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    internal class OrderService
    {
        private readonly List<Product> products;

        public OrderService()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(product.GetType().Name);

            products.Add(product);

            Console.WriteLine($"Dodano produkt: {product.Name} - {product.Price:zł}");
        }

        public bool RemoveProduct(int productId)
        {
            var product =
                products.
                FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine($"Usunięto produkt: {product.Name}");
                return true;
            }
            else
            {
                Console.WriteLine("Nie znaleziono produktu");
                return false;
            }
        }
        public OrderSummary GetOrderValue()
        {

            /*
            Jesli liczba produktow w zamowieniu jest podzielna zarowno przez 3 jak i przez 2 to naliczamy tylko promocje 20% na trzeci
            najtańszy produkt tj. np. w przypadku 6 produktów naliczamy 20% na 2 najtańsze itd.
            */

            float totalValue = 0;
            float totalDiscount = 0;
            var sortedProductsByPrices = products.OrderBy(p => p.Price).ToList();

            OrderSummary summary = new OrderSummary();

            if(products.Count % 3 == 0)
            {
                for (int i = 0; i < products.Count/3; i++)
                {
                    totalDiscount += sortedProductsByPrices[i].Price * 0.2f;
                }
            }
            else if(products.Count % 2 == 0)
            {
                for (int i = 0; i < products.Count / 2; i++)
                {
                    totalDiscount += sortedProductsByPrices[i].Price * 0.1f;
                }
            }
            if(sortedProductsByPrices.Sum(p=>p.Price)-totalDiscount > 5000)
            {
                totalDiscount += sortedProductsByPrices.Sum(p => p.Price) - totalDiscount * 0.05f;
            }

            totalValue = (sortedProductsByPrices.Sum(p => p.Price) - totalDiscount);

            summary.TotalDiscount = totalDiscount;
            summary.PriceWithoutDiscout = sortedProductsByPrices.Sum(p => p.Price);
            summary.Discount =totalDiscount;

            return summary;
        }
    }
}