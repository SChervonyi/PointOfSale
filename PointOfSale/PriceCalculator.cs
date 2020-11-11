using PointOfSale.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PointOfSale
{
    class PriceCalculator
    {
        private IDictionary<string, IList<ProductPrice>> _productPricesDictionary = new Dictionary<string, IList<ProductPrice>>();

        public PriceCalculator(IEnumerable<ProductPrice> pricesList)
        {
            if (pricesList == null) throw new ArgumentNullException(nameof(pricesList));

            foreach (var price in pricesList)
            {
                if (!_productPricesDictionary.ContainsKey(price.ProductName))
                {
                    _productPricesDictionary.Add(price.ProductName, new List<ProductPrice> { price });
                }
                else
                {
                    _productPricesDictionary[price.ProductName].Add(price);
                }
            }
        }

        public double CalculateOrderTotal(IEnumerable<OrderItem> orderItems)
        {
            return orderItems.Sum(orderItem => CalculateSubTotal(orderItem.Quantity, _productPricesDictionary[orderItem.ProductName]));
        }

        private double CalculateSubTotal(int quantity, IList<ProductPrice> prices)
        {
            var pricesOrderedByPriority = prices.OrderByDescending(price => price.PricePriority);
            foreach (var productPrice in pricesOrderedByPriority)
            {
                if(!IsApplicablePrice(quantity, productPrice))
                    continue;

                return productPrice.Price + CalculateSubTotal(quantity - productPrice.ProductQantity, prices);
            }

            return 0;
        }

        private bool IsApplicablePrice(int qantity, ProductPrice price)
        {
            return qantity >= price.ProductQantity;
        }
    }
}
