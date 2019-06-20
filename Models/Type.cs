using System.ComponentModel.DataAnnotations;

namespace Rent_a_Car.Models
{
    public class Type
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}