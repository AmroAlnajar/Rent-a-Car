using System.ComponentModel.DataAnnotations;

namespace Rent_a_Car.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Make")]
        public string Make { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Mod { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }

        //[Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Number available")]
        public int NumberAvailable { get; set; }


        public Type Type { get; set; }

        [Required]
        [Display(Name = "Car type")]
        public int TypeId { get; set; }
    }
}