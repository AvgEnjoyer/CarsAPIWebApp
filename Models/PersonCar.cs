
using System.ComponentModel.DataAnnotations;

namespace CarsAPIWebApp.Models
{
    public class PersonCar
    {
        public PersonCar()
        { }
        [Key]
        public int Id { get; set; } 
        public int PersonId { get; set; }
        public int CarId { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual Car Car { get; set; } = null!;
    }
}