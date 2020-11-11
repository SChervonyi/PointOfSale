using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Models
{
    class Order
    {
        public IDictionary<string, OrderItem> Items { get; set; }
    }
}
