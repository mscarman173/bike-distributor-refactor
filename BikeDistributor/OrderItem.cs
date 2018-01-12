using System;

namespace BikeDistributor
{
    public class OrderItem
    {
        public OrderItem(int quantity, decimal price, string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(description));

            Quantity = quantity;
            Price = price;
            Description = description;
        }

        public int Quantity { get; }

        public decimal Price { get; }

        public string Description { get; }

        public decimal ItemTotal => Quantity * Price;
    }
}
