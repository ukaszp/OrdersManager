﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Data
{
    public class OrderSummary
    {
        public float TotalDiscount { get; set; }
        public float PriceWithoutDiscout { get; set; }
        public float Discount { get; set; }
    }
}
