using System;

namespace Rent_a_Car.Models
{
    public class RentalViewModel
    {

        public int CarId { get; set; }
        public string CustomerId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string CarMake { get; set; }
        public string CarMod { get; set; }
        public int CarPrice { get; set; }
        public string CarPicture { get; set; }
        public DateTime DateRented { get; set; }
        public int DaysToRent { get; set; }

    }
}