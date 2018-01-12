using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor
{
    public class Order
    {
        private const decimal TaxRate = 0.0725m;
        private readonly IList<OrderItem> _orderItems = new List<OrderItem>();

        public Order(string company)
        {
            if (string.IsNullOrWhiteSpace(company))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(company));

            Company = company;
        }

        public string Company { get; }

        public void AddItem(Bike bike, int quantity)
        {
            _orderItems.Add(CreateLineItem(bike, quantity));
        }

        public IEnumerable<OrderItem> OrderItems => _orderItems;

        public decimal SubTotal => _orderItems.Sum(l => l.ItemTotal);

        public decimal Tax => SubTotal * TaxRate;

        public decimal Total => SubTotal + Tax;

        private OrderItem CreateLineItem(Bike bike, int quantity)
        {
            var price = bike.Price;

            if (price == Bike.OneThousand && quantity > 20)
            {
                price = price * 0.9m;
            }
            else if (price == Bike.TwoThousand && quantity >= 10)
            {
                price = price * 0.8m;
            }
            else if (price == Bike.FiveThousand && quantity >= 5)
            {
                price = price * 0.8m;
            }

            return new OrderItem(quantity, price, bike.Description);
        }
    }
}
