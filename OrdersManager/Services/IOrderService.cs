using OrdersManager.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public interface IOrderService
    {
        List<Product> ListOfProducts { get; }
        void AddProduct(int productId);
        void DisplayOrder();
        OrderSummary GetOrderValue();
        bool RemoveProduct(int productId);
    }
}