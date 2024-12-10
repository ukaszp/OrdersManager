using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Data
{
    internal class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
