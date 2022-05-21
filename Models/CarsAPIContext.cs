using Microsoft.EntityFrameworkCore;
namespace CarsAPIWebApp.Models
{
    public class CarsAPIContext: DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<PersonCar> PersonCars { get; set; } = null!;


        public CarsAPIContext(DbContextOptions<CarsAPIContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
