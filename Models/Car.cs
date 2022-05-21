using System.ComponentModel.DataAnnotations;
namespace CarsAPIWebApp.Models
{
    public class Car
    {
        public Car()
        {
            PersonCars = new HashSet<PersonCar>();
        }
        [Key]
        public int CarId { get; set; }
        [Display(Name = "Ціна авто")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public double Price { get; set;}
        [Display(Name = "Назва авто")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; } = null!;
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual ICollection<PersonCar> PersonCars { get; set; }

    }
}