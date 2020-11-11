using PointOfSale.Models;
using System;
using System.Collections.Generic;

namespace PointOfSale
{
    // README: To easy start and test use the code below:
    // ------------- CODE EXAMPLE -------------
    // var repository = new ProductPriceRepository();
    // var terminal = new PointOfSaleTerminal();
    // terminal.SetPricing(repository.GetProductPrices());

    public class PointOfSaleTerminal
    {
        private Order _order = new Order { Items = new Dictionary<string, OrderItem>() };
        private PriceCalculator _priceCalculator;

        public void SetPricing(IEnumerable<ProductPrice> pricesList)
        {
            _priceCalculator = new PriceCalculator(pricesList);
        }

        public void Scan(string productName)
        {
            if (_order.Items.ContainsKey(productName))
            {
                _order.Items[productName].Quantity += 1;
            }
            else
            {
                var newOrderItem = new OrderItem { ProductName = productName, Quantity = 1 };
                _order.Items.Add(productName, newOrderItem);
            }
        }

        public double CalculateTotal()
        {
            if (_priceCalculator == null) throw new Exception("No product prices");

            var priceResult = _priceCalculator.CalculateOrderTotal(_order.Items.Values);
            _order = new Order { Items = new Dictionary<string, OrderItem>() };
            return priceResult;
        }
    }
}
