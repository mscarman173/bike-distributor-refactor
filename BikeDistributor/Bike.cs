namespace BikeDistributor
{
    public class Bike
    {
        public const decimal OneThousand = 1000;
        public const decimal TwoThousand = 2000;
        public const decimal FiveThousand = 5000;
    
        public Bike(string brand, string model, decimal price)
        {
            Brand = brand;
            Model = model;
            Price = price;
        }

        public string Brand { get; private set; }
        public string Model { get; private set; }
        public decimal Price { get; set; }
    }
}
