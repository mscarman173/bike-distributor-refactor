using System;
using System.Collections.Generic;
using System.Linq;

namespace BikeDistributor
{
    public class Order
    {
        private const decimal TaxRate = 0.0725m;
        private readonly IList<Line> _lines = new List<Line>();

        public Order(string company)
        {
            if (string.IsNullOrWhiteSpace(company))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(company));

            Company = company;
        }

        public string Company { get; }

        public void AddLine(Bike bike, int quantity)
        {
            _lines.Add(CreateLineItem(bike, quantity));
        }

        public IEnumerable<Line> LineItems => _lines;

        public decimal SubTotal => _lines.Sum(l => l.ItemTotal);

        public decimal Tax => SubTotal * TaxRate;

        public decimal Total => SubTotal + Tax;

        private Line CreateLineItem(Bike bike, int quantity)
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

            return new Line(quantity, price, bike.Description);
        }
    }
}
