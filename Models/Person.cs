
using System.ComponentModel.DataAnnotations;

namespace CarsAPIWebApp.Models
{
    public class Person
    {
        public Person()
        {
            PersonCars=new HashSet<PersonCar>();
        }
        [Key]
        public int PersonId { get; set; }
        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; } = null!;
        [Display(Name = "Адреса")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Address { get; set; } = null!;
        public virtual ICollection<PersonCar> PersonCars { get; set; }
    }
}