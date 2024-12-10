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
    public class OrderService : IOrderService
    {
        private readonly List<Product> products;

        public List<Product> ListOfProducts { get; private set; }

        public OrderService()
        {
            products = new List<Product>();
            ListOfProducts = GetProducts().Result;
        }

        public void AddProduct(int productId)
        {
            var product =
             ListOfProducts.
             FirstOrDefault(p => p.Id == productId);

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

            Dla 5 produktów naliczymy zniżkę jak dla 4 produktów (2 pełne pary).
            Dla 13 produktów naliczymy zniżkę jak dla 12 produktów (4 pełne trójki).
            */

            int productCount = products.Count;
            float totalValue = 0f;
            float totalDiscount = 0f;
            var sortedProductsByPrices = products.OrderBy(p => p.Price).ToList();

            OrderSummary summary = new OrderSummary();

            int tripleGroups = productCount / 3;
            if (tripleGroups > 0) 
            {
                for (int i = 0; i < tripleGroups; i++)
                {
                    totalDiscount += sortedProductsByPrices[i].Price * 0.2f;
                }
            }
            else if(productCount/2 > 0)
            {
                int pairs = productCount / 2;
                for (int i = 0; i < pairs; i++)
                {
                    totalDiscount += sortedProductsByPrices[i].Price * 0.1f;
                }
            }
            if (sortedProductsByPrices.Sum(p => p.Price) - totalDiscount > 5000)
            {
                totalDiscount += sortedProductsByPrices.Sum(p => p.Price)  * 0.05f;
            }

            totalValue = (sortedProductsByPrices.Sum(p => p.Price) - totalDiscount);

            summary.TotalDiscount = totalDiscount;
            summary.PriceWithoutDiscout = sortedProductsByPrices.Sum(p => p.Price);
            summary.Discount = totalDiscount;

            return summary;
        }

        public void DisplayOrder()
        {
            if (!products.Any())
            {
                Console.WriteLine("Zamówienie jest puste.");
                return;
            }

            Console.WriteLine("Szczegóły zamówienia:");
            Console.WriteLine("----------------------");

            foreach (var product in products)
            {
                Console.WriteLine($"Produkt: {product.Name}, Cena: {product.Price} zł");
            }

            Console.WriteLine("----------------------");

            var summary = GetOrderValue();

            Console.WriteLine($"Łączna wartość (bez zniżek): {summary.PriceWithoutDiscout} zł");
            Console.WriteLine($"Zniżki: {summary.TotalDiscount} zł");
            Console.WriteLine($"Łączna wartość (po zniżkach): {summary.PriceWithoutDiscout - summary.TotalDiscount} zł");
        }

        private async Task<List<Product>> GetProducts()
        {
            try
            {
                string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string filePath = Path.Combine(projectDirectory, "products.json");

                using (FileStream fs = File.OpenRead(filePath))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string json = await sr.ReadToEndAsync();
                    return JsonConvert.DeserializeObject<List<Product>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas odczytu pliku: {ex.Message}");
                return new List<Product>();
            }
        }
    }
}