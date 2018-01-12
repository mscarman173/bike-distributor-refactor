using System;

namespace BikeDistributor
{
    public class Bike
    {
        public const decimal OneThousand = 1000;
        public const decimal TwoThousand = 2000;
        public const decimal FiveThousand = 5000;

        public Bike(string brand, string model, decimal price)
        {
            if (string.IsNullOrWhiteSpace(brand))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(brand));
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(model));

            Brand = brand;
            Model = model;
            Price = price;
        }

        public string Brand { get; }

        public string Model { get; }

        public decimal Price { get; }

        public string Description => $"{Brand} {Model}";
    }
}