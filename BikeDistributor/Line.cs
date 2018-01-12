using System;

namespace BikeDistributor
{
    public class Line
    {
        private readonly Bike _bike;

        public Line(Bike bike, int quantity, decimal price)
        {
            _bike = bike ?? throw new ArgumentNullException(nameof(bike));
            Quantity = quantity;
            Price = price;
        }

        public int Quantity { get; }

        public decimal Price { get; }

        public string Description => $"{_bike.Brand} {_bike.Model}";

        public decimal ItemTotal => Quantity * Price;
    }
}
