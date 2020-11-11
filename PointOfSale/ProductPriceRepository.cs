using PointOfSale.Models;
using System.Collections.Generic;

namespace PointOfSale
{
    public class ProductPriceRepository
    {
        public IList<ProductPrice> GetProductPrices()
        {
            return new List<ProductPrice>
            {
                new ProductPrice { ProductName = "A", PricePriority = 0, Price = 1.25, ProductQantity = 1 },
                new ProductPrice { ProductName = "A", PricePriority = 1, Price = 3, ProductQantity = 3 },
                new ProductPrice { ProductName = "B", PricePriority = 0, Price = 4.25, ProductQantity = 1 },
                new ProductPrice { ProductName = "C", PricePriority = 0, Price = 1, ProductQantity = 1 },
                new ProductPrice { ProductName = "C", PricePriority = 1, Price = 5, ProductQantity = 6 },
                new ProductPrice { ProductName = "D", PricePriority = 0, Price = 0.75, ProductQantity = 1 }
            };
        }
    }
}
