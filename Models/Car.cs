namespace Rent_a_Car.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Mod { get; set; }

        public int Price { get; set; }

        public string Picture { get; set; }

        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public Type Type { get; set; }

        public int TypeId { get; set; }
    }
}