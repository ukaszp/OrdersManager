﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Data
{
    public class Order
    {
        public List<Product> Items { get; set; } = new List<Product>();
    }
}
