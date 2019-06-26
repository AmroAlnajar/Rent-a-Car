using System;

namespace Rent_a_Car.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public ApplicationUser Customer { get; set; }

        public string CustomerId { get; set; }

        public Car Car { get; set; }

        public int CarId { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime DateReturned { get; set; }

    }
}